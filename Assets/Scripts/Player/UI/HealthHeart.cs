using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{
    public Sprite fullHeart;
    public Sprite emptyHeart;
    Image heartImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHeartImage(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.Empty:
                heartImage.sprite = emptyHeart;
                break;
            case HeartStatus.Full:
                heartImage.sprite = fullHeart;
                break;
        }
        

    }
}

public enum HeartStatus
{
    Empty = 0,
    Full = 1
}
