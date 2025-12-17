using UnityEngine;

public class SmallEnemyDamage : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.CompareTag("Player"))
        {
            player.GetComponent<PlayerVariablesManager>().TakeDamage(damage);
            Debug.Log("Player hit");
        }
    }
}
