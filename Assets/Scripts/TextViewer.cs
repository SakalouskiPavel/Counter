using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private readonly string _defaultText = "0";

    private void Awake()
    {
        if (_counter != null)
        {
            _counter.ValueChanged += UpdateText;
        }

        _text.text = _defaultText;
    }

    private void UpdateText(int value)
    {
        _text.text = value.ToString();
    }

    private void OnDisable()
    {
        if (_counter != null)
        {
            _counter.ValueChanged -= UpdateText;
        }
    }
}
