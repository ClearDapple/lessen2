using UnityEngine;

public class Trap : MonoBehaviour
{
    public Player player;

    private Rigidbody rigid;
    private MeshCollider mesh;
    public int Demege = -10;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshCollider>();
        mesh.enabled = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mesh.enabled = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mesh.enabled = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            player.AddHP(Demege);
        }
    }
}