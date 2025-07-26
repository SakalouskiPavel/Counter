using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay = 0.5f;

    private WaitForSeconds _wait;
    private bool _isWork = false;
    private Coroutine _coroutine;
    private int _currentValue;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
        _text.text = "0";
        _currentValue = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isWork)
            {
                StopCoroutine(_coroutine);
                _isWork = false;
            }
            else
            {
                _coroutine = StartCoroutine(Count());
                _isWork = true;
            }
        }
    }

    private IEnumerator Count()
    {
        while (_currentValue < int.MaxValue)
        {
            _text.text = _currentValue.ToString();
            yield return _wait;
            _currentValue++;
        }
    }
}
