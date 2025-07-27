using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Counter))]
public class TextViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private readonly string _defaultText = "0";

    void Awake()
    {
        Counter counter = GetComponent<Counter>();
        counter.OnValueChange += UpdateText;
        _text.text = _defaultText;
    }

    private void UpdateText(int value)
    {
        _text.text = value.ToString();
    }
}
