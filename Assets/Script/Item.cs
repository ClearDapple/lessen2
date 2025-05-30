using UnityEngine;

public class Item : MonoBehaviour
{
    public Player player;

    public int Heal = 10;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.AddHP(Heal);
            Destroy(gameObject);
        }
    }
}