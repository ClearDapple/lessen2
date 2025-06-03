using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static event Action OnGameStartEvent;
    public static event Action OnGameEndEvent;
    public static event Action OnGameClearEvent;
    public static event Action OnGameOverEvent;

    [SerializeField] GameData gamedata;
    [SerializeField] PlayerData playerdata;
    public UIManager uimanager;
    public Player player;
    public TileManager tilemanager;
    public TrapManager trapmanager;


    private void Start()
    {

    }

    private void Update()
    {

    }

    public void NextStage()
    {
        gamedata.stageLevel++;
        //uimanager.GetStage(stageLevel);
        ClearStage();
        CreatStage();
    }

    public void Restart()
    {
        Respawn();
    }

    public void Respawn()
    {
        player.gameObject.transform.position = new Vector3(1.5f, 5f, gamedata.verticalCount * gamedata.tileSpacing / 2f);
    }

    public void CreatStage()
    {
        tilemanager.CreatGround();
        trapmanager.CreateTrap();
    }

    public void ClearStage()
    {
        tilemanager.DeleteGround();
        trapmanager.DeleteTrap();
    }
}