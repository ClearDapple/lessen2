using UnityEngine;

public class ClearPoint : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //gamecleareventinvoke;
        }
    }
}
