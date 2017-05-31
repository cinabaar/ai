using UnityEngine;

public struct Damage
{
    public float Amount;
    public Vector3 Direction;
    public GameObject Instigator;
}

public interface ITakeDamage
{
    void ApplyDamage(Damage damage);
}