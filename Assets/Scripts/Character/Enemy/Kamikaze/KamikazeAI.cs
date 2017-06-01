using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class KamikazeAI : EnemyAI
{
    public ParticleSystem Explosion;
    [SerializeField]
    private float _damageRadius;
    [SerializeField]
    private float _damage;

    protected override void RunAI()
    {
        StartCoroutine(new MoveToPlayer().FollowTarget(_agent, _player.transform));
        StartCoroutine(new LookAtTargetBehavior().LookAtTarget(_agent, _player));
        StartCoroutine(ExplodeNextToPlayer());
    }

    private IEnumerator ExplodeNextToPlayer()
    {
        while(_player && (_player.transform.position - transform.position).magnitude > 2)
        {
            yield return new WaitForEndOfFrame();
        }
        var enemyChar = GetComponent<EnemyCharacter>();
        if (!enemyChar) yield break;
        var explosion = Instantiate(Explosion.gameObject, transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();
        enemyChar.Kill(new Damage { Amount = 100, Direction = Vector3.down * 10, Instigator = gameObject });
        var colliders = Physics.OverlapSphere(transform.position, _damageRadius);
        var affectedObjects = new List<ITakeDamage>();
        DebugExtensions.DebugDrawCircle(transform.position + Vector3.up, _damageRadius, 3);
        foreach (var collider in colliders)
        {
            var objectsTakingDamage = collider.gameObject.GetComponentsInChildren<ITakeDamage>();
            foreach (var takeDamage in objectsTakingDamage)
            {
                if (affectedObjects.Contains(takeDamage))
                    continue;
                takeDamage.ApplyDamage(new Damage { Amount = _damage, Direction = (transform.position - collider.transform.position).normalized, Instigator = gameObject });
                affectedObjects.Add(takeDamage);
            }
        }
        Destroy(explosion, 2);
    }
}
