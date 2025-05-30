using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public TileManager tilemanager;

    [SerializeField] private Transform trapParent;   // Ʈ�� �θ�

    public GameObject[] nomalTrapPrefabs;       //����� Ʈ�� ������ �迭
    public GameObject InstantKillTrapPrefab;    //����� ��� Ʈ�� ������ �迭

    public int nomalTrapCount = 10;
    public int InstantKillTrapCount = 3;
    public float xPosNullTrap = 3f;             //Ʈ�� �̹߻� x��ġ


    public void CreateTrap()
    {
        for (int i = 0; i < nomalTrapCount; i++)
        {
            float xPos = UnityEngine.Random.Range(xPosNullTrap, tilemanager.horizontalCount * tilemanager.tileSpacing);// ���� ��ġ ����
            float yPos = UnityEngine.Random.Range(xPosNullTrap, tilemanager.verticalCount * tilemanager.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            int randomRotationAngle = UnityEngine.Random.Range(0, 360); //������ ���� ����
            Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);

            int randomTrapIndex = UnityEngine.Random.Range(0, nomalTrapPrefabs.Length);// ���� Ʈ�� ����
            GameObject selectedTrap = nomalTrapPrefabs[randomTrapIndex];

            Instantiate(selectedTrap, randomPosition, randomRotation, trapParent);
        }

        for (int i = 0; i < InstantKillTrapCount; i++)
        {
            float xPos = UnityEngine.Random.Range(xPosNullTrap, tilemanager.horizontalCount * tilemanager.tileSpacing);// ���� ��ġ ����
            float yPos = UnityEngine.Random.Range(xPosNullTrap, tilemanager.verticalCount * tilemanager.tileSpacing);
            float zPos = 3f;
            Vector3 randomPosition = new Vector3(xPos, yPos, zPos);

            int randomRotationAngle = UnityEngine.Random.Range(0, 360); //������ ���� ����
            Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);

            Instantiate(InstantKillTrapPrefab, randomPosition, randomRotation, trapParent);
        }
    }
}
