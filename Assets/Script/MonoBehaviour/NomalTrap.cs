using UnityEngine;

public class NomalTrap : BaseTrap
{
    public override void PlayerHitEffect()
    {
        playerdata.HP -= gamedata.Demege;
    }
}