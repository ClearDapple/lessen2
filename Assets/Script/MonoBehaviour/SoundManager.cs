using System;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    Hit,
    Over,
    Clear,
    Item,
    Jump,
    Run
}

public class SoundManager : MonoBehaviour
{
    public Dictionary<AudioType, AudioClip> playList;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip over;
    [SerializeField] AudioClip clear;
    [SerializeField] AudioClip item;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip run;

    private void Start()
    {
        playList = new Dictionary<AudioType, AudioClip>();
        playList.Add(AudioType.Hit, hit);
        playList.Add(AudioType.Over, over);
        playList.Add(AudioType.Clear, clear);
        playList.Add(AudioType.Item, item);
        playList.Add(AudioType.Jump, jump);
        playList.Add(AudioType.Run, run);

        Trap.OnHitAudio += Trap_HitAudio;

    }

    private void Trap_HitAudio(AudioType myType)
    {
        PlayOneList(myType);
    }

    public void PlayOneList(AudioType myType)
    {
        AudioClip clip = playList[myType];

        AudioSource.PlayClipAtPoint(clip, transform.position);
        Debug.Log("audio clip name: " + clip.name);
    }
}
