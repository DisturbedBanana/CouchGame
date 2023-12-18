using UnityEngine;

public class WoodZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Character character = other.GetComponentInChildren<Character>();
            if (character == null) return;

            character.IsInsideWoodZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Character character = other.GetComponentInChildren<Character>();
            if (character == null) return;

            character.IsInsideWoodZone = false;
        }
    }
}
