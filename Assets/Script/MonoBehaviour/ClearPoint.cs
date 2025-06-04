using System;
using UnityEngine;

public class ClearPoint : MonoBehaviour
{
    public static event Action OnGameClearEvent;

    public GameManager gamemanager;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gamemanager.isGameEnd = true;
            OnGameClearEvent?.Invoke();
        }
    }
}
