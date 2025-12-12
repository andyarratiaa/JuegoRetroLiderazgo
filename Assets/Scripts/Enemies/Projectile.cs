using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float projectileSpeed;
    [SerializeField] int projectileDamage;
    [SerializeField] float projectileSpread;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = new Vector3(Random.Range(player.transform.position.x - projectileSpread, player.transform.position.x + projectileSpread), player.transform.position.y, 0) - transform.position;
        rb.linearVelocity = new Vector2 (direction.x, direction.y).normalized * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            player.GetComponent<PlayerVariablesManager>().TakeDamage(projectileDamage);
            Debug.Log("Player hit");
            Destroy(gameObject);
        }
    }
}
