using Unity.VisualScripting;
using UnityEngine;

public class NormalEnemy : EnemyBase
{
    Animator anim;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
        
        if (Mathf.Abs(Vector3.Distance(transform.position, player.gameObject.transform.position)) > 1.5f)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, player.gameObject.transform.position, enemySpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Iniciar Ataque
            Attack(player);
        }
    }
}
