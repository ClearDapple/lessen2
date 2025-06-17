using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    public bool isGameEnd;
    
    public string nowStageLevelUI = "";
    public string GameClearMessageUI = "Game Clear!";
    public string NextStageButtonUI = "Next Stage";
    public string QuitButtonUI = "Exit Game";
    public string RestartButtonUI = "Continue?";

    public int horizontalCount = 30;    //���� ����
    public int verticalCount = 5;       //���� ����
    public float tileSpacing = 2f;      //������ ������ ����

    public int nomalTrapCount = 10;
    public int instantKillTrapCount = 3;
    public float xPosNullTrap = 3f;     //Ʈ�� �̹߻� x��ġ

    public int Damege = 35;
    public int Heal = 10;

    public float slowDelayTime = 3f;
    public float knockBackPower = 15;

    private int stagelevel;
    public int StageLevel
    {
        get { return stagelevel; }
        set { stagelevel = value;
            nowStageLevelUI = "Stage: " + stagelevel;
        }
    }
}