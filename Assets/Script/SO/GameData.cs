using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    public int stageLevel = 0;

    public int horizontalCount = 30;    //가로 개수
    public int verticalCount = 5;       //세로 개수
    public float tileSpacing = 2f;      //프리팹 사이의 간격

    public int nomalTrapCount = 10;
    public int instantKillTrapCount = 3;
    public float xPosNullTrap = 3f;     //트랩 미발생 x위치

    public int Demege = 35;
    public int Heal = 10;

    public string nowStageLevelUI = "";
    public string GameClearMessageUI = "Game Clear!";
    public string NextStageButtonUI = "Next Stage";
    public string QuitButtonUI = "Exit Game";
    public string RestartButtonUI = "Continue?";
}