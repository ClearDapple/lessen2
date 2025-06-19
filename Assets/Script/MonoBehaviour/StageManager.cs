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
    //[SerializeField] Transform _startPoint;//��������
    //[SerializeField] Transform _ClearPoint;//��������
    [SerializeField] private Transform groundParent;        // Ÿ�� �θ�
    [SerializeField] private Transform trapParent;          // Ʈ�� �θ�
    [SerializeField] private Transform collectableParent;   // ������ �θ�
    [SerializeField] private Transform clearPointParent;    // Ŭ��������Ʈ �θ�

    public GameObject[] GroundPrefabs;          //����� Ÿ�� ������ �迭

    public GameObject[] InstantKillTrapPrefab;  //����� ��� Ʈ�� ������ �迭
    public GameObject[] nomalTrapPrefabs;       //����� �븻 Ʈ�� ������ �迭

    public GameObject[] CollectablePrefab;      //����� ������ ������ �迭

    public GameObject _ClearPoint;              //����� Ŭ��������Ʈ ������

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
    //    int xPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// ���� ��ġ ����
    //    int yPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
    //    float zPos = 3f;
    //    Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

    //    //int randomRotationAngle = UnityEngine.Random.Range(0, 360); //������ ���� ����
    //    //Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);
    //    Quaternion randomRotation = Quaternion.Euler(0f, 0f, 0f);

    //    int randomTrapIndex = UnityEngine.Random.Range(0, nomalTrapPrefabs.Length);// ���� Ʈ�� ����
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


        for (int i = 0; i < gamedata.instantKillTrapCount + currentStageLevel.NomalTrapAddCount; i++)//���Ʈ��
        {
            int xPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// ���� ��ġ ����
            int yPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            //int randomRotationAngle = UnityEngine.Random.Range(0, 360); //������ ���� ����
            //Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, InstantKillTrapPrefab.Length);// ���� Ʈ�� ����
            GameObject randomTrap = InstantKillTrapPrefab[randomTrapIndex];

            Instantiate(randomTrap, randomPosition, randomRotation, trapParent);
        }
        for (int i = 0; i < gamedata.nomalTrapCount+ currentStageLevel.InstansKillTrapAddCount; i++)//�븻Ʈ��
        {
            int xPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// ���� ��ġ ����
            int yPos = (int)UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            //int randomRotationAngle = UnityEngine.Random.Range(0, 360); //������ ���� ����
            //Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, nomalTrapPrefabs.Length);// ���� Ʈ�� ����
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