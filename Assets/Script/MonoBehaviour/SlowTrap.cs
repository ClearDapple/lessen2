using System.Collections;
using UnityEngine;

public class SlowTrap : BaseTrap
{
    public override void PlayerHitEffect()
    {
        playerdata.moveSpeed = playerdata.SlowMoveSpeed;

        StartCoroutine(PlayerMoveSpeedReturn(gamedata.slowDelayTime));
        
        IEnumerator PlayerMoveSpeedReturn(float delay)
        {
            yield return new WaitForSeconds(delay);
            playerdata.moveSpeed = playerdata.nomalMoveSpeed;
        }
    }
}