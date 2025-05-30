using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Transform groundParent; // Ÿ�� �θ�

    public GameObject[] tilePrefabs;            //����� Ÿ�� ������ �迭

    public int horizontalCount = 30;    //���� ����
    public int verticalCount = 5;       //���� ����
    public float tileSpacing = 2f;      //������ ������ ����

    public void CreatGround()
    {
        for (int zRow = 0; zRow < verticalCount; zRow++)//���� ����
        {
            for (int xRow = 0; xRow < horizontalCount; xRow++)//���� ����
            {
                int randomTileIndex = UnityEngine.Random.Range(0, tilePrefabs.Length);//������ Ÿ�� ������ ����
                GameObject randomTile = tilePrefabs[randomTileIndex];

                int randomRotationAngle = UnityEngine.Random.Range(0, 4) * 90;//90�� �������� ������ ���� ����
                Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);

                float xPos = xRow * tileSpacing;
                float zPos = zRow * tileSpacing;
                Vector3 spawnPosition = new Vector3(xPos, 0f, zPos);

                Instantiate(randomTile, spawnPosition, randomRotation, groundParent);
            }
        }
    }
}
