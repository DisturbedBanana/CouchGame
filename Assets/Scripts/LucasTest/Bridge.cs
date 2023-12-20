using System;
using System.Collections;
using System.Collections.Generic;
using FFO.Inventory;
using FFO.Inventory.Storage;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private GameObject _objectToActivate;
    private BridgeInteractable _currentBridgeInteractable;

    [Header("Resource Costs")]
    [SerializeField] private int woodCost;
    [SerializeField] private int metalCost;
    private int woodAdded, metalAdded;

    private void Start()
    {
        _objectToActivate.SetActive(false);
    }

    public void ActivateBridge(Character character)
    {
        // Toutes les ressources ajoutées ?
        print("Bois : " + woodAdded + "/" + woodCost + " | Fer : " + metalAdded + "/" + metalCost);
        if(woodAdded >= woodCost && metalAdded >= metalCost) 
        {
            print("Assez de ressources pour réparer...");
            // On vérifie que c'est l'Ingénieure
            if(character.PlayerId == 4)
            {
                print("L'ingénieure peut réparer !");
                _objectToActivate.SetActive(true);
            }
            else print("Cette classe ne peut pas réparer le pont !");
        }
        // Pas assez de ressources ajoutées -> On ajoute celles dans l'inventaire
        else
        {
            print("Pas assez de ressources pour réparer le pont. On cherche...");
            PlayerInventory inventory = character.GetComponentInChildren<PlayerInventory>();
            List<SlotController> slots = inventory.storageController.Slots;

            // Tant qu'on a du bois et qu'il faut du bois
            while(woodAdded < woodCost && inventory.DoesPlayerHaveEnoughItems("Woo_NONE", 1))
            {
                // On cherche un slot avec du bois
                foreach (SlotController slot in slots)
                {
                    if(slot.DataItem != null && slot.DataItem.ID == "Woo_NONE")
                    {
                        slot.OnRemove();
                        woodAdded++;
                        print("Bois ajouté ! ("+ woodAdded + "/" + woodCost + ")");
                        break;
                    }
                }
            }

            // Même chose avec le fer
            while(metalAdded < metalCost && inventory.DoesPlayerHaveEnoughItems("Met_NONE", 1))
            {
                foreach (SlotController slot in slots)
                {
                    if(slot.DataItem.ID == "Met_NONE")
                    {
                        slot.OnRemove();
                        metalAdded++;
                        print("Fer ajouté ! ("+ metalAdded + "/" + metalCost + ")");
                        break;
                    }
                }
            }
            print("Pas d'autres ressources dans l'inventaire à ajouter !");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BridgeInteractable _currentBridgeInteractable = other.GetComponent<BridgeInteractable>();

            if (_currentBridgeInteractable != null)
            {
                _currentBridgeInteractable.CurrentBridge = this;
                _currentBridgeInteractable.CanActivateBridge = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BridgeInteractable bridgeInteractable = other.GetComponent<BridgeInteractable>();
        if (bridgeInteractable == _currentBridgeInteractable)
        {
            _currentBridgeInteractable.CurrentBridge = null;
            _currentBridgeInteractable.CanActivateBridge = false;
        }
    }
}
