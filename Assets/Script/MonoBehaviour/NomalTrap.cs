using UnityEngine;

public class NomalTrap : BaseTrap
{
    public override void PlayerHitEffect()
    {
        playerdata.UpdateHP(playerdata.HP - gamedata.damege);
    }
}