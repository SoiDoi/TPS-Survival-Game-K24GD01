using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyDie : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 10; // Điểm khi tiêu diệt enemy / Score value for killing the enemy

    public void Die()
    {
        // Gọi hàm tăng điểm trong GameManager / Call the score increase function in GameManager
        GameManager.Instance.GetScore(_scoreValue);
    }
}
