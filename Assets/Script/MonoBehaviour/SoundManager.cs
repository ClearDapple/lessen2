using System;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    Hit,
    Death,
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
    [SerializeField] AudioClip death;

    private void Start()
    {
        playList = new Dictionary<AudioType, AudioClip>();
        playList.Add(AudioType.Hit, hit);
        playList.Add(AudioType.Over, over);
        playList.Add(AudioType.Clear, clear);
        playList.Add(AudioType.Item, item);
        playList.Add(AudioType.Jump, jump);
        playList.Add(AudioType.Run, run);
        playList.Add(AudioType.Death, death);

        BaseTrap.OnHitAudioEvent += BaseTrap_OnHitAudioEvent;
    }

    private void BaseTrap_OnHitAudioEvent(AudioType objType)
    {
        AudioClip clip = playList[objType];

        AudioSource.PlayClipAtPoint(clip, transform.position);
        Debug.Log("audio clip name: " + clip.name);
    }
}
