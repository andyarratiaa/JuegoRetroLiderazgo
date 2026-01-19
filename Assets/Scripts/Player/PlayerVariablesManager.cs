using Unity.VisualScripting;
using UnityEngine;

public class PlayerVariablesManager : MonoBehaviour
{
    [SerializeField] public int playerHealth = 4;
    [SerializeField] public int playerMaxHealth = 4;

    [SerializeField] int coins;
    public bool isPlayerDead = false;

    void Start()
    {
        playerHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(1);
            Debug.Log(playerHealth);
        }
    }

    public void TakeDamage(int damageTaken)
    {
        playerHealth -= damageTaken;
        Debug.Log("Player health:" + playerHealth);
        if (playerHealth <= 0) 
        {
            
            isPlayerDead = true;
            GetComponent<PlayerController>().OnDead();
            GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            //morir
        }
    }
}
