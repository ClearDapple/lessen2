using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameData gamedata;

    //[SerializeField] GameObject[] _Trap;
    //[SerializeField] Transform[] _position;
    //[SerializeField] Transform _parent;
    //[SerializeField] Transform _3DTiles;
    //[SerializeField] Transform _startPoint;//시작지점
    //[SerializeField] Transform _ClearPoint;//종료지점
    [SerializeField] private Transform groundParent;        // 타일 부모
    [SerializeField] private Transform trapParent;          // 트랩 부모
    [SerializeField] private Transform collectableParent;   // 아이템 부모
    [SerializeField] private Transform clearPointParent;    // 클리어포인트 부모

    public GameObject[] GroundPrefabs;          //사용할 타일 프리팹 배열

    public GameObject[] InstantKillTrapPrefab;  //사용할 즉사 트랩 프리팹 배열
    public GameObject[] nomalTrapPrefabs;       //사용할 노말 트랩 프리팹 배열

    public GameObject[] CollectablePrefab;      //사용할 아이템 프리팹 배열

    public GameObject _ClearPoint;              //사용할 클리어포인트 프리팹

    public StageLevelOS[] stageLevel;
    public StageLevelOS currentStageLevel;

    private void Start()
    {
        UIManager.OnGameStartEvent += UIManager_OnGameStartEvent;
        //BaseTrap.OnTrapDeleteEvent += BaseTrap_OnTrapDeleteEvent;
    }

    //////public void CreateCurrentStage(StageLevelOS currentStage)
    //////{
    //////    GameObject[] gameObjects = new GameObject[5];
    //////    List<GameObject> myObject = new List<GameObject>();

    //////    for (int i = 0; i < currentStage.NomalTrapAddCount; i++)
    //////    {
    //////        GameObject clone = Instantiate(nomalTrapPrefabs[UnityEngine.Random.Range(0, trapParent.Length)], trapParent.position);
    //////        myObject.Add(clone);
    //////    }
    //////}

    //private void BaseTrap_OnTrapDeleteEvent()
    //{
    //    int xPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// 랜덤 위치 생성
    //    int yPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
    //    float zPos = 3f;
    //    Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

    //    //int randomRotationAngle = UnityEngine.Random.Range(0, 360); //랜덤한 방향 설정
    //    //Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);
    //    Quaternion randomRotation = Quaternion.Euler(0f, 0f, 0f);

    //    int randomTrapIndex = UnityEngine.Random.Range(0, nomalTrapPrefabs.Length);// 랜덤 트랩 선택
    //    GameObject randomTrap = nomalTrapPrefabs[randomTrapIndex];

    //    Instantiate(randomTrap, randomPosition, randomRotation, trapParent);
    //}

    private void UIManager_OnGameStartEvent()
    {
        DeleteAll();
        CreateAll();
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

    //

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

    public void DeleteGround()
    {
        foreach (Transform child in groundParent)
        {
            Destroy(child.gameObject);
        }
    }

    //

    public void CreateTrap()
    {
        //for (int i = 0; i < gamedata.nomalTrapCount; i++)
        //{
        //    GameObject clone = Instantiate(_Trap[Random.Range(0, _Trap.Length)], _position[i].position, Quaternion.identity);
        //    clone.transform.parent = _parent;
        //}


        for (int i = 0; i < gamedata.instantKillTrapCount + currentStageLevel.NomalTrapAddCount; i++)//즉사트랩
        {
            int xPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// 랜덤 위치 생성
            int yPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            //int randomRotationAngle = UnityEngine.Random.Range(0, 360); //랜덤한 방향 설정
            //Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, InstantKillTrapPrefab.Length);// 랜덤 트랩 선택
            GameObject randomTrap = InstantKillTrapPrefab[randomTrapIndex];

            Instantiate(randomTrap, randomPosition, randomRotation, trapParent);
        }
        for (int i = 0; i < gamedata.nomalTrapCount+ currentStageLevel.InstansKillTrapAddCount; i++)//노말트랩
        {
            int xPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// 랜덤 위치 생성
            int yPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            //int randomRotationAngle = UnityEngine.Random.Range(0, 360); //랜덤한 방향 설정
            //Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, nomalTrapPrefabs.Length);// 랜덤 트랩 선택
            GameObject randomTrap = nomalTrapPrefabs[randomTrapIndex];

            Instantiate(randomTrap, randomPosition, randomRotation, trapParent);
        }
    }

    public void DeleteTrap()
    {
        foreach (Transform child in trapParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void CreateClearPoint()
    {
        Vector3 clearPosition = new Vector3(gamedata.horizontalCount * gamedata.tileSpacing, 2f, gamedata.verticalCount-1 * gamedata.tileSpacing / 2f);
        Quaternion clearRotation = Quaternion.Euler(0f, 0f, 0f);

        GameObject clone = Instantiate(_ClearPoint, clearPosition, clearRotation, clearPointParent);
    }

    public void DeleteClearPoint()
    {
        foreach (Transform child in clearPointParent)
        {
            Destroy(child.gameObject);
        }
    }
}