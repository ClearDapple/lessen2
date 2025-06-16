using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameData gamedata;

    [SerializeField] GameObject[] _Trap;
    [SerializeField] Transform[] _position;
    [SerializeField] Transform _parent;
    [SerializeField] Transform _3DTiles;
    [SerializeField] GameObject _collectable;//item
    [SerializeField] Transform _startPoint;//��������
    [SerializeField] Transform _ClearPoint;//��������

    //

    [SerializeField] private Transform groundParent;    // Ÿ�� �θ�

    public GameObject[] tilePrefabs;    //����� Ÿ�� ������ �迭

    //

    [SerializeField] private Transform trapParent;   // Ʈ�� �θ�

    public GameObject[] nomalTrapPrefabs;       //����� Ʈ�� ������ �迭
    public GameObject[] InstantKillTrapPrefab;    //����� ��� Ʈ�� ������ �迭

    //

    private void Start()
    {
        _3DTiles.transform.Clear();
        _parent.transform.Clear();

    }

    //

    public void CreatGround()
    {
        for (int zRow = 0; zRow < gamedata.verticalCount; zRow++)   //���� ����
        {
            for (int xRow = 0; xRow < gamedata.horizontalCount; xRow++) //���� ����
            {
                int randomTileIndex = UnityEngine.Random.Range(0, tilePrefabs.Length);  //������ Ÿ�� ������ ����
                GameObject randomTile = tilePrefabs[randomTileIndex];

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
        for (int i = 0; i < gamedata.nomalTrapCount; i++)//�븻Ʈ��
        {
            float xPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// ���� ��ġ ����
            float yPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            int randomRotationAngle = UnityEngine.Random.Range(0, 360); //������ ���� ����
            Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, nomalTrapPrefabs.Length);// ���� Ʈ�� ����
            GameObject randomTrap = nomalTrapPrefabs[randomTrapIndex];

            Instantiate(randomTrap, randomPosition, randomRotation, trapParent);
        }

        for (int i = 0; i < gamedata.instantKillTrapCount; i++)//���Ʈ��
        {
            float xPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.horizontalCount * gamedata.tileSpacing);// ���� ��ġ ����
            float yPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, gamedata.verticalCount * gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            int randomRotationAngle = UnityEngine.Random.Range(0, 360); //������ ���� ����
            Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, InstantKillTrapPrefab.Length);// ���� Ʈ�� ����
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