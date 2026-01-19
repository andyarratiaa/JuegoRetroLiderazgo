using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundScriptable", menuName = "Scriptable Objects/SoundScriptable")]
public class SoundScriptable : ScriptableObject
{
    public Type ID;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] bool RandomPitch = true;
    public float Volume = 1;
    public float Pitch = 1;

    public AudioClip SelectClip()
    {
        if (RandomPitch)
        {
            Pitch = Random.Range(0.7f, 1.3f);
        }
        return audioClips[Random.Range(0, audioClips.Length)];
    }
}

public enum Type
{
    Attack,
    Hurt,
    Death,
}