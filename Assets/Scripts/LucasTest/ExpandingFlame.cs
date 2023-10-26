using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingFlame : MonoBehaviour
{
    List<GameObject> _alreadyDownSnowList = new List<GameObject>();
    float _shrinkTimer = 0;

    [Header("Flame")]
    [SerializeField] float _shrinkTickDelay = 1f;
    [SerializeField] float _flameGrowthFromWood = 2f;

    [Header("Snow Movement")]
    [SerializeField] float _snowMovementDuration = 1f;
    [SerializeField] float _snowMovementOffset = 0.5f;

    [Header("Other")]
    [SerializeField] bool _doesSnowComeBackUp = false;

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            StartCoroutine(LerpFlameScale(5, 10));

        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(LerpFlameScale(5, 1));

        _shrinkTimer += Time.deltaTime;
        if (_shrinkTimer >= _shrinkTickDelay)
        {
            _shrinkTimer = 0;
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 5);
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

    //used for debugging purposes
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
        else if (other.gameObject.CompareTag("Player"))
        {
            
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
