using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public enum VFXType
{
    Hit,
    Slow,
    KnockBack,
    Death,
    Item,
    Jump,
    Landing
}

public class VFXManager : MonoBehaviour
{
    public Dictionary<VFXType, ParticleSystem> playList;
    [SerializeField] ParticleSystemAnimationType particle;
    [SerializeField] ParticleSystem hit;
    [SerializeField] ParticleSystem slow;
    [SerializeField] ParticleSystem knockBack;
    [SerializeField] ParticleSystem death;
    [SerializeField] ParticleSystem item;
    [SerializeField] ParticleSystem jump;
    [SerializeField] ParticleSystem landing;

    private void Start()
    {
        playList = new Dictionary<VFXType, ParticleSystem>();
        playList.Add(VFXType.Hit, hit);
        playList.Add(VFXType.Slow, slow);
        playList.Add(VFXType.KnockBack, knockBack);
        playList.Add(VFXType.Death, death);
        playList.Add(VFXType.Item, item);
        playList.Add(VFXType.Jump, jump);
        playList.Add(VFXType.Landing, landing);

        BaseTrap.OnHitVFXEvent += BaseTrap_OnHitVFXEvent;
    }

    public void BaseTrap_OnHitVFXEvent(VFXType objType, Vector3 pos)
    {
        ParticleSystem clip = playList[objType];

        ParticleSystem newParticle = Instantiate(clip, pos, Quaternion.identity);

        newParticle.Play();
        Debug.Log("particle clip name: " + clip.name);
        Destroy(newParticle.gameObject, newParticle.main.duration + newParticle.main.startLifetime.constantMax);
    }
}