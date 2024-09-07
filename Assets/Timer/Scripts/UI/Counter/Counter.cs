using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _smoothDecreaseDuration;
    [SerializeField] private Button _button;

    public event Action<int> TextChanged;

    private Coroutine _changeCounter;
    private bool _counterRunning = false;
    private int _valueDisplay = 0;

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeToggle);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeToggle);
    }

    private void ChangeToggle()
    {
        _counterRunning = !_counterRunning;

        if (_counterRunning == true)
        {
            _changeCounter = StartCoroutine(Increase());
        }
        else
        {
            if (_changeCounter != null)
                StopCoroutine(_changeCounter);
        }
    }

    private IEnumerator Increase(int increaseCounter = 1)
    {
        var delay = new WaitForSeconds(_smoothDecreaseDuration);

        while (_counterRunning == true)
        {
            _valueDisplay += increaseCounter;
            TextChanged?.Invoke(_valueDisplay);
            yield return delay;
        }
    }
}
