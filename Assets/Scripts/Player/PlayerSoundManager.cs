using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] AudioSource PlayerAudio;
    [SerializeField] List<SoundScriptable> SoundScripts;
    public static PlayerSoundManager instance;

    [SerializeField] BoxCollider2D attackCollider;
    [SerializeField] BoxCollider2D attackColliderCrouch;

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

    public SoundScriptable SelectSoundType(Type Type)
    {
        for (int i = 0; i < SoundScripts.Count; i++)
        {
            if (SoundScripts[i].ID == Type)
            {
                return SoundScripts[i];
            }
        }
        return null;
    }

    public void PlayPlayerSound(Type Type)
    {
        SoundScriptable SoundType = SelectSoundType(Type);
        AudioClip ClipToPlay = SoundType.SelectClip();
        PlayerAudio.pitch = SoundType.Pitch;
        PlayerAudio.volume = SoundType.Volume;
        PlayerAudio.PlayOneShot(ClipToPlay);
    }

    public void PlaySoundAttack()
    {
        PlayPlayerSound(Type.Attack);
    }




    //COSAS DE ATAQUE PERDON POR DEJAR EL CÓDIGO FEO
    void ActivateAttackColliderStanding()
    {
        attackCollider.enabled = true;
    }

    void DeactivateAttackColliderStanding()
    {
        attackCollider.enabled = false;
    }

    void ActivateAttackColliderCrouch()
    {
        attackColliderCrouch.enabled = true;
    }

    void DeactivateAttackColliderCrouch()
    {
        attackColliderCrouch.enabled = false;
    }
}
