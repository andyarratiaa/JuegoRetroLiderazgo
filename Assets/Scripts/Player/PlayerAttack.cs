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
            //other.gameObject.GetComponent<EnemtHealth>().TakeDamage(attackDamage);
        }
    }
}
