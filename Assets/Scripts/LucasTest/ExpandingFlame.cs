using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingFlame : MonoBehaviour
{
    List<GameObject> _alreadyDownSnowList = new List<GameObject>();

    [Header("Flame")]
    [SerializeField] float _flameDuration = 1f;
    [SerializeField] float _flameGrowthSizeMultiplier = 10f;

    [Header("Snow Movement")]
    [SerializeField] float _snowMovementDuration = 1f;
    [SerializeField] float _snowMovementOffset = 0.5f;

    [Header("Other")]
    [SerializeField] bool _doesSnowComeBackUp = false;

    Vector3 _snowHitTargetPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            StartCoroutine(LerpFlameScale(5, 10));

        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(LerpFlameScale(5, 1));
    }

    IEnumerator LerpSnowPosition(float duration, GameObject objectToMove)
    {
        Vector3 targetPosition;

        if (_alreadyDownSnowList.Contains(objectToMove))
        {
            targetPosition = objectToMove.transform.position + new Vector3(0, _snowMovementOffset, 0);
            _alreadyDownSnowList.Remove(objectToMove);
            Debug.Log("Snow is coming back up!");
        }
        else
        {
            targetPosition = objectToMove.transform.position + new Vector3(0, -_snowMovementOffset, 0);
            _alreadyDownSnowList.Add(objectToMove);
            Debug.Log("Snow is going down!");
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

    IEnumerator LerpFlameScale(float duration, float targetSize, bool isScalingDown = false)
    {
        float time = 0;
        float startSize = transform.localScale.x;
        while (time < duration)
        {
            transform.localScale = new Vector3(Mathf.Lerp(startSize, targetSize, time / duration), Mathf.Lerp(startSize, targetSize, time / duration), Mathf.Lerp(startSize, targetSize, time / duration));
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
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(LerpSnowPosition(_snowMovementDuration, other.gameObject));
    }
}
