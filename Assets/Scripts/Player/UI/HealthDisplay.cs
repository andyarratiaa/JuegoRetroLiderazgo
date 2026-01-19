using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private PlayerVariablesManager health;

    public Image[] hearts;
    //Image heartImage;
    public float currHealth;

    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        //heartImage = GetComponent<Image>();
        health = GetComponent<PlayerVariablesManager>();
        currHealth = health.playerHealth; ;

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health.playerHealth; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }


}


