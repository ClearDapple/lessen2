using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameData gamedata;
    [SerializeField] PlayerData playerdata;
    public TileManager tilemanager;
    public TrapManager trapmanager;
    public GameManager gamemanager;

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
        PlayerPage.visible = true;
        GameClearPage.visible = false;
        GameOverPage.visible = false;

      
    }

  

    private void Update()
    {
        playerdata.nowHPUI = playerdata.HP + "/" + playerdata.MaxHP;
        gamedata.nowStageLevelUI = "Stage: " + gamedata.stageLevel;
    }

    //private void GameManager_OnGameStart()
    //{
    //    throw new System.NotImplementedException();
    //}

    //private void GameManager_OnGameEnd()
    //{
    //    throw new System.NotImplementedException();
    //}

    //private void GameManager_OnGameOver()
    //{
    //    throw new System.NotImplementedException();
    //}

    //private void GameManager_OnGameClear()
    //{
    //    throw new System.NotImplementedException();
    //}

    public void OnNextStageButtonClick()
    {
        gamemanager.NextStage();
    }

    public void OnGameQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnGameRestartButtonClick()
    {
        gamemanager.Restart();
    }
}