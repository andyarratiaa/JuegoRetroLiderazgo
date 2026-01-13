using Unity.VisualScripting;
using UnityEngine;

public class PlayerVariablesManager : MonoBehaviour
{
    [SerializeField] int playerHealh;

    [SerializeField] int coins;
    public bool isPlayerDead = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(1);
            Debug.Log(playerHealh);
        }
    }

    public void TakeDamage(int damageTaken)
    {
        playerHealh -= damageTaken;
        Debug.Log("Player health:" + playerHealh);
        if (playerHealh <= 0) 
        {
            
            isPlayerDead = true;
            GetComponent<PlayerController>().OnDead();
            GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            //morir
        }
    }
}
