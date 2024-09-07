using UnityEngine;
using TMPro;


[RequireComponent(typeof(TextMeshProUGUI))]
public class View : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textDisplay;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        _textDisplay.text = "0";
    }

    private void OnEnable()
    {
        _counter.TextChanged += Display;
    }

    private void OnDisable()
    {
        _counter.TextChanged -= Display;
    }

    private void Display(int count)
    {
        _textDisplay.text = count.ToString();
    }
}
