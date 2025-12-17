using UnityEngine;

public class FlyingEnemy : EnemyBase
{
    public Transform[] patrollWaypoints;
    int targetPoint;
    public GameObject projectile;
    [SerializeField] float shootingCooldown;

    GameObject player;

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPoint = 0;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Mathf.Abs(Vector3.Distance(transform.position, player.gameObject.transform.position)) < 10f)
        {
            if (timer > shootingCooldown) 
            {
                timer = 0f;
                Shoot();
            }

        }
    }

    private void FixedUpdate()
    {
        if (transform.position == patrollWaypoints[targetPoint].position)
        {
            increaseTargetInt();
        }
        transform.position = Vector2.MoveTowards(transform.position, patrollWaypoints[targetPoint].position, enemySpeed);

        
    }

    void increaseTargetInt()
    {
        targetPoint++;
        if (targetPoint >= patrollWaypoints.Length)
        {
            targetPoint = 0;
        }
    }

    public void Shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
