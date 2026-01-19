using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerVariablesManager : MonoBehaviour
{
    [SerializeField] public int playerHealth = 4;
    [SerializeField] public int playerMaxHealth = 4;

    [SerializeField] int coins;
    public bool isPlayerDead = false;
    public static event Action OnPlayerDamaged;

    public bool hasPowerup;
    public bool tricePowerup, veloPowerup, pteroPowerup;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
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
        if (hasPowerup)
        {
            if (veloPowerup)
            {
                veloPowerup = false;
                anim.SetBool("veloPowerup", false);
            } else if (pteroPowerup)
            {
                pteroPowerup = false;
                anim.SetBool("pteroPowerup", false);
            } else if (tricePowerup)
            {
                tricePowerup = false;
                anim.SetBool("tricePowerup", false);
            }
        }
        playerHealth -= damageTaken;
        OnPlayerDamaged?.Invoke();
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
