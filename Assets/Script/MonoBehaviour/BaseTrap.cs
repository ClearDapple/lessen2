using System;
using UnityEngine;

public class BaseTrap : MonoBehaviour
{
    public static event Action<VFXType, Vector3> OnHitVFXEvent;
    public static event Action<AudioType> OnHitAudioEvent;
    public VFXType myVFXType;
    public AudioType myAudioType;

    public GameData gamedata;
    public PlayerData playerdata;

    protected Rigidbody rigid;
    protected MeshCollider mesh;

    public void Start()
    {
        rigid = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshCollider>();

        mesh.enabled = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mesh.enabled = true;
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHitEffect();
            OnHitVFXEvent?.Invoke(myVFXType, collision.transform.position);
            OnHitAudioEvent?.Invoke(myAudioType);
        }
    }

    public virtual void PlayerHitEffect()
    {

    }
}
