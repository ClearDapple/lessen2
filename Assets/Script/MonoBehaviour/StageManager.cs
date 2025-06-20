using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using static UnityEngine.Rendering.DebugUI.Table;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameData gamedata;

    //public StageLevelOS[] stageLevel;
    public StageLevelSO currentStageLevel;

    //[SerializeField] GameObject[] _Trap;
    //[SerializeField] Transform[] _position;
    //[SerializeField] Transform _parent;
    //[SerializeField] Transform _3DTiles;
    //[SerializeField] Transform _startPoint;//시작지점
    //[SerializeField] Transform _ClearPoint;//종료지점
    [SerializeField] private Transform groundParent;            // 타일 부모
    [SerializeField] private Transform trapCollectableParent;   // 트랩&아이템 부모
    [SerializeField] private Transform clearPointParent;        // 클리어포인트 부모

    public GameObject _TilePos;

    public GameObject[] GroundPrefabs;          //사용할 타일 프리팹 배열

    public GameObject[] InstantKillTrapPrefab;  //사용할 즉사 트랩 프리팹 배열
    public GameObject[] nomalTrapPrefabs;       //사용할 노말 트랩 프리팹 배열

    public GameObject[] CollectablePrefab;      //사용할 아이템 프리팹 배열

    public GameObject _ClearPoint;              //사용할 클리어포인트 프리팹

    private int NomalCount;
    private int InstansCount;

    private void Start()
    {
        UIManager.OnGameStartEvent += UIManager_OnGameStartEvent;
    }

    private void UIManager_OnGameStartEvent()
    {
        //DeleteAll();
        //CreateAll();
        SetRandTilePos();
    }

    public void CreateCurrentStage(StageLevelSO currentStage)
    {
        //GameObject[] gameObjects = new GameObject[5];
        List<GameObject> myTile = new List<GameObject>();
        List<GameObject> myTrap = new List<GameObject>();
        List<GameObject> myItem = new List<GameObject>();

        //맵 생성
        for (int i = 0; i < gamedata.horizontalCount * gamedata.verticalCount; i++)
        {
            GameObject clone = Instantiate(GroundPrefabs[UnityEngine.Random.Range(0, GroundPrefabs.Length)],
                               groundParent.position, Quaternion.identity);
            myTile.Add(clone);
        }

        //즉사 트랩 생성
        for (int i = 0; i < gamedata.instantKillTrapCount + currentStage.InstansKillTrapAddCount; i++)
        {
            GameObject clone = Instantiate(InstantKillTrapPrefab[UnityEngine.Random.Range(0, InstantKillTrapPrefab.Length)],
                               trapCollectableParent.position, Quaternion.identity);
            myTrap.Add(clone);
        }

        //노말 트랩 생성
        for (int i = 0; i < gamedata.nomalTrapCount + currentStage.NomalTrapAddCount; i++)
        {
            GameObject clone = Instantiate(nomalTrapPrefabs[UnityEngine.Random.Range(0, nomalTrapPrefabs.Length)], 
                               trapCollectableParent.position, Quaternion.identity);
            myTrap.Add(clone);
        }

        //아이템 생성
        for (int i = 0; i < gamedata.collectableCount + currentStage.CollectableAddCount; i++)
        {
            GameObject clone = Instantiate(CollectablePrefab[UnityEngine.Random.Range(0, CollectablePrefab.Length)],
                               trapCollectableParent.position, Quaternion.identity);
            myItem.Add(clone);
        }

        //셔플하기
        UTILS.Shuffle(myItem);

        //for (int i = 0; i < length; i++)
        //{

        //}
    }

    public void SetRandTilePos()
    {
        for (int i = 0; i < gamedata.verticalCount; i++)
        {
            float xPos = i * gamedata.tileSpacing;
            for (int ii = 0; ii < gamedata.horizontalCount; ii++)
            {
                float zPos = ii * gamedata.tileSpacing;
                Vector3 spawnPosition = new Vector3(xPos, 0f, zPos);
                Instantiate(_TilePos, spawnPosition, Quaternion.Euler(0, 0, 0), groundParent);
            }
        }
    }

    public void DeleteAll()
    {
        DeleteGround();
        DeleteTrap();
        DeleteClearPoint();
    }

    public void CreateAll()
    {
        CreatGround();
        CreateTrap();
        CreateClearPoint();
    }

    public void CreatGround()
    {
        for (int zRow = 0; zRow < gamedata.verticalCount; zRow++)   //세로 범위
        {
            for (int xRow = 0; xRow < gamedata.horizontalCount; xRow++) //가로 범위
            {
                int randomTileIndex = UnityEngine.Random.Range(0, GroundPrefabs.Length);  //랜덤한 타일 프리팹 선택
                GameObject randomTile = GroundPrefabs[randomTileIndex];

                int randomRotationAngle = UnityEngine.Random.Range(0, 4) * 90;  //90도 간격으로 랜덤한 방향 설정
                Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);

                float xPos = xRow * gamedata.tileSpacing;
                float zPos = zRow * gamedata.tileSpacing;
                Vector3 spawnPosition = new Vector3(xPos, 0f, zPos);

                Instantiate(randomTile, spawnPosition, randomRotation, groundParent);
            }
        }
    }

    public void CreateTrap()
    {
        for (int i = 0; i < InstansCount; i++)//즉사트랩
        {
            int xPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// 랜덤 위치 생성
            int yPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);


            Quaternion randomRotation = Quaternion.Euler(0f, 0f, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, InstantKillTrapPrefab.Length);// 랜덤 트랩 선택
            GameObject randomTrap = InstantKillTrapPrefab[randomTrapIndex];

            Instantiate(randomTrap, randomPosition, randomRotation, trapCollectableParent);
        }

        for (int i = 0; i < NomalCount; i++)//노말트랩
        {
            int xPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// 랜덤 위치 생성
            int yPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            Quaternion randomRotation = Quaternion.Euler(0f, 0f, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, nomalTrapPrefabs.Length);// 랜덤 트랩 선택
            GameObject randomTrap = nomalTrapPrefabs[randomTrapIndex];

            Instantiate(randomTrap, randomPosition, randomRotation, trapCollectableParent);
        }
    }

    public void CreateClearPoint()
    {
        Vector3 clearPosition = new Vector3(gamedata.horizontalCount * gamedata.tileSpacing, 2f, gamedata.verticalCount-1 * gamedata.tileSpacing / 2f);
        Quaternion clearRotation = Quaternion.Euler(0f, 0f, 0f);

        GameObject clone = Instantiate(_ClearPoint, clearPosition, clearRotation, clearPointParent);
    }

    public void DeleteGround()
    {
        foreach (Transform child in groundParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void DeleteTrap()
    {
        foreach (Transform child in trapCollectableParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void DeleteClearPoint()
    {
        foreach (Transform child in clearPointParent)
        {
            Destroy(child.gameObject);
        }
    }
}