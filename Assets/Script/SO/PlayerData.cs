using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public bool isGround = false;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public int MaxHP = 100;
    public int MinHP = 0;
    public int HP = 100;

    public string nowHPUI = "";
}