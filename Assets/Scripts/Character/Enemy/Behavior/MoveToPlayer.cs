using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer
{
    public IEnumerator FollowTarget(NavMeshAgent navAgent, Transform target)
    {
        Vector3 previousTargetPosition = new Vector3(float.PositiveInfinity, float.PositiveInfinity);
        while (true)
        {
            // did target move more than at least a minimum amount since last destination set?
            if (Vector3.SqrMagnitude(previousTargetPosition - target.position) > 0.1f)
            {
                navAgent.SetDestination(target.position);
                previousTargetPosition = target.position;
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}