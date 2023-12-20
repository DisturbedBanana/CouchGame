using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class DropInteraction : MonoBehaviour
{
    public static DropInteraction instance;

    [SerializeField] private int _woodExpansionFactor = 5;
    [SerializeField] private int _charcoalExpansionFactor = 10;
    private bool _coalWasDropped;

    private Character character = null;

    private void Awake()
    {
        character = GetComponent<Character>();
        instance = this;
    }

    public void OnDropWood(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (character.IsInsideWoodZone)
            {
                DropMaterialInsideFlame(_woodExpansionFactor);
                RemoveOneWoodFromInventory(character);
                return;
            }

            //CODE POUR DROP PAR TERRE
            if (character.NbWoods >= 1)
            {
                RemoveOneWoodFromInventory(character);
                Instantiate(PickUp.instance._woodItem, new Vector3(character.transform.position.x + Random.Range(0f, 5f), character.transform.position.y, character.transform.position.z + Random.Range(0f, 5f)), Quaternion.identity);
            }
        }
    }

    public void OnDropCoal(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (character.IsInsideWoodZone)
            {
                _coalWasDropped = true;
                DropMaterialInsideFlame(_charcoalExpansionFactor);
                RemoveOneCharcoalFromInventory(character);
                return;
            }

            //CODE POUR DROP PAR TERRE
            if (character.NbCharcoals >= 1)
            {
                RemoveOneCharcoalFromInventory(character);
                Instantiate(PickUp.instance._coalItem, new Vector3(character.transform.position.x + Random.Range(0f, 5f), character.transform.position.y, character.transform.position.z + Random.Range(0f, 5f)), Quaternion.identity);
            }
        }
    }

    public void OnDropIron(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //CODE POUR DROP PAR TERRE
            if (character.NbIrons >= 1)
            {
                RemoveOneIronFromInventory(character);
                Instantiate(PickUp.instance._ironItem, new Vector3(character.transform.position.x + Random.Range(0f, 5f), character.transform.position.y, character.transform.position.z + Random.Range(0f, 5f)), Quaternion.identity);
            }
        }
    }

    private void DropMaterialInsideFlame(int flameScaleUpFactor)
    {
        if (!_coalWasDropped)
        {
            if (character.NbWoods == 0)
            {
                return;
                Debug.Log("Not enough wood");
            }

            ExpandingFlame.Instance.StartLerpFlameScale(flameScaleUpFactor);
            _coalWasDropped = false;
        }
        else
        {
            if (character.NbCharcoals == 0)
            {
                return;
                Debug.Log("Not enough wood");
            }

            ExpandingFlame.Instance.StartLerpFlameScale(flameScaleUpFactor);
        }
    }

    public void RemoveOneWoodFromInventory(Character player)
    {
        if (player.NbWoods == 0)
        {
            return;
            Debug.Log("Not enough wood");
        }

        string woodValue;

        if (player.PlayerId == 1)
        {
            woodValue = UIManager.instance._lumberjackWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            intWoodValue--;
            UIManager.instance._lumberjackWoodValue.text = intWoodValue.ToString();
            player.NbWoods--;
        }
        else if (player.PlayerId == 2)
        {
            woodValue = UIManager.instance._scoutWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            intWoodValue--;
            UIManager.instance._scoutWoodValue.text = intWoodValue.ToString();
            player.NbWoods--;
        }
        else if (player.PlayerId == 3)
        {
            woodValue = UIManager.instance._shamanWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            intWoodValue--;
            UIManager.instance._shamanWoodValue.text = intWoodValue.ToString();
            player.NbWoods--;
        }
        else if (player.PlayerId == 4)
        {
            woodValue = UIManager.instance._engineerWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            intWoodValue--;
            UIManager.instance._engineerWoodValue.text = intWoodValue.ToString();
            player.NbWoods--;
        }
    }

    public void RemoveOneCharcoalFromInventory(Character player)
    {
        if (player.NbCharcoals == 0)
        {
            return;
            Debug.Log("Not enough wood");
        }

        string coalValue;

        if (player.PlayerId == 1)
        {
            coalValue = UIManager.instance._lumberjackCoalValue.text;
            int intCoalValue = int.Parse(coalValue);

            intCoalValue--;
            UIManager.instance._lumberjackCoalValue.text = intCoalValue.ToString();
            player.NbCharcoals--;
        }
        else if (player.PlayerId == 2)
        {
            coalValue = UIManager.instance._scoutCoalValue.text;
            int intCoalValue = int.Parse(coalValue);

            intCoalValue--;
            UIManager.instance._scoutCoalValue.text = intCoalValue.ToString();
            player.NbCharcoals--;
        }
        else if (player.PlayerId == 3)
        {
            coalValue = UIManager.instance._shamanCoalValue.text;
            int intCoalValue = int.Parse(coalValue);

            intCoalValue--;
            UIManager.instance._shamanCoalValue.text = intCoalValue.ToString();
            player.NbCharcoals--;
        }
        else if (player.PlayerId == 4)
        {
            coalValue = UIManager.instance._engineerCoalValue.text;
            int intCoalValue = int.Parse(coalValue);

            intCoalValue--;
            UIManager.instance._engineerCoalValue.text = intCoalValue.ToString();
            player.NbCharcoals--;
        }
    }

    public void RemoveOneIronFromInventory(Character player)
    {
        if (player.NbIrons == 0)
        {
            return;
            Debug.Log("Not enough wood");
        }

        string ironValue;

        if (player.PlayerId == 1)
        {
            ironValue = UIManager.instance._lumberjackIronValue.text;
            int intIronValue = int.Parse(ironValue);

            intIronValue--;
            UIManager.instance._lumberjackIronValue.text = intIronValue.ToString();
            player.NbIrons--;
        }
        else if (player.PlayerId == 2)
        {
            ironValue = UIManager.instance._scoutIronValue.text;
            int intIronValue = int.Parse(ironValue);

            intIronValue--;
            UIManager.instance._scoutIronValue.text = intIronValue.ToString();
            player.NbIrons--;
        }
        else if (player.PlayerId == 3)
        {
            ironValue = UIManager.instance._shamanIronValue.text;
            int intIronValue = int.Parse(ironValue);

            intIronValue--;
            UIManager.instance._shamanIronValue.text = intIronValue.ToString();
            player.NbIrons--;
        }
        else if (player.PlayerId == 4)
        {
            ironValue = UIManager.instance._engineerIronValue.text;
            int intIronValue = int.Parse(ironValue);

            intIronValue--;
            UIManager.instance._engineerIronValue.text = intIronValue.ToString();
            player.NbIrons--;
        }
    }
}
