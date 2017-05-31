using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ShielderAI : EnemyAI
{
    public Transform ShieldRPivot;
    public Transform ShieldLPivot;

    protected override void RunAI()
    {
        StartCoroutine(new MoveToPlayer().FollowTarget(_agent, _player.transform));
        StartCoroutine(new LookAtTargetBehavior().LookAtTarget(_agent, _player));
        StartCoroutine(ActivateDefenses());
    }

    private IEnumerator ActivateDefenses()
    {
        while (true)
        {
            ShieldRPivot.DOLocalRotate(new Vector3(0, -64, 0), 1, RotateMode.Fast);
            ShieldLPivot.DOLocalRotate(new Vector3(0, 64, 0), 1, RotateMode.Fast);
            yield return new WaitForSeconds(2);
            ShieldRPivot.DOLocalRotate(new Vector3(0, 0, 0), 1, RotateMode.Fast);
            ShieldLPivot.DOLocalRotate(new Vector3(0, 0, 0), 1, RotateMode.Fast);
            yield return new WaitForSeconds(2);
        }
    }

}