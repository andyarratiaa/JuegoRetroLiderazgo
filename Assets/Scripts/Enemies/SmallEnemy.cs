using UnityEngine;

public class SmallEnemy : EnemyBase
{
    Rigidbody2D rb;
    public LayerMask groundlayers;

    [SerializeField] Transform groundCheck;
    RaycastHit2D hitWall;
    RaycastHit2D hitFall;
    bool isFacingRight;

    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        if (player.transform.position.x >= transform.position.x)
        {
            isFacingRight = true;
            transform.localScale = Vector3.one;
        } 
        else
        {
            isFacingRight = false;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        hitFall = Physics2D.Raycast(groundCheck.position, -transform.up, 0.6f, groundlayers);
        hitWall = Physics2D.Raycast(groundCheck.position, transform.right, 0.2f, groundlayers);
    }

    private void FixedUpdate()
    {
        if(hitFall.collider != false)
        {
            if (isFacingRight)
            {
                rb.linearVelocity = new Vector2(-enemySpeed, rb.linearVelocityY);
            } 
            else
            {
                rb.linearVelocity = new Vector2(enemySpeed, rb.linearVelocityY);   
            }
        } 
        else
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        if(hitWall.collider != false) 
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
