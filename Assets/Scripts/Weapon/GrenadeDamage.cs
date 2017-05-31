using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDamage : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _explosion;
    [SerializeField]
    private float _damageRadius = 2;
    [SerializeField]
    private float _damage;

    public GameObject ThrownBy { get; set; }

	void Start ()
    {
        StartCoroutine(ExplodeAfterSeconds(2f));    		
	}

    private IEnumerator ExplodeAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        var explosion = Instantiate(_explosion.gameObject, transform.position + _explosion.transform.position, _explosion.transform.rotation);
        explosion.GetComponent<ParticleSystem>().Play();
        var colliders = Physics.OverlapSphere(transform.position, _damageRadius);
        var affectedObjects = new List<ITakeDamage>();
        DebugExtensions.DebugDrawCircle(transform.position + Vector3.up, _damageRadius, 3);
        foreach(var collider in colliders)
        {
            var objectsTakingDamage = collider.gameObject.GetComponentsInChildren<ITakeDamage>();
            foreach (var takeDamage in objectsTakingDamage)
            {
                if (affectedObjects.Contains(takeDamage))
                    continue;
                takeDamage.ApplyDamage(new Damage { Amount = _damage, Direction = (transform.position - collider.transform.position).normalized, Instigator = ThrownBy });
                affectedObjects.Add(takeDamage);
            }
        }
        Destroy(gameObject);
        Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.duration);
    }
}
