using UnityEngine;

public class Item : MonoBehaviour
{
    Player player;

    private Rigidbody rigid;
    private MeshCollider mesh;
    public int Heal = 10;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.AddHP(Heal);
            Destroy(gameObject);
        }
    }
}