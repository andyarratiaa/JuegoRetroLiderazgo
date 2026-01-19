using UnityEngine;

public class Powerup : MonoBehaviour
{
    public bool triceratops;
    public bool velociraptor;
    public bool pteranodon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerVariablesManager player = collision.GetComponent<PlayerVariablesManager>();

            if (triceratops)
            {
                player.GetTricePowerup();
            }
            else if (velociraptor)
            {
                player.GetVeloPowerup();
            }
            else if (pteranodon)
            {
                player.GetPteraPowerup();
            }
            Destroy(gameObject);
        }
        
    }
}
