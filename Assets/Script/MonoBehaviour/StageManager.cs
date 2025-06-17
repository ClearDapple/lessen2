using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameData gamedata;

    //[SerializeField] GameObject[] _Trap;
    //[SerializeField] Transform[] _position;
    //[SerializeField] Transform _parent;
    //[SerializeField] Transform _3DTiles;
    [SerializeField] GameObject _collectable;//item
    //[SerializeField] Transform _startPoint;//시작지점
    //[SerializeField] Transform _ClearPoint;//종료지점

    //

    [SerializeField] private Transform groundParent;    // 타일 부모

    public GameObject[] GroundPrefabs;    //사용할 타일 프리팹 배열

    //

    [SerializeField] private Transform trapParent;   // 트랩 부모

    public GameObject[] nomalTrapPrefabs;       //사용할 트랩 프리팹 배열
    public GameObject[] InstantKillTrapPrefab;    //사용할 즉사 트랩 프리팹 배열

    //

    private void Start()
    {
        UIManager.OnGameStartEvent += UIManager_OnGameStartEvent;
    }

    private void UIManager_OnGameStartEvent()
    {
        DeleteGround();
        DeleteTrap();
        //CreatGround();
        //CreateTrap();
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

        for (int i = 0; i < gamedata.nomalTrapCount; i++)//노말트랩
        {
            float xPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// 랜덤 위치 생성
            float yPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            //int randomRotationAngle = UnityEngine.Random.Range(0, 360); //랜덤한 방향 설정
            //Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, nomalTrapPrefabs.Length);// 랜덤 트랩 선택
            GameObject randomTrap = nomalTrapPrefabs[randomTrapIndex];

            Instantiate(randomTrap, randomPosition, randomRotation, trapParent);
        }

        for (int i = 0; i < gamedata.instantKillTrapCount; i++)//즉사트랩
        {
            float xPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// 랜덤 위치 생성
            float yPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            //int randomRotationAngle = UnityEngine.Random.Range(0, 360); //랜덤한 방향 설정
            //Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, InstantKillTrapPrefab.Length);// 랜덤 트랩 선택
            GameObject randomTrap = InstantKillTrapPrefab[randomTrapIndex];

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
}