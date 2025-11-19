using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class NormalEnemy : EnemyBase
{
    Animator anim;
    Rigidbody rb;
    [SerializeField] Transform collisionDetector;
    public LayerMask groundLayer;

    RaycastHit hit; 
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //hit = Physics.Raycast(collisionDetector.position, Vector3.down, 10f, groundLayer);
        if (player.gameObject.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        } 

        else
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }

        if(hit.collider != false)
        {
            Debug.Log("Suelo");
        } 

        else
        {
            Debug.Log("Suelo no");
        }


        
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
