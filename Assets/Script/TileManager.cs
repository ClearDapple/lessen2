using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Transform groundParent; // 타일 부모

    public GameObject[] tilePrefabs;            //사용할 타일 프리팹 배열

    public int horizontalCount = 30;    //가로 개수
    public int verticalCount = 5;       //세로 개수
    public float tileSpacing = 2f;      //프리팹 사이의 간격

    public void CreatGround()
    {
        for (int zRow = 0; zRow < verticalCount; zRow++)//세로 범위
        {
            for (int xRow = 0; xRow < horizontalCount; xRow++)//가로 범위
            {
                int randomTileIndex = UnityEngine.Random.Range(0, tilePrefabs.Length);//랜덤한 타일 프리팹 선택
                GameObject randomTile = tilePrefabs[randomTileIndex];

                int randomRotationAngle = UnityEngine.Random.Range(0, 4) * 90;//90도 간격으로 랜덤한 방향 설정
                Quaternion randomRotation = Quaternion.Euler(0f, randomRotationAngle, 0f);

                float xPos = xRow * tileSpacing;
                float zPos = zRow * tileSpacing;
                Vector3 spawnPosition = new Vector3(xPos, 0f, zPos);

                Instantiate(randomTile, spawnPosition, randomRotation, groundParent);
            }
        }
    }
}
