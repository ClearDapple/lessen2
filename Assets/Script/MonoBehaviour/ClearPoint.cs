using System;
using UnityEngine;

public class ClearPoint : MonoBehaviour
{
    public static event Action OnGameClearEvent;

    [SerializeField] GameData gamedata;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gamedata.isGameEnd = true;
            OnGameClearEvent?.Invoke();
        }
    }
}