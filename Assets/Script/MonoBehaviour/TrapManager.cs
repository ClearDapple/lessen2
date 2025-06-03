using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [SerializeField] GameData gamedata;

    [SerializeField] private Transform trapParent;   // Ʈ�� �θ�

    public GameObject[] nomalTrapPrefabs;       //����� Ʈ�� ������ �迭
    public GameObject[] InstantKillTrapPrefab;    //����� ��� Ʈ�� ������ �迭


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