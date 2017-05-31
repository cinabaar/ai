using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GrenadierAI : EnemyAI
{
    protected override void RunAI()
    {
        StartCoroutine(new FindAndGoToRandomLocationBehavior().FindAndGoToRandomLocation(_agent, 4f));
        StartCoroutine(new LookAtTargetBehavior().LookAtTarget(_agent, _player));
        StartCoroutine(RandomlyThrowGrenade());
    }

    private IEnumerator RandomlyThrowGrenade()
    {
        while(true)
        {
            var grenadeAttack = GetComponent<EnemyGrenadeAttack>();
            grenadeAttack.Attack(_player);
            yield return new WaitForSeconds(Random.Range(3f, 5f));
        }
    }
}
