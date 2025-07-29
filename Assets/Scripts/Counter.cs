using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    private WaitForSeconds _wait;
    private bool _isWork = false;
    private Coroutine _coroutine;
    private int _currentValue;

    public event UnityAction<int> ValueChanged;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
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
        while (enabled)
        {
            _currentValue++;
            ValueChanged?.Invoke(_currentValue);
            yield return _wait;            
        }
    }
}
