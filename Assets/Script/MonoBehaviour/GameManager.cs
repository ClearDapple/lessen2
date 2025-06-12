using System;
using UnityEngine;
using UnityEngine.Analytics;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameData gamedata;
    [SerializeField] PlayerData playerdata;
    public Player player;
    public TileManager tilemanager;
    public TrapManager trapmanager;


    private void Start()
    {
        UIManager.OnGameStartEvent += UIManager_OnGameStartEvent;
        gamedata.stageLevel = 0;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    private void UIManager_OnGameStartEvent()
    {
        gamedata.isGameEnd = false;
        //NextStage();
    }

    public void NextStage()
    {
        gamedata.stageLevel++;
        //ClearStage();
        //CreatStage();
        Respawn();
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