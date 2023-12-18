using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ExpandingFlame : MonoBehaviour
{
    public static ExpandingFlame Instance { get; private set; }

    List<GameObject> _alreadyDownSnowList = new List<GameObject>();
    float _shrinkTimer = 0;

    [Header("Flame")]
    [SerializeField] float _shrinkSpeed;
    [SerializeField] float _growthSpeed;
    [SerializeField] float _flameGrowthFromWood = 2f;
    [SerializeField] private FlameCylinderMeshGenerator _flameCylinder;

    [Header("Snow Movement")]
    [SerializeField] float _snowMovementDuration = 1f;
    [SerializeField] float _snowMovementOffset = 0.5f;

    [Header("Other")]
    [SerializeField] bool _doesSnowComeBackUp = false;

    public float ShrinkSpeed { get { return _shrinkSpeed; } set { _shrinkSpeed = value; } }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetCylinderRange(transform.localScale.x);
        Shader.SetGlobalFloat("_FlameRange", transform.localScale.x);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            StartCoroutine(LerpFlameScale(_growthSpeed, 5));

        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(LerpFlameScale(_growthSpeed, -5));

        _shrinkTimer += Time.deltaTime;

        SetCylinderRange(transform.localScale.x);
        Shader.SetGlobalFloat("_FlameRange", transform.localScale.x);
    }

    private void FixedUpdate()
    {
        Vector3 currentScale = transform.localScale;

        currentScale.x -= _shrinkSpeed * Time.deltaTime / 20f;
        currentScale.z -= _shrinkSpeed * Time.deltaTime / 20f;

        transform.localScale = currentScale;

        if (currentScale.x <= 5f && currentScale.z <= 5f)
        {
            GameManager.instance.Lose();
        }
    }

    //used to make "Snow" tagged objects go under and above when needed. Values can be tweaked via editor
    IEnumerator LerpSnowPosition(float duration, GameObject objectToMove)
    {
        Vector3 targetPosition;
        BoxCollider collider = objectToMove.GetComponent<BoxCollider>();

        if (_alreadyDownSnowList.Contains(objectToMove) && _doesSnowComeBackUp)
        {
            targetPosition = objectToMove.transform.position + new Vector3(0, _snowMovementOffset, 0);
            _alreadyDownSnowList.Remove(objectToMove);
            objectToMove.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(ReEnableCollider(collider));
        }
        else
        {
            targetPosition = objectToMove.transform.position + new Vector3(0, -_snowMovementOffset, 0);
            _alreadyDownSnowList.Add(objectToMove);
        }

        float time = 0;
        Vector3 startPosition = objectToMove.transform.position;
        while (time < duration)
        {
            objectToMove.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        objectToMove.transform.position = targetPosition;
    }

    private void SetCylinderRange(float scaleFactor)
    {
        _flameCylinder.Radius = scaleFactor / 2;
    }

    //used for debugging purposes
    IEnumerator LerpFlameScale(float duration, float addSize, bool isScalingDown = false)
    {
        float time = 0;
        float startSizeX = transform.localScale.x;
        float startSizeY = transform.localScale.y;
        float startSizeZ = transform.localScale.z;
        while (time < duration)
        {
            transform.localScale = new Vector3(Mathf.Lerp(startSizeX, startSizeX + addSize, time / duration), transform.localScale.y, Mathf.Lerp(startSizeX, startSizeZ + addSize, time / duration));
            SetCylinderRange(transform.localScale.x);
            Shader.SetGlobalFloat("_FlameRange", transform.localScale.x);
            time += Time.deltaTime;
            yield return null;
        }
    }

    public void StartLerpFlameScale(int amount)
    {
        StartCoroutine(LerpFlameScale(_growthSpeed, amount));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Snow"))
        {
            other.GetComponent<BoxCollider>().isTrigger = true;
            StartCoroutine(LerpSnowPosition(_snowMovementDuration, other.gameObject));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_doesSnowComeBackUp)
        {
            if (_alreadyDownSnowList.Contains(other.gameObject))
            {
                if (other.gameObject.CompareTag("Snow"))
                {
                    StartCoroutine(LerpSnowPosition(_snowMovementDuration, other.gameObject));

                }
            }
        }
    }

    private IEnumerator ReEnableCollider(BoxCollider collider)
    {
        yield return new WaitForSeconds(3f);
        collider.enabled = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, transform.localScale.y/2);
    }
}
