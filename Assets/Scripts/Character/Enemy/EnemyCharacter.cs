using UnityEngine;

public class EnemyCharacter : Character
{
    public GameObject SpawnOnDeath;

    protected override void Kill(Damage damage)
    {
        base.Kill(damage);
        Destroy(gameObject);
        var spawnOnDeath = Instantiate(SpawnOnDeath, transform.position, transform.rotation);
        var rigidBodies = spawnOnDeath.GetComponentsInChildren<Rigidbody>();
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.AddForce(damage.Direction * 5, ForceMode.Impulse);
        }
    }
}