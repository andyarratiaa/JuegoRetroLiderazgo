using UnityEngine;

public class ShowPowerupHUD : MonoBehaviour
{
    [SerializeField] GameObject veloSprite;
    [SerializeField] GameObject triceSprite;
    [SerializeField] GameObject pteroSprite;

    PlayerVariablesManager playerVariablesManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerVariablesManager = FindAnyObjectByType<PlayerVariablesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerVariablesManager.veloPowerup)
        {
            triceSprite.SetActive(false);
            pteroSprite.SetActive(false);
            veloSprite.SetActive(true);
        } else if (playerVariablesManager.tricePowerup) 
        {
            pteroSprite.SetActive(false);
            veloSprite.SetActive(false);
            triceSprite.SetActive(true);
        } else if (playerVariablesManager.pteroPowerup)
        {
            veloSprite.SetActive(false);
            triceSprite.SetActive(false);
            pteroSprite.SetActive(true);
        } else
        {
            veloSprite.SetActive(false);
            triceSprite.SetActive(false);
            pteroSprite.SetActive(false);
        }
    }
}
