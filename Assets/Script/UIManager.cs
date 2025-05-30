using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
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

    void Awake()
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

    void start()
    {
        GameManager.OnGameStart += GameManager_OnGameStart;
        GameManager.OnGameEnd += GameManager_OnGameEnd;
        GameManager.OnGameOver += GameManager_OnGameOver;
        GameManager.OnGameClear += GameManager_OnGameClear;
    }
    private void GameManager_OnGameStart()
    {
        throw new System.NotImplementedException();
    }

    private void GameManager_OnGameEnd()
    {
        throw new System.NotImplementedException();
    }

    private void GameManager_OnGameOver()
    {
        throw new System.NotImplementedException();
    }

    private void GameManager_OnGameClear()
    {
        throw new System.NotImplementedException();
    }







    private void Update()
    {
        
    }

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

    private void Start()
    {
        GetHP((int)HPBar.highValue);
    }

    public void GetHP(int hp)
    {
        HPBar.value = hp;
        HPBar.title = hp + "/" + HPBar.highValue;
    }

    public void GetStage(int level)
    {
        StageLabel.text = "Stage: " + level;
    }
}