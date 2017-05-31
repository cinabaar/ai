using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ShooterAI : MonoBehaviour
{
    private NavMeshAgent _agent;

    private GameObject _player;

	void Start ()
    {
        _player = GameObject.Find("Player");
        _agent = GetComponent<NavMeshAgent>();
        StartCoroutine(new FindAndGoToRandomLocationBehavior().FindAndGoToRandomLocation(_agent, 3));
        StartCoroutine(ShootBullets(6f));
        StartCoroutine(new LookAtTargetBehavior().LookAtTarget(_agent, _player));
    }

    private IEnumerator ShootBullets(float cooldown)
    {
        var fireAttack = GetComponent<EnemyFireAttack>();
        while (_agent && _player)
        {
            yield return StartCoroutine(fireAttack.ShootBullets());
            yield return new WaitForSeconds(cooldown);
        }
    }
}
