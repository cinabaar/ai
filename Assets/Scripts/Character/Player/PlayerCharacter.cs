using UnityEngine;

public class PlayerCharacter : Character
{
    protected override void Kill(Damage damage)
    {
        base.Kill(damage);
        Destroy(gameObject);
    }
}
