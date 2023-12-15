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
        if (character.NbWoods > 0)
        {
            ExpandingFlame.Instance.StartLerpFlameScale(_woodExpansionFactor);
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
