using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class FindAndGoToRandomLocationBehavior
{
    public IEnumerator FindAndGoToRandomLocation(NavMeshAgent navAgent, float changeLocationTime)
    {
        while (true && navAgent.gameObject)
        {
            NavMeshHit hit;
            NavMesh.SamplePosition(navAgent.transform.position + Random.onUnitSphere * 10, out hit, 20, NavMesh.AllAreas);
            if (hit.hit)
            {
                navAgent.SetDestination(hit.position);
            }
            yield return new WaitForSeconds(changeLocationTime);
        }
    }
}