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
        
            if (veloPowerup)
            {
                hasPowerup = false;
                LoseVeloPowerup();
            } else if (pteroPowerup)
            {
                hasPowerup = false;
                LosePteraPowerup();
            } else if (tricePowerup)
            {
                hasPowerup = false;
                LoseTricePowerup();
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

    public void GetPteraPowerup ()
    {
        hasPowerup = true;
        LoseTricePowerup();
        LoseVeloPowerup();
        pteroPowerup = true;
        anim.SetBool("pteroPowerup", true);
        anim.SetTrigger("ptero");
    }

    public void GetTricePowerup()
    {
        hasPowerup = true;
        LosePteraPowerup();
        LoseVeloPowerup();
        tricePowerup = true;
        anim.SetBool("tricePowerup", true);
        anim.SetTrigger("trice");
    }

    public void GetVeloPowerup()
    {
        hasPowerup = true;
        LoseTricePowerup();
        LosePteraPowerup();
        veloPowerup = true;
        anim.SetBool("veloPowerup", true);
        anim.SetTrigger("velo");
    }

    public void LosePteraPowerup()
    {
        hasPowerup = false;
        pteroPowerup = false;
        anim.SetBool("pteroPowerup", false);
    }

    public void LoseTricePowerup()
    {
        hasPowerup = false;
        tricePowerup = false;
        anim.SetBool("tricePowerup", false);
        
    }

    public void LoseVeloPowerup()
    {
        hasPowerup = false;
        veloPowerup = false;
        anim.SetBool("veloPowerup", false);
        
    }
}
