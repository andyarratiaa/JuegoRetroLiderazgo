using UnityEngine;

public class HippieAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    [SerializeField] Transform firingPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firingPoint.transform.position, Quaternion.identity);
    }

    
}
