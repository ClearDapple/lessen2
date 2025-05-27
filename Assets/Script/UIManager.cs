using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    ProgressBar HPBar;

    private void Start()
    {
        HPBar = GetComponent<ProgressBar>();
        HPBar.value = 100;
    }

    public void GetHP(int hp)
    {
        HPBar.value = hp;
        HPBar.title = hp + "/" + HPBar.highValue;
    }
}