using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ClearPoint : MonoBehaviour
{
    public static event Action OnGameClearEvent;

    [SerializeField] GameData gamedata;

    protected Rigidbody rigid;
    protected BoxCollider box;


    public void Start()
    {
        rigid = GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            gamedata.isGameEnd = true;
            OnGameClearEvent?.Invoke();
        }
    }
}