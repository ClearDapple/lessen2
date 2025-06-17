using UnityEngine;

public class KnockBackTrap : BaseTrap
{
    public Player player;


    public override void PlayerHitEffect()
    {
        player.ApplyKnockback(gamedata.knockBackPower);  // 넉백 효과 적용
    }
}