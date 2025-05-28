using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uimanager;

    public static event Action OnGameStart;
    public static event Action OnGameEnd;
    public static event Action OnGameOver;
    public static event Action OnGameClear;

    public GameObject trapPrefab;
    public GameObject instantKillPrefab;
    public GameObject knockBackPrefab;
    public GameObject moveObstructionPrefab;

    [SerializeField] Transform _parent;

    public Transform[] trapPosition = new Transform[15];
    public int[] myScore;

    private int stageLevel = 0;


    private void Start()
    {
        NextStage();
    }

    //void CreateTrap()
    //{
    //    for (int i = 0; i < myScore.Length; i++)
    //    {
    //        GameObject clone = Instantiate(trapPrefab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
    //        clone.transform.parent = _parent;
    //    }
    //}

    void NextStage()
    {
        stageLevel++;
        uimanager.GetStage(stageLevel);
    }
}