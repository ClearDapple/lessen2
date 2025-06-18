using System;
using UnityEngine;

public class KnockBackTrap : BaseTrap
{
    public static event Action OnKnockBackEvent;

    public override void PlayerHitEffect()
    {
        OnKnockBackEvent?.Invoke();
    }
}