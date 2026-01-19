using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsBar : MonoBehaviour
{

    //public GameObject heartPrefab;
    //public PlayerHealth plHealth;
    
    //List<HealthBarManager> hearts = new List<HealthBarManager>();

    
    //private void Start()
    //{
    //    DrawHearts();
    //}
    //public void ClearHearts()
    //{
    //    foreach (Transform t in transform)
    //    {
    //        Destroy(t.gameObject);
    //    }
    //    hearts = new List<HealthBarManager>();
    //}

    //public void CreateEmptyHeart()
    //{
    //    GameObject newHeart = Instantiate(heartPrefab);   
    //    newHeart.transform.SetParent(transform);
    //    newHeart.transform.localScale = Vector3.one;

    //    HealthBarManager heartComponent = newHeart.GetComponent<HealthBarManager>();
    //    heartComponent.SetHeartImage(HeartStatus.Empty);
    //    hearts.Add(heartComponent);
    //}

    //public void DrawHearts()
    //{
    //    ClearHearts();

    //    float maxHealthReminder = GameData.currMaxHealth % 2;
    //    int heartsToMake =(int)((GameData.currMaxHealth / 2) + maxHealthReminder);

    //    for (int i = 0; i < heartsToMake; i++) 
    //    {
    //        CreateEmptyHeart();
    //    }

    //    for (int i = 0; i < hearts.Count;i++)
    //    {
    //        int HeartStatusRemainder = (int)Mathf.Clamp(GameData.currentHealth - (i * 2), 0, 2);
    //        hearts[i].SetHeartImage((HeartStatus)HeartStatusRemainder);
    //    }
    //}
}
