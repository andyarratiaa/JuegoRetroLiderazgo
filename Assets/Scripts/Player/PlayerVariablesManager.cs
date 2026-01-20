using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVariablesManager : MonoBehaviour
{
    [SerializeField] public int playerHealth = 4;
    [SerializeField] public int playerMaxHealth = 4;

    [SerializeField] int coins;
    public bool isPlayerDead = false;
    public static event Action OnPlayerDamaged;
    private float DeathTime = 0;

    public bool hasPowerup;
    public bool tricePowerup, veloPowerup, pteroPowerup;
    Animator anim;
    [SerializeField] SpriteRenderer spritePlayer;
    [SerializeField] Color dmgColor;
    Color initialColor;
    public GameObject deathScreenUI;

    void Start()
    {
        initialColor = spritePlayer.color;
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

        if(isPlayerDead)
        {
            deathScreenUI.SetActive(true);
        }
    }

    public void TakeDamage(int damageTaken)
    {
        StartCoroutine(DamageVFX());
        PlayerSoundManager.instance.PlaySoundHurt();
        if (veloPowerup)
        {
            PlayerSoundManager.instance.PlaySoundPowerDown();
            hasPowerup = false;
            LoseVeloPowerup();
        } 
        else if (pteroPowerup)
        {
            PlayerSoundManager.instance.PlaySoundPowerDown();
            hasPowerup = false;
            LosePteraPowerup();
        } 
        else if (tricePowerup)
        {
            PlayerSoundManager.instance.PlaySoundPowerDown();   
            hasPowerup = false;
            LoseTricePowerup();
        }
        
        playerHealth -= damageTaken;
        OnPlayerDamaged?.Invoke();
        Debug.Log("Player health:" + playerHealth);
        if (playerHealth <= 0) 
        {
            PlayerSoundManager.instance.PlaySoundDeath();
            isPlayerDead = true;
            GetComponent<PlayerController>().OnDead();
            GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            
        }
    }

    public void GetPteraPowerup ()
    {
        PlayerSoundManager.instance.PlaySoundPowerUp();
        hasPowerup = true;
        LoseTricePowerup();
        LoseVeloPowerup();
        pteroPowerup = true;
        anim.SetBool("pteroPowerup", true);
        anim.SetTrigger("ptero");
    }

    public void GetTricePowerup()
    {
        PlayerSoundManager.instance.PlaySoundPowerUp();
        hasPowerup = true;
        LosePteraPowerup();
        LoseVeloPowerup();
        tricePowerup = true;
        anim.SetBool("tricePowerup", true);
        anim.SetTrigger("trice");
    }

    public void GetVeloPowerup()
    {
        PlayerSoundManager.instance.PlaySoundPowerUp();
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

    IEnumerator DamageVFX()
    {
        spritePlayer.color = dmgColor;
        //Dmg effect time
        yield return new WaitForSeconds(0.25f);
        spritePlayer.color = initialColor;
    }
}
