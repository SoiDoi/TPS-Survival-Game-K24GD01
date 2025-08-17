using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int totalHealth = 100; // Máu tổng của người chơi / Total health of the player
    [SerializeField] private int currentHealth; // Máu hiện tại của người chơi / Current health of the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = totalHealth; // Khởi tạo máu hiện tại bằng máu tổng / Initialize current health with total health
    }

   public void GetDamage(int damage)
    {
        if (currentHealth < damage)
        {
            currentHealth = 0; // Nếu máu hiện tại nhỏ hơn sát thương, đặt máu hiện tại về 0 / If current health is less than damage, set current health to 0
            Die();
        }
        else
        {
            currentHealth -= damage; // Giảm máu hiện tại theo sát thương / Reduce current health by damage
        }
    }

    private void Die()
    {

    }
}
