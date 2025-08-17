using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _healthImage;


    public void HealthUpdate()
    {
        if (_health == null || _healthImage == null) return;
        float healthPercentage = (float)_health.HealthPoint / _health.MaxHealthPoint;
        if (healthPercentage < 0f) healthPercentage = 0f; // Ensure the health percentage does not go below 0
        _healthImage.rectTransform.localScale = new Vector3 (healthPercentage,1f,1f); // Ensure the health bar does not go below 0

        if (_health.IsDead)
        {
            _healthImage.fillAmount = 0f; // Ensure the health bar is empty when dead
        }
    }

}
