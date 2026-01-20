using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class NormalEnemy : EnemyBase
{
    
    Rigidbody2D rb;
    [SerializeField] Transform collisionDetector;
    public LayerMask groundlayers;

    public GameObject projectile;

    [SerializeField] Transform groundCheck;
    RaycastHit2D hitWall;
    RaycastHit2D hitFall;
    bool isFacingRight;
    [SerializeField] Transform firingPoint;

    RaycastHit hit;

    GameObject player;

    bool canShoot;
    public Animator anim;

    [SerializeField] float shootingCooldown;
    private float timer;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        hitFall = Physics2D.Raycast(groundCheck.position, -transform.up, 0.6f, groundlayers);
        hitWall = Physics2D.Raycast(groundCheck.position, transform.right, 0.3f, groundlayers);

        timer += Time.deltaTime;
        if (Mathf.Abs(Vector3.Distance(transform.position, player.gameObject.transform.position)) < 10f)
        {
            anim.SetBool("isMoving", false);
            float xPos = player.transform.position.x - transform.position.x;
            if(xPos > 0)
            {
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
            } else
            {
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
            }
            canShoot = true;
            if (timer > shootingCooldown)
            {
                timer = 0f;
                Shoot();
            }

        } else
        {
            canShoot= false;
        }
    }

    private void FixedUpdate()
    {
        if (!canShoot) 
        {
            anim.SetBool("isMoving", true);
            if (hitFall.collider != false)
            {
                if (isFacingRight)
                {
                    rb.linearVelocity = new Vector2(enemySpeed, rb.linearVelocityY);
                }
                else
                {
                    rb.linearVelocity = new Vector2(-enemySpeed, rb.linearVelocityY);
                }
            }
            else
            {
                isFacingRight = !isFacingRight;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            if (hitWall.collider != false)
            {
                isFacingRight = !isFacingRight;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }


    public void Shoot()
    {
        anim.SetTrigger("Shoot");
        //Instantiate(projectile, firingPoint.transform.position, Quaternion.identity);
    }
    
}
