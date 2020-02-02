using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Audio 
{
    public string name;
    [HideInInspector]
    public AudioSource source;
    public AudioClip clip;
    [Range(0,1)]
    public float volume;
    [Range(0, 1)]
    public float pitch;
    public bool loop;
    
}
