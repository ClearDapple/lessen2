using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public GameData gamedata;
    public TileManager tilemanager;

    [SerializeField] private Transform trapParent;   // Ʈ�� �θ�

    public GameObject[] nomalTrapPrefabs;       //����� Ʈ�� ������ �迭
    public GameObject InstantKillTrapPrefab;    //����� ��� Ʈ�� ������ �迭



    public void CreateTrap()
    {
        for (int i = 0; i < gamedata.nomalTrapCount; i++)
        {
            float xPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, tilemanager.gamedata.horizontalCount * tilemanager.gamedata.tileSpacing);// ���� ��ġ ����
            float yPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, tilemanager.gamedata.verticalCount * tilemanager.gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            int randomRotationAngle = UnityEngine.Random.Range(0, 360); //������ ���� ����
            Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, nomalTrapPrefabs.Length);// ���� Ʈ�� ����
            GameObject selectedTrap = nomalTrapPrefabs[randomTrapIndex];

            Instantiate(selectedTrap, randomPosition, randomRotation, trapParent);
        }

        for (int i = 0; i < gamedata.instantKillTrapCount; i++)
        {
            float xPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, tilemanager.gamedata.horizontalCount * tilemanager.gamedata.tileSpacing);// ���� ��ġ ����
            float yPos = UnityEngine.Random.Range(gamedata.xPosNullTrap, tilemanager.gamedata.verticalCount * tilemanager.gamedata.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            int randomRotationAngle = UnityEngine.Random.Range(0, 360); //������ ���� ����
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