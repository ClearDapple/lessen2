using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameDataSO")]
public class GameData : ScriptableObject
{
    public bool isGameEnd;
    
    public string GameClearMessageUI = "Game Clear!";
    public string NextStageButtonUI = "Next Stage";
    public string QuitButtonUI = "Exit Game";
    public string RestartButtonUI = "Continue?";

    public int horizontalCount = 30;    //���� ����
    public int verticalCount = 5;       //���� ����
    public float tileSpacing = 2f;      //������ ������ ����
    public float xPosNullTrap = 3f;     //Ʈ�� �̹߻� x��ġ

    public int nomalTrapCount = 10;
    public int instantKillTrapCount = 3;
    public int collectableCount = 3;

    public int damege = 35;
    public int heal = 10;

    public float slowDelayTime = 3f;
    public float knockBackPower = 15;
}