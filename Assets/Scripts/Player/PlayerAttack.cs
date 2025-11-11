using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    [SerializeField] int attackDamage;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Registered");
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }
}
