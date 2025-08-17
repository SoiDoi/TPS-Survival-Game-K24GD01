using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health: MonoBehaviour
{
    [SerializeField] private int _maxHealthPoint;

    public UnityEvent OnDead;
    public int MaxHealthPoint => _maxHealthPoint;
    public int HealthPoint => _healthPoint;
    
    private int _healthPoint;

    private void Start() => _healthPoint = _maxHealthPoint;

    public bool IsDead => _healthPoint <= 0;

    public void TakeDamage(int damage)
    {
        if (IsDead) { return; }

        _healthPoint -= damage;
        if (IsDead)
        {
            Die();
            StartCoroutine(Destroy()); // Optional: Destroy the game object after a delay
        }
    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    private void Die() => OnDead.Invoke();
}