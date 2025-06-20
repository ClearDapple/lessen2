using UnityEngine;

public class InstantKillTrap : BaseTrap
{
    public override void PlayerHitEffect()
    {
        playerdata.UpdateHP(playerdata.minHP);
    }
}