using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //private AudioSource audioSc;
    //Animator anim;
    //public HeartsBar hBar;


    //[SerializeField] private AudioClip[] playerDamage;
    //public float volumenSonido = 1f;

    
    //public float maxHealth = 3f;
    //public float health;
    //public float currHealth;
    //public static bool isInv;
    //public static bool firstHealth;






    //public bool gameOver = false;
    //public static bool isPlayerDead;
    //private float invTime = 1f;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    audioSc = GetComponent<AudioSource>();
    //    if (firstHealth == false) {
    //        health = maxHealth;
    //        GameData.currentHealth = maxHealth;
    //        GameData.currMaxHealth = maxHealth;
    //        firstHealth = true;
    //    } else
    //    {
    //        health = GameData.currentHealth;
    //        maxHealth = GameData.currMaxHealth;
    //    }
    //    isPlayerDead = false;
    //    isInv = false;
        
    //    Physics2D.IgnoreLayerCollision(6, 7, false);
    //    Physics2D.IgnoreLayerCollision(6, 9, false);

    //    Debug.Log(GameData.currentHealth);
      
    //    anim = GetComponent<Animator>();

    //    hBar.DrawHearts();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //public void TakeDamage(float damage)
    //{


    //    health -= damage;
    //    GameData.currentHealth -= damage;
    //    hBar.DrawHearts();
      

    //        if (isInv == false)
    //        {
    //            //SoundFXManager.instance.PlayRandomSoundFXClip(playerDamage, transform, volumenSonido);
    //            StartCoroutine(InvencivilityTime());
    //        }
        



    //    if (health <= 0)
    //    {
    //        Die();
    //    }
    //}

    //public void PlayerHeal(float heal)
    //{


    //    health += heal;
    //    GameData.currentHealth += heal;
    //    if (health > maxHealth)
    //    {
    //        health = maxHealth;
    //        GameData.currentHealth = maxHealth;
    //    }


    //    hBar.DrawHearts();


     
    //}

    //public void IncreaseHealth(float extraHealth)
    //{
    //    maxHealth += extraHealth;
    //    GameData.currMaxHealth += extraHealth;
    //    health += extraHealth;
    //    GameData.currentHealth += extraHealth;
        
    //    if (health > maxHealth)
    //    {
    //        health = maxHealth;
    //        GameData.currentHealth = maxHealth;
    //    }


    //    hBar.DrawHearts();



    //}



    //void Die()
    //{
        
    //        gameOver = true;
    //        isPlayerDead = true;

    //        //StartCoroutine(DeathDelay());


        
       
    //}

    //IEnumerator DeathDelay()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    gameObject.SetActive(false);

    //}

    //IEnumerator InvencivilityTime()
    //{
    //    isInv = true;
    //    Physics2D.IgnoreLayerCollision(6, 7);
    //    Physics2D.IgnoreLayerCollision(6, 9);
    //    yield return new WaitForSeconds(invTime);
    //    Physics2D.IgnoreLayerCollision(6, 7, false);
    //    Physics2D.IgnoreLayerCollision(6, 9, false);
    //    isInv = false;
    //}

    
}
