using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    public CinemachineFollow cameraFollow;

    [SerializeField] bool FadeIn;
    [SerializeField] bool FadeOut;
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        if(FadeIn)
        {
            anim.SetTrigger("FadeIn");
        } 
        if(FadeOut)
        {
            anim.SetTrigger("FadeOut");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StopCameraFollow()
    {
        cameraFollow.enabled = false;
    }

    void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void DisableScreen()
    {
        gameObject.SetActive(false);
    }
}
