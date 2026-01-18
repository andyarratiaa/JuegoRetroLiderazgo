using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float projectileSpeed;
    [SerializeField] int projectileDamage;
    [SerializeField] float projectileSpread;
    private GameObject player;
    [SerializeField] GameObject smallEnemy;
    [SerializeField] Sprite brokenEgg;
    SpriteRenderer spriteRenderer;

    bool fade = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = new Vector3(Random.Range(player.transform.position.x - projectileSpread, player.transform.position.x + projectileSpread), player.transform.position.y, 0) - transform.position;
        rb.linearVelocity = new Vector2 (direction.x, direction.y).normalized * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(fade)
        {
        Color c = spriteRenderer.color;
        c.a = Mathf.Lerp(c.a, 0f, 3f * Time.deltaTime);
        spriteRenderer.color = c;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            if(Random.Range(0, 4) == 3)
            {
                Instantiate(smallEnemy, new Vector3(transform.position.x, transform.position.y +0.65f, transform.position.z), Quaternion.identity);
            }
            rb.linearVelocity = new Vector2 (0f, 0f);
            fade = true;
            StartCoroutine(HitGround());
        }

        if (collision.CompareTag("Player"))
        {
            player.GetComponent<PlayerVariablesManager>().TakeDamage(projectileDamage);
            Debug.Log("Player hit");
            Destroy(gameObject);
        }
    }

    IEnumerator HitGround()
    {
        spriteRenderer.sprite = brokenEgg;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
