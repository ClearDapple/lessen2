using System;
using UnityEngine;

public class BaseTrap : MonoBehaviour
{
    public static event Action<AudioType> OnHitAudio;
    public AudioType myType;

    public GameData gamedata;
    public PlayerData playerdata;

    private Rigidbody rigid;
    private MeshCollider mesh;

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
            OnHitAudio?.Invoke(myType);
        }
    }

    public virtual void PlayerHitEffect()
    {

    }
}
