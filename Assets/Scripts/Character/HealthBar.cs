using UnityEngine;
using UnityEngine.UI;

namespace Character
{
    public class HealthBar : MonoBehaviour
    {
        private Slider _slider;
        private Character _character;
        
        public void GetCurrentHealth(float currentHealth)
        {
            _slider.value = currentHealth;
        }

        public void SetMaxHealth(float value)
        {
            _slider.maxValue += value;
            _slider.value += value;
        }

        public void SetHealth()
        {
            _slider = GetComponent<Slider>();
            _character = GetComponentInParent<Character>();
            _slider.minValue = 0;
            _slider.maxValue = _character.GetMaxHealth();
            _slider.value = _slider.maxValue;
        }
    }
}
