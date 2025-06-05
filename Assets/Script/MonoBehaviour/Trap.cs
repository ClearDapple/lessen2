using System;
using UnityEngine;

public class Trap : MonoBehaviour
{
    //public static event Action<AudioType> OnHitAudio;

    //[SerializeField] GameData gamedata;
    //[SerializeField] PlayerData playerdata;

    private Rigidbody rigid;
    //private MeshCollider mesh;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        //mesh = GetComponent<MeshCollider>();
        //mesh.enabled = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //mesh.enabled = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //mesh.enabled = true;
        }
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        playerdata.HP -= gamedata.Demege;
    //        Debug.Log("HP = " + playerdata.HP);
    //        Debug.Log("Demege = " + gamedata.Demege);
    //        OnHitAudio?.Invoke(AudioType.Hit);
    //    }
    //}
}