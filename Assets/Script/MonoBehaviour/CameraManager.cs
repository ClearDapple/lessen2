using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Player player;
    public Camera camera;

    private Vector3 playerPos;

    void Update()
    {
        playerPos = player.transform.position;
        camera.transform.position = new Vector3(playerPos.x, playerPos.y+5, playerPos.z - 10);
    }
}
