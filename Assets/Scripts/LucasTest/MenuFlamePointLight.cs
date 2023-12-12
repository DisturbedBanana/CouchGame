
using System.Collections;
using UnityEngine;


public class MenuFlamePointLight : MonoBehaviour
{
    [SerializeField] private float _minIntensity = 1f; 
    [SerializeField] private float _maxIntensity = 3f; 
    [SerializeField] private float _fluctuationSpeed = 1f;
    [SerializeField] private float _fluctuationTimer = 1f;
    
    private Light _myLight;
    private bool _shouldFluctuate = true;
    private float _targetIntensity;

    private void Start()
    {
        _myLight = GetComponent<Light>();
    }

    private void Update()
    {
        if (_shouldFluctuate)
        {
            _targetIntensity = Random.Range(_minIntensity, _maxIntensity);
            _shouldFluctuate = false;
            StartCoroutine(FluctuateTimer());
        }
        _myLight.intensity = Mathf.Lerp(_myLight.intensity, _targetIntensity, Time.deltaTime * _fluctuationSpeed);
    }

    private IEnumerator FluctuateTimer()
    {
        yield return new WaitForSeconds(_fluctuationTimer);
        _shouldFluctuate = true;
    }
}
