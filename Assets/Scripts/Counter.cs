using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private InputReader _inputReader;

    private WaitForSeconds _wait;
    private Coroutine _coroutine;
    private int _currentValue;

    public event UnityAction<int> ValueChanged;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
        _currentValue = 0;
        _inputReader.LeftMouseButtonDown += ToggleCoroutine;
    }

    private IEnumerator Count()
    {
        while (enabled)
        {
            _currentValue++;
            ValueChanged?.Invoke(_currentValue);
            yield return _wait;            
        }
    }

    private void ToggleCoroutine()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Count());
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;           
        }
    }
}
