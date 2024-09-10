using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[RequireComponent(typeof(Button))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _smoothDecreaseDuration;
    [SerializeField] private Button _buttonSwitch;

    private Coroutine _turnOnOff;
    private int _valueDisplay = 0;

    public event Action<int> ValueChangedDisplay;

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
        if (_turnOnOff != null)
        {
            StopCoroutine(_turnOnOff);
            _turnOnOff = null;
        }
        else
        {
            _turnOnOff = StartCoroutine(Increase());
        }
    }

    private IEnumerator Increase(int increaseCounter = 1)
    {
        var delay = new WaitForSeconds(_smoothDecreaseDuration);

        while (true)
        {
            _valueDisplay += increaseCounter;
            ValueChangedDisplay?.Invoke(_valueDisplay);
            yield return delay;
        }
    }
}
