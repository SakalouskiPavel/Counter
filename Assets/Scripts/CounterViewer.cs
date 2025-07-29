using TMPro;
using UnityEngine;

public class CounterViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private readonly string _defaultText = "0";

    private void Awake()
    {
        _counter.ValueChanged += UpdateText;
        _text.text = _defaultText;
    }

    private void OnDestroy()
    {
        _counter.ValueChanged -= UpdateText;
    }

    private void UpdateText(int value)
    {
        _text.text = value.ToString();
    }
}
