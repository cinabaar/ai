using UnityEngine;

public class PlayerCharacter : Character
{
    public override void Kill(Damage damage)
    {
        base.Kill(damage);
        Destroy(gameObject);
    }
}
