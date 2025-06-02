using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public GameData gamedata;
    public TileManager tilemanager;

    [SerializeField] private Transform trapParent;   // 트랩 부모

    public GameObject[] nomalTrapPrefabs;       //사용할 트랩 프리팹 배열
    public GameObject InstantKillTrapPrefab;    //사용할 즉사 트랩 프리팹 배열



    public void CreateTrap()
    {
        for (int i = 0; i < gamedata.nomalTrapCount; i++)
        {
            float xPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, tilemanager.gamedata.horizontalCount * tilemanager.gamedata.tileSpacing);// 랜덤 위치 생성
            float yPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, tilemanager.gamedata.verticalCount * tilemanager.gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            int randomRotationAngle = UnityEngine.Random.Range(0, 360); //랜덤한 방향 설정
            Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, nomalTrapPrefabs.Length);// 랜덤 트랩 선택
            GameObject selectedTrap = nomalTrapPrefabs[randomTrapIndex];

            Instantiate(selectedTrap, randomPosition, randomRotation, trapParent);
        }

        for (int i = 0; i < gamedata.instantKillTrapCount; i++)
        {
            float xPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, tilemanager.gamedata.horizontalCount * tilemanager.gamedata.tileSpacing);// 랜덤 위치 생성
            float yPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, tilemanager.gamedata.verticalCount * tilemanager.gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            int randomRotationAngle = UnityEngine.Random.Range(0, 360); //랜덤한 방향 설정
            Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);

            Instantiate(InstantKillTrapPrefab, randomPosition, randomRotation, trapParent);
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