using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static event Action OnGameStartEvent;

    [SerializeField] GameData gamedata;
    [SerializeField] PlayerData playerdata;

    [SerializeField] UIDocument MainToolkit;

    VisualElement PlayerPage;
    ProgressBar HPBar;
    Label StageLabel;

    VisualElement GameClearPage;
    Label ClearStageLabel;
    Button NextStageButton;

    VisualElement GameOverPage;
    Button GameQuitButton;
    Button GameRestartButton;

    public void Awake()
    {
        VisualElement root = MainToolkit.rootVisualElement;

        PlayerPage = root.Q<VisualElement>("PlayerUI");
        HPBar = PlayerPage.Q<ProgressBar>("HP");
        StageLabel = PlayerPage.Q<Label>("Stage");

        GameClearPage = root.Q<VisualElement>("GameClearUI");
        ClearStageLabel = GameClearPage.Q<Label>("ClearMesege");
        NextStageButton = GameClearPage.Q<Button>("NextStage");
        NextStageButton.clicked += OnNextStageButtonClick;

        GameOverPage = root.Q<VisualElement>("GameOverUI");
        GameQuitButton = GameOverPage.Q<Button>("Quit");
        GameRestartButton = GameOverPage.Q<Button>("Restart");
        GameQuitButton.clicked += OnGameQuitButtonClick;
        GameRestartButton.clicked += OnGameRestartButtonClick;
    }

    public void Start()
    {
        PlayerData.OnDeathEvent += PlayerData_OnDeathEvent;
        PlayerData.OnGameOverEvent += PlayerData_OnGameOverEvent;
        Player.OnGameClearEvent += Player_OnGameClearEvent;

        UIManager_OnGameStartEvent();
    }

    public void UIManager_OnGameStartEvent()
    {
        OnGameStartEvent?.Invoke();
        PlayerPage.visible = true;
        GameClearPage.visible = false;
        GameOverPage.visible = false;
    }

    public void PlayerData_OnDeathEvent()
    {
        PlayerPage.visible = false;
        GameClearPage.visible = false;
        GameOverPage.visible = true;
    }

    public void PlayerData_OnGameOverEvent()
    {

    }

    public void Player_OnGameClearEvent()
    {
        PlayerPage.visible = false;
        GameClearPage.visible = true;
        GameOverPage.visible = false;
    }

    public void GameManager_OnGameStartEvent()
    {
        PlayerPage.visible = true;
        GameClearPage.visible = false;
        GameOverPage.visible = false;
        gamedata.isGameEnd = false;
    }

///

    public void OnNextStageButtonClick()
    {
        UIManager_OnGameStartEvent();
    }

    public void OnGameQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnGameRestartButtonClick()
    {
        
        UIManager_OnGameStartEvent();
    }
}