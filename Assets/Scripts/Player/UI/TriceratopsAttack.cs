using UnityEngine;

public class TriceratopsAttack : MonoBehaviour
{
    public BoxCollider2D triceAttackCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateCollider()
    {
        triceAttackCollider.enabled =true;
    }

    public void DectivateCollider()
    {
        triceAttackCollider.enabled = false;
    }

    public void DectivateGameobject()
    {
        gameObject.SetActive(false);
    }
}
