using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] UIDocument MainToolkit;
    VisualElement PlayerPage;
    ProgressBar HPBar;
    Label StageLabel;


    private void Awake()
    {
        VisualElement root = MainToolkit.rootVisualElement;

        PlayerPage = root.Q<VisualElement>("PlayerUI");
        HPBar = PlayerPage.Q<ProgressBar>("HP");
        StageLabel = PlayerPage.Q<Label>("Stage");
    }

    private void Start()
    {
        HPBar.value = 100;
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