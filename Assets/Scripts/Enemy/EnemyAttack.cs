using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackCooldown = 1.5f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private Health _enemyHealth; // Tham chiếu đến Health của enemy / Reference to the enemy's Health component

    private Transform playerTransform;
    private float lastAttackTime=0; // thời gian kể từ lần tấn công cuối cùng / time since last attack


    private void Start()
    {
        try
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        catch
        {
            Debug.Log("Player not found! Make sure the player has the 'Player' tag assigned.");
            return;
        }


        if (playerTransform == null)
        {
            Debug.LogError("Player not found in the scene!");
        }
    }
    private void Update()
    {
        if (_enemyHealth == null || _enemyHealth.IsDead) return; // Kiểm tra nếu enemy đã chết / Check if the enemy is dead
        if (playerTransform == null) return;
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            AttackPlayer();
            lastAttackTime = Time.time; // cập nhật thời gian tấn công cuối cùng / update last attack time
        }
    }
    private void AttackPlayer()
    {
        Collider[] hitPlayers = Physics.OverlapSphere(transform.position, attackRange, playerLayer);
        foreach (var hitPlayer in hitPlayers)
        {
            Health playerHealth = hitPlayer.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Player attacked for " + attackDamage + " damage.");
            }
        }
    }
}
