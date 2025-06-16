using UnityEngine;

public class KnockBackTrap : BaseTrap
{

    //public override void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        rigid.constraints = RigidbodyConstraints.FreezeAll;
    //    }

    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Vector3 direction = collision.transform.position - transform.position;
    //        //direction.y = 0; // Y축 방향을 제거하여 수평으로만 튕겨냄
    //        // 튕겨낼 방향으로 힘을 가함
    //        collision.gameObject.AddForce(direction.normalized * gamedata.knockBackPower, ForceMode.Impulse);
    //        OnHitAudio?.Invoke(myType);
    //    }
    //}

    //public override void PlayerHitEffect()
    //{
    //    playerdata.moveSpeed = playerdata.SlowMoveSpeed;

    //    StartCoroutine(PlayerMoveSpeedReturn(gamedata.slowDelayTime));

    //    IEnumerator PlayerMoveSpeedReturn(float delay)
    //    {
    //        yield return new WaitForSeconds(delay);
    //        playerdata.moveSpeed = playerdata.nomalMoveSpeed;
    //    }
    //}
}