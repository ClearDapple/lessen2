using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameData gamedata;

    [SerializeField] private Transform groundParent; // Ÿ�� �θ�

    public GameObject[] tilePrefabs;            //����� Ÿ�� ������ �迭



    public void CreatGround()
    {
        for (int zRow = 0; zRow < gamedata.verticalCount; zRow++)//���� ����
        {
            for (int xRow = 0; xRow < gamedata.horizontalCount; xRow++)//���� ����
            {
                int randomTileIndex = UnityEngine.Random.Range(0, tilePrefabs.Length);//������ Ÿ�� ������ ����
                GameObject randomTile = tilePrefabs[randomTileIndex];

                int randomRotationAngle = UnityEngine.Random.Range(0, 4) * 90;//90�� �������� ������ ���� ����
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
}