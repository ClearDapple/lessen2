using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerDataSO")]
public class PlayerData : ScriptableObject
{
    public static event Action OnDeathEvent;
    public static event Action OnGameOverEvent;

    [SerializeField] GameData gamedata;

    public bool isGround;
    public bool isMoveable;

    public float moveSpeed;
    public float nomalMoveSpeed = 5f;
    public float slowMoveSpeed = 3f;

    public float jumpForce;
    public float nomalJumpForce = 5f;
    public float slowJumpForce = 3f;

    public int maxHP = 100;
    public int minHP = 0;
    public string nowHPUI;
    public int HP;

    public void UpdateHP(int value)
    {
        HP = Mathf.Clamp(value, minHP, maxHP);
        if (HP == minHP && !gamedata.isGameEnd)
        {
            Life--;
            gamedata.isGameEnd = true;
            OnDeathEvent?.Invoke();
        }
        nowHPUI = $"HP: {HP}/{maxHP}";
    }

    public int maxLife = 5;
    public int minLife = 0;
    public string nowLifeUI;
    public int Life;

    public void UpdateLife(int value)
    {
        Life = Mathf.Clamp(value, minLife, maxLife);
        if (Life == minLife)
        {
            OnGameOverEvent?.Invoke();
        }
        nowLifeUI = $"Life: {Life}/{maxLife}";
    }
}