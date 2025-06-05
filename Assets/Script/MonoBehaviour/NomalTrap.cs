using UnityEngine;

public class NomalTrap : BaseTrap
{
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            base.OnCollisionEnter(collision);
            //데미지 부여;
        }
    }
}