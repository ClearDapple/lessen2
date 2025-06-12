using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public static event Action OnGameOverEvent;

    [SerializeField] GameData gamedata;

    public bool isGround = false;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public int MaxHP = 100;
    public int MinHP = 0;

    private int hp;
    public int HP
    {
        get { return hp; }
        set { hp = value;
            if (hp < MinHP)
            {
                hp = MinHP;
            }

            if (hp == MinHP && gamedata.isGameEnd == false)
            {
                gamedata.isGameEnd = true;
                OnGameOverEvent?.Invoke();
            }

            if (hp > MaxHP)
            {
                hp = MaxHP;
            }
        }
    }

    public string nowHPUI = "";
}