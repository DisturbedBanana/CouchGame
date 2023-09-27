using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatBar : MonoBehaviour
{
    Slider _slider;
    [SerializeField] Image _sliderImage;

    float _shrinkTimer = 0;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = 0;
        _slider.maxValue = 1;
        _slider.value = 1;
        _sliderImage.color = Color.red;
    }

    private void Update()
    {
        _shrinkTimer += Time.deltaTime;

        if (_shrinkTimer >= 1)
        {
            _shrinkTimer = 0;
            _slider.value -= 0.03f;
            _sliderImage.color = Color.Lerp(Color.cyan, Color.red, _slider.value);
            //Color.Lerp(Color.red, Color.blue, _slider.value);
        }
    }
}
