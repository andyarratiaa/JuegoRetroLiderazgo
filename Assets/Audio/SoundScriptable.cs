using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundScriptable", menuName = "Scriptable Objects/SoundScriptable")]
public class SoundScriptable : ScriptableObject
{
    [SerializeField] List<AudioClip> clipList = new List<AudioClip>();
    [SerializeField] bool RandomPitch;
}
