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
    //[SerializeField] Transform _startPoint;//��������
    //[SerializeField] Transform _ClearPoint;//��������
    [SerializeField] private Transform groundParent;            // Ÿ�� �θ�
    [SerializeField] private Transform trapCollectableParent;   // Ʈ��&������ �θ�
    [SerializeField] private Transform clearPointParent;        // Ŭ��������Ʈ �θ�

    public GameObject _TilePos;

    public GameObject[] GroundPrefabs;          //����� Ÿ�� ������ �迭

    public GameObject[] InstantKillTrapPrefab;  //����� ��� Ʈ�� ������ �迭
    public GameObject[] nomalTrapPrefabs;       //����� �븻 Ʈ�� ������ �迭

    public GameObject[] CollectablePrefab;      //����� ������ ������ �迭

    public GameObject _ClearPoint;              //����� Ŭ��������Ʈ ������

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

        //�� ����
        for (int i = 0; i < gamedata.horizontalCount * gamedata.verticalCount; i++)
        {
            GameObject clone = Instantiate(GroundPrefabs[UnityEngine.Random.Range(0, GroundPrefabs.Length)],
                               groundParent.position, Quaternion.identity);
            myTile.Add(clone);
        }

        //��� Ʈ�� ����
        for (int i = 0; i < gamedata.instantKillTrapCount + currentStage.InstansKillTrapAddCount; i++)
        {
            GameObject clone = Instantiate(InstantKillTrapPrefab[UnityEngine.Random.Range(0, InstantKillTrapPrefab.Length)],
                               trapCollectableParent.position, Quaternion.identity);
            myTrap.Add(clone);
        }

        //�븻 Ʈ�� ����
        for (int i = 0; i < gamedata.nomalTrapCount + currentStage.NomalTrapAddCount; i++)
        {
            GameObject clone = Instantiate(nomalTrapPrefabs[UnityEngine.Random.Range(0, nomalTrapPrefabs.Length)], 
                               trapCollectableParent.position, Quaternion.identity);
            myTrap.Add(clone);
        }

        //������ ����
        for (int i = 0; i < gamedata.collectableCount + currentStage.CollectableAddCount; i++)
        {
            GameObject clone = Instantiate(CollectablePrefab[UnityEngine.Random.Range(0, CollectablePrefab.Length)],
                               trapCollectableParent.position, Quaternion.identity);
            myItem.Add(clone);
        }

        //�����ϱ�
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
        for (int zRow = 0; zRow < gamedata.verticalCount; zRow++)   //���� ����
        {
            for (int xRow = 0; xRow < gamedata.horizontalCount; xRow++) //���� ����
            {
                int randomTileIndex = UnityEngine.Random.Range(0, GroundPrefabs.Length);  //������ Ÿ�� ������ ����
                GameObject randomTile = GroundPrefabs[randomTileIndex];

                int randomRotationAngle = UnityEngine.Random.Range(0, 4) * 90;  //90�� �������� ������ ���� ����
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
        for (int i = 0; i < InstansCount; i++)//���Ʈ��
        {
            int xPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// ���� ��ġ ����
            int yPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);


            Quaternion randomRotation = Quaternion.Euler(0f, 0f, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, InstantKillTrapPrefab.Length);// ���� Ʈ�� ����
            GameObject randomTrap = InstantKillTrapPrefab[randomTrapIndex];

            Instantiate(randomTrap, randomPosition, randomRotation, trapCollectableParent);
        }

        for (int i = 0; i < NomalCount; i++)//�븻Ʈ��
        {
            int xPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// ���� ��ġ ����
            int yPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            Quaternion randomRotation = Quaternion.Euler(0f, 0f, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, nomalTrapPrefabs.Length);// ���� Ʈ�� ����
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