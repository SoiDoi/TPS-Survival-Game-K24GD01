using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;   // Reference tới player / Reference to the player
    [SerializeField] private float speed = 3f;   // Tốc độ di chuyển / Movement speed of the enemy
    [SerializeField] private float stopDistance = 1.5f; // Khoảng cách dừng, tránh enemy dính vào player


    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Tìm player trong scene / Find the player in the scene
    }
    private void Update()
    {
        if (_playerTransform == null) return;

        // Tính vector hướng đến player
        Vector3 direction = _playerTransform.position - transform.position;
        direction.y = 0; // Giữ enemy không bay lên/xuống / Keep the enemy on the same horizontal plane

        float distance = direction.magnitude;

        // Nếu còn xa hơn khoảng cách dừng thì di chuyển / If the distance to the player is greater than the stop distance, move towards the player
        if (distance > stopDistance)
        {
            // Chuẩn hóa vector hướng
            direction.Normalize();

            // Di chuyển enemy
            transform.position += direction * speed * Time.deltaTime;

            // Xoay mặt về phía player / Rotate the enemy to face the player
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
