using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[RequireComponent(typeof(Button))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _smoothDecreaseDuration;
    [SerializeField] private Button _buttonSwitch;

    public event Action<int> TextChanged;

    private Coroutine _turnOnOff;
    private bool _isRunning = false;
    private int _valueDisplay = 0;

    private void OnEnable()
    {
        _buttonSwitch.onClick.AddListener(ChangeToggle);
    }

    private void OnDisable()
    {
        _buttonSwitch.onClick.RemoveListener(ChangeToggle);
    }

    private void ChangeToggle()
    {
        _isRunning = !_isRunning;

        if (_isRunning == true)
        {
            _turnOnOff = StartCoroutine(Increase());
        }
        else
        {
            if (_turnOnOff != null)
                StopCoroutine(_turnOnOff);
        }
    }

    private IEnumerator Increase(int increaseCounter = 1)
    {
        var delay = new WaitForSeconds(_smoothDecreaseDuration);

        while (_isRunning == true)
        {
            _valueDisplay += increaseCounter;
            TextChanged?.Invoke(_valueDisplay);
            yield return delay;
        }
    }
}
