using System.Collections;
using Blinders;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Bars
{
    [RequireComponent(typeof(Slider))]
    public sealed class HealthBar : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Slider _slider;
        private IHealth _health;
        private Coroutine _coroutine;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void OnDisable()
        {
            _health.Changed -= OnChanged;
            _health.Died -= OnDied;
        }

        private void Start()
        {
            SetStartValues(_health.MaxHealth);
        }

        public void Init(IHealth health)
        {
            _health = health;
            
            _health.Changed += OnChanged;
            _health.Died += OnDied;
        }

        private void OnDied()
        {
            if (_coroutine != null) 
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ChangeSliderValue(0));
        }

        private void SetStartValues(int maxValue)
        {
            _slider.maxValue = maxValue;
            _slider.value = maxValue;
        }
        
        private void OnChanged()
        {
            _slider.maxValue = _health.MaxHealth;
            
            if (_coroutine != null) 
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ChangeSliderValue(_health.CurrentHealth));
        }
        
        private IEnumerator ChangeSliderValue(int currentValue)
        {
            while (_slider.value != currentValue)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, currentValue, Time.deltaTime * _speed);

                yield return null;
            }
        }
    }
}