using System;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float DamageAmount;

    [NonSerialized]
    public GameObject Instigator;

    private Rigidbody _rigidBody;

    public void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        var takeDamageInterface = other.gameObject.GetComponent<ITakeDamage>();
        if (takeDamageInterface != null)
        {
            takeDamageInterface.ApplyDamage(new Damage()
            {
                Amount = DamageAmount,
                Direction = _rigidBody.velocity.normalized,
                Instigator = Instigator
            });
        }
        Destroy(gameObject);
    }
}
