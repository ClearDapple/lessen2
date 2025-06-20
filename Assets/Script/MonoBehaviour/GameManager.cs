using System;
using UnityEngine;
using UnityEngine.Analytics;


public class GameManager : MonoBehaviour
{
    [SerializeField] StageLevelSO stagelevelSO;
    [SerializeField] GameData gamedata;
    [SerializeField] PlayerData playerdata;
    public Player player;


    private void Awake()
    {
        stagelevelSO.stageLevel = 1;
        gamedata.isGameEnd = false;
    }

    private void Start()
    {
        UIManager.OnGameStartEvent += UIManager_OnGameStartEvent;
    }

    private void UIManager_OnGameStartEvent()
    {
        Respawn();
        gamedata.isGameEnd = false;
    }

    //public void NextStage()
    //{
    //    gamedata.StageLevel++;
    //    //ClearStage();
    //    //CreatStage();
    //    Respawn();
    //}

    public void Restart()
    {
        Respawn();
    }

    public void Respawn()
    {
        player.gameObject.transform.position = new Vector3(1.5f, 5f, gamedata.verticalCount * gamedata.tileSpacing / 2f);
    }
}