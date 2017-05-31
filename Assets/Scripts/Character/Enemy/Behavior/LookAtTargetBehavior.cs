using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class LookAtTargetBehavior
{
    public IEnumerator LookAtTarget(NavMeshAgent navAgent, GameObject target)
    {
        navAgent.updateRotation = false;
        while (true && navAgent.gameObject && target)
        {
            navAgent.transform.LookAt(target.transform);
            yield return new WaitForEndOfFrame();
        }
    }
}