using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerVariablesManager player;
    List<HealthHeart> hearts = new List<HealthHeart>();

    private void OnEnable()
    {
        PlayerVariablesManager.OnPlayerDamaged += DrawHearts;
    }

    private void OnDisable()
    {
        PlayerVariablesManager.OnPlayerDamaged -= DrawHearts;
    }
    private void Awake()
    {
       player = FindAnyObjectByType<PlayerVariablesManager>();
    }
    void Start()
    {
        DrawHearts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void DrawHearts()
    {
        ClearHearts();
        //float maxHealthReminder = player.playerMaxHealth;
        int heartsToMake = player.playerMaxHealth;
        for (int i = 0; i < heartsToMake; i++) 
        { 
            CreateEmptyHeart();
        }

        for (int i = 0; i < player.playerHealth;i++)
        {
            hearts[i].SetHeartImage((HeartStatus)1);
        }
    }

    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }
}
