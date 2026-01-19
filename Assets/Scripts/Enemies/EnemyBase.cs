using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected int enemyHealth;
    [SerializeField] protected float enemySpeed;
    [SerializeField] protected int enemyDamage;
    [SerializeField] protected AudioClip DieClip;

    //[SerializeField] protected PlayerVariablesManager player;
    //[SerializeField] protected GameObject player1;

    
    void Start()
    {
        //player1 = GameObject.FindWithTag("Player");
        //player = FindAnyObjectByType<PlayerVariablesManager>();
        //if(player1 != null)
        //{
        //    Debug.Log("Si");
        //}
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
        Debug.Log("Llega");
        SFXManager.instance.PlaySoundFX(transform, DieClip, 1, 1);
        Destroy(gameObject);
    }

    public void Attack(PlayerVariablesManager player)
    {
        player.TakeDamage(enemyDamage);
    }
   
}
