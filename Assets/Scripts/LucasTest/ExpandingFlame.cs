using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingFlame : MonoBehaviour
{
    List<GameObject> _alreadyDownSnowList = new List<GameObject>();
    float _shrinkTimer = 0;

    [Header("Flame")]
    [SerializeField] float _shrinkSpeed;
    [SerializeField] float _growthSpeed;
    [SerializeField] float _flameGrowthFromWood = 2f;

    [Header("Snow Movement")]
    [SerializeField] float _snowMovementDuration = 1f;
    [SerializeField] float _snowMovementOffset = 0.5f;

    [Header("Other")]
    [SerializeField] bool _doesSnowComeBackUp = false;

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            StartCoroutine(LerpFlameScale(_growthSpeed, 5));

        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(LerpFlameScale(_growthSpeed, -5));

        _shrinkTimer += Time.deltaTime;
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime / _shrinkSpeed);
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

    //used for debugging purposes
    IEnumerator LerpFlameScale(float duration, float addSize, bool isScalingDown = false)
    {
        float time = 0;
        float startSizeX = transform.localScale.x;
        float startSizeY = transform.localScale.y;
        float startSizeZ = transform.localScale.z;
        while (time < duration)
        {
            transform.localScale = new Vector3(Mathf.Lerp(startSizeX, startSizeX + addSize, time / duration), Mathf.Lerp(startSizeX, startSizeY + addSize, time / duration), Mathf.Lerp(startSizeX, startSizeZ + addSize, time / duration));
            time += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Snow"))
        {
            other.GetComponent<BoxCollider>().isTrigger = true;
            StartCoroutine(LerpSnowPosition(_snowMovementDuration, other.gameObject));
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Inventory inv = other.GetComponentInChildren<Inventory>();
            foreach (var item in inv.ItemList)
            {
                if (item.itemInformation.name == "red" && item.itemInformation.amount > 0)
                {
                    item.itemInformation.amount--;
                    transform.localScale += new Vector3(_flameGrowthFromWood, _flameGrowthFromWood, _flameGrowthFromWood);
                }
            }
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
