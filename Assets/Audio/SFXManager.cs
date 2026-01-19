using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource FXSource;

    public static SFXManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void PlaySoundFX(Transform Position, AudioClip FX, float Pitch, float Volume)
    {
        Debug.Log("Suena");
        FXSource.pitch = Pitch;
        FXSource.volume = Volume;
        AudioSource Source = AudioSource.Instantiate(FXSource, Position);
        FXSource.PlayOneShot(FX);
        Destroy(Source, FX.length);
    }
}
