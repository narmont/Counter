using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[RequireComponent(typeof(Button))]
public class Counter : MonoBehaviour
{
    [SerializeField] private float _smoothDecreaseDuration;
    [SerializeField] private Button _buttonSwitch;

    private Coroutine _coroutine;
    private int _value = 0;

    public event Action<int> ValueChangeDisplay;

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
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        else
        {
            _coroutine = StartCoroutine(Increase());
        }
    }

    private IEnumerator Increase(int increaseCounter = 1)
    {
        var delay = new WaitForSeconds(_smoothDecreaseDuration);

        while (true)
        {
            _value += increaseCounter;
            ValueChangeDisplay?.Invoke(_value);
            yield return delay;
        }
    }
}
