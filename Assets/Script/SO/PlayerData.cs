using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public static event Action OnDeathEvent;
    public static event Action OnGameOverEvent;

    [SerializeField] GameData gamedata;

    public bool isGround;

    public float moveSpeed;
    public float nomalMoveSpeed = 5f;
    public float SlowMoveSpeed = 3f;

    public float jumpForce;
    public float nomalJumpForce = 5f;
    public float slowJumpForce = 3f;

    public int MaxHP = 100;
    public int MinHP = 0;
    public string nowHPUI = "";
    public int UIHP;

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
                Life--;
                gamedata.isGameEnd = true;
                OnDeathEvent?.Invoke();
            }

            if (hp > MaxHP)
            {
                hp = MaxHP;
            }
            UIHP = hp;
            nowHPUI = "HP: " + UIHP + "/" + MaxHP;
        }
    }

    public int MaxLife = 5;
    public int MinLife = 0;
    public string nowLifeUI = "";
    public int UILife;

    private int life;
    public int Life
    {
        get { return life; }
        set { life = value;
            if (life < MinLife)
            {
                life = MinLife;
            }

            if (life == MinLife)
            {
                OnGameOverEvent?.Invoke();
            }
            UILife = life;
            nowLifeUI = "Life: " + UILife + "/" + MaxLife;
        }
    }
}