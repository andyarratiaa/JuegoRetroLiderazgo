using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected int enemyHealth;
    [SerializeField] protected float enemySpeed;
    [SerializeField] protected int enemyDamage;

    [SerializeField] protected PlayerVariablesManager player;
    [SerializeField] protected GameObject player1;
    void Start()
    {
        
        player1 = GameObject.FindWithTag("Player");
        player = FindAnyObjectByType<PlayerVariablesManager>();
        if(player1 != null)
        {
            Debug.Log("Si");
        }
    }

   

    public void TakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void Attack(PlayerVariablesManager player)
    {
        player.TakeDamage(enemyDamage);
    }
   
}
