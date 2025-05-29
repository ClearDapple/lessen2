using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using static UnityEngine.Rendering.DebugUI.Table;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public UIManager uimanager;

    public static event Action OnGameStart;
    public static event Action OnGameEnd;
    public static event Action OnGameOver;
    public static event Action OnGameClear;

    public GameObject[] tilePrefabs;    //사용할 타일 프리팹 배열
    public GameObject SandGroundPrefab;
    public GameObject IceGroundPrefab;
    public GameObject LavaGroundPrefab;
    public GameObject WaterGroundPrefab;
    public GameObject StairsGroundPrefab;
    public GameObject SlopeGroundPrefab;
    public int horizontalCount = 30;    //가로 개수
    public int verticalCount = 5;       //세로 개수
    public float tileSpacing = 2f;      //프리팹 사이의 간격

    public GameObject[] nomalTrapPrefabs;
    public GameObject DemageTrapPrefab;
    public GameObject KnockBackTrapPrefab;
    public GameObject MoveObstructionTrapPrefab;

    public GameObject InstantKillTrapPrefab;//InstantKillTrap
    public int nomalTrapCount = 10;
    public int InstantKillTrapCount = 3;
    public float xPosNullTrap = 3f;     //트랩 미발생 x위치



    private int stageLevel = 0;


    private void Start()
    {
        tilePrefabs = new GameObject[]
        {
            SandGroundPrefab,
            IceGroundPrefab,
            LavaGroundPrefab,
            WaterGroundPrefab,
            StairsGroundPrefab,
            SlopeGroundPrefab
        };

        nomalTrapPrefabs = new GameObject[]
        {
            DemageTrapPrefab,
            KnockBackTrapPrefab,
            MoveObstructionTrapPrefab
        };

        NextStage();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            NextStage();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            CreatGround();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            CreateTrap();
        }
    }

    void NextStage()
    {
        stageLevel++;
        uimanager.GetStage(stageLevel);
        CreatGround();
        CreateTrap();
    }

    void CreatGround()
    {
        for (int zRow = 0; zRow < verticalCount; zRow++)//세로 범위
        {
            for (int xRow = 0; xRow < horizontalCount; xRow++)//가로 범위
            {
                int randomTileIndex = UnityEngine.Random.Range(0, tilePrefabs.Length);//랜덤한 타일 프리팹 선택
                GameObject randomTile = tilePrefabs[randomTileIndex];

                int randomRotationAngle = UnityEngine.Random.Range(0, 4) * 90;//90도 간격으로 랜덤한 방향 설정
                Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);

                float xPos = xRow * tileSpacing;
                float zPos = zRow * tileSpacing;
                Vector3 spawnPosition = new Vector3(xPos, 0f, zPos);

                Instantiate(randomTile, spawnPosition, randomRotation);
            }
        }
    }

    void CreateTrap()
    {
        for (int i = 0; i < nomalTrapCount; i++)
        {
            float xPos = UnityEngine.Random.Range(xPosNullTrap, horizontalCount* tileSpacing);// 랜덤 위치 생성
            float yPos = UnityEngine.Random.Range(xPosNullTrap, verticalCount* tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            int randomRotationAngle = UnityEngine.Random.Range(0, 360); //랜덤한 방향 설정
            Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, nomalTrapPrefabs.Length);// 랜덤 트랩 선택
            GameObject selectedTrap = nomalTrapPrefabs[randomTrapIndex];

            Instantiate(selectedTrap, randomPosition, randomRotation);
        }

        for (int i = 0; i < InstantKillTrapCount; i++)
        {
            float xPos = UnityEngine.Random.Range(xPosNullTrap, horizontalCount * tileSpacing);// 랜덤 위치 생성
            float yPos = UnityEngine.Random.Range(xPosNullTrap, verticalCount * tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            int randomRotationAngle = UnityEngine.Random.Range(0, 360); //랜덤한 방향 설정
            Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);

            Instantiate(InstantKillTrapPrefab, randomPosition, randomRotation);
        }
    }
}