using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingFlame : MonoBehaviour
{
    [Header("Snow Movement")]
    [SerializeField] private float _snowMovementDuration = 1f;
    [SerializeField] private float _snowMovementOffset = 0.5f;

    Vector3 _snowHitTargetPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            StartCoroutine(ExpandFlameCoroutine());
    }

    private IEnumerator ExpandFlameCoroutine()
    {
        yield return new WaitForSeconds(0.05f);
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        if (transform.localScale.x < 10)
        {
            StartCoroutine(ExpandFlameCoroutine());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Snow"))
        {
            _snowHitTargetPosition = other.transform.position + new Vector3 (0, _snowMovementOffset, 0);
            other.GetComponent<BoxCollider>().isTrigger = true;
            StartCoroutine(LerpSnowPosition(_snowHitTargetPosition, _snowMovementDuration, other.gameObject));
            Debug.Log("Snow hit!");
        }
    }

    IEnumerator LerpSnowPosition(Vector3 targetPosition, float duration, GameObject objectToMove)
    {
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
}
