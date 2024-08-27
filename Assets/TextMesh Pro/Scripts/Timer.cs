using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _smoothDecreaseDuration;

    private Coroutine _changeCounter;
    private bool _counterRunning = false;
    private int _valueCounter = 0;

    private void Start()
    {
        _timerText.text = "0";
    }

    public void Counter()
    {
        _counterRunning = !_counterRunning;

        if (_counterRunning == false)
        {
            if (_changeCounter != null)
                StopCoroutine(Increase());
        }

        if (_counterRunning == true)
        {
            _changeCounter = StartCoroutine(Increase());
        }
    }

    private IEnumerator Increase()
    {
        int increaseCounter = 1;
        var delay = new WaitForSeconds(_smoothDecreaseDuration);

        while (_counterRunning == true)
        {
            _valueCounter += increaseCounter;
            Display(_valueCounter);
            yield return delay;
        }  
    }

    private void Display(float count)
    {
        _timerText.text = count.ToString();
    }
}
