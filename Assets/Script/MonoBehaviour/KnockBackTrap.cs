using UnityEngine;

public class KnockBackTrap : BaseTrap
{

    //public virtual void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        rigid.constraints = RigidbodyConstraints.FreezeAll;
    //    }

    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Vector3 direction = collision.transform.position - transform.position;
    //        direction.y = 0; // Y�� ������ �����Ͽ� �������θ� ƨ�ܳ�
    //                         // ƨ�ܳ� �������� ���� ����
    //        collision.gameObject.AddForce(direction.normalized * pushBackForce, ForceMode.Impulse);
    //        OnHitAudio?.Invoke(myType);
    //    }
    //}   
}