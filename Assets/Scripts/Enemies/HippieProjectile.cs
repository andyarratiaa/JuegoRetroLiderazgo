using System.Collections;
using UnityEngine;

public class HippieProjectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    Rigidbody2D rb;
    GameObject player;
    [SerializeField] int projectileDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        if (player.transform.position.x > transform.position.x)
        {
            rb.linearVelocity = Vector2.right * projectileSpeed;
        } else
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            rb.linearVelocity = Vector2.left * projectileSpeed;
        }
        
        StartCoroutine(DespawnBullet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DespawnBullet()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
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
