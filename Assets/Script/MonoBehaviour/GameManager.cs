using System;
using UnityEngine;
using UnityEngine.Analytics;


public class GameManager : MonoBehaviour
{

    public static event Action OnGameOverEvent;

    [SerializeField] GameData gamedata;
    [SerializeField] PlayerData playerdata;
    public Player player;
    public TileManager tilemanager;
    public TrapManager trapmanager;
    public bool isGameEnd = false;


    private void Start()
    {
        UIManager.OnGameStartEvent += UIManager_OnGameStartEvent;
        gamedata.stageLevel = 0;
    }

    public void Update()
    {
        if (playerdata.HP <= 0 && isGameEnd == false)
        {
            isGameEnd = true;
            OnGameOverEvent?.Invoke();
        }
    }

    private void UIManager_OnGameStartEvent()
    {
        NextStage();
    }

    public void NextStage()
    {
        gamedata.stageLevel++;
        ClearStage();
        CreatStage();
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