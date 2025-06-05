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
        ClearPoint.OnGameClearEvent += ClearPoint_OnGameClearEvent;
        GameManager.OnGameOverEvent += GameManager_OnGameOverEvent;

        PlayerPage.visible = true;
        GameClearPage.visible = false;
        GameOverPage.visible = false;
        
        OnGameStartEvent?.Invoke();
    }

    private void Update()
    {
        GetMyUI();
    }

    public void GameManager_OnGameStartEvent()
    {
        PlayerPage.visible = true;
        GameClearPage.visible = false;
        GameOverPage.visible = false;
        gamedata.isGameEnd = false;
    }

    private void ClearPoint_OnGameClearEvent()
    {
        PlayerPage.visible = false;
        GameClearPage.visible = true;
        GameOverPage.visible = false;
    }

    private void GameManager_OnGameOverEvent()
    {
        PlayerPage.visible = false;
        GameClearPage.visible = false;
        GameOverPage.visible = true;
    }

    public void GetMyUI()
    {
        playerdata.nowHPUI = playerdata.HP + "/" + playerdata.MaxHP;
        gamedata.nowStageLevelUI = "Stage: " + gamedata.stageLevel;
    }

    public void OnNextStageButtonClick()
    {
        GameManager_OnGameStartEvent();
        OnGameStartEvent?.Invoke();
    }

    public void OnGameQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnGameRestartButtonClick()
    {
        OnGameStartEvent?.Invoke();
    }
}