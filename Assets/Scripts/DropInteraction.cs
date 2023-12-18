using UnityEngine;

public class DropInteraction : MonoBehaviour
{
    [SerializeField] private int _woodExpansionFactor = 5;
    [SerializeField] private int _charcoalExpansionFactor = 10;

    private Character character = null;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    public void OnDropWood()
    {
        if (character.IsInsideWoodZone)
        {
            _DropWoodInsideFlame();
            return;
        }

        _DropWoodOnGround();
    }

    private void _DropWoodInsideFlame()
    {
        if (character.NbWoods == 0)
        {
            return;
            Debug.Log("Not enough wood");
        }

        ExpandingFlame.Instance.StartLerpFlameScale(_woodExpansionFactor);

        string woodValue;

        if (character.PlayerId == 1)
        {
            woodValue = UIManager.instance._lumberjackWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            intWoodValue--;
            UIManager.instance._lumberjackWoodValue.text = intWoodValue.ToString();
            character.NbWoods--;
        }
        else if (character.PlayerId == 2)
        {
            woodValue = UIManager.instance._scoutWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            intWoodValue--;
            UIManager.instance._scoutWoodValue.text = intWoodValue.ToString();
            character.NbWoods--;
        }
        else if (character.PlayerId == 3)
        {
            woodValue = UIManager.instance._shamanWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            intWoodValue--;
            UIManager.instance._shamanWoodValue.text = intWoodValue.ToString();
            character.NbWoods--;
        }
        else if (character.PlayerId == 4)
        {
            woodValue = UIManager.instance._engineerWoodValue.text;
            int intWoodValue = int.Parse(woodValue);

            intWoodValue--;
            UIManager.instance._engineerWoodValue.text = intWoodValue.ToString();
            character.NbWoods--;
        }
    }



    private void _DropWoodOnGround()
    {

    }

    public void OnDropIron()
    {

    }

    public void OnDropCharcoal()
    {
        int flameScaleAmount = 0;
        flameScaleAmount += _woodExpansionFactor * character.NbWoods;
        flameScaleAmount += _charcoalExpansionFactor * character.NbCharcoals;
        if (flameScaleAmount > 0)
        {
            ExpandingFlame.Instance.StartLerpFlameScale(flameScaleAmount);
        }
        character.NbWoods = 0;
        character.NbCharcoals = 0;
    }
}
