using System.Collections;
using UnityEngine;

public class SlowTrap : BaseTrap
{
    public override void PlayerHitEffect()
    {
        playerdata.moveSpeed = playerdata.slowMoveSpeed;

        StartCoroutine(PlayerMoveSpeedReturn(gamedata.slowDelayTime));
        
        IEnumerator PlayerMoveSpeedReturn(float delay)
        {
            yield return new WaitForSeconds(delay);
            playerdata.moveSpeed = playerdata.nomalMoveSpeed;
        }
    }
}