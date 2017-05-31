using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class CleanupDestructible : MonoBehaviour
{
    [SerializeField]
    private float _disableAfterTime;

    private Rigidbody[] _rigidBodies;

    public void Start()
    {
        _rigidBodies = GetComponentsInChildren<Rigidbody>();
        StartCoroutine(DetectCleanup());
    }

    private IEnumerator DetectCleanup()
    {
        do
        {
            yield return new WaitForSeconds(0.2f);
        } while (_rigidBodies.Select(x => x.velocity.magnitude).Max() > 0.2f && _rigidBodies.Select(x => x.transform.position.y).Min() > -50f);
        yield return StartCoroutine(PerformCleanup(_disableAfterTime));
    }

    public IEnumerator PerformCleanup(float dissolveTime)
    {
        foreach(Transform t in transform)
        {
            t.GetComponent<Rigidbody>().isKinematic = true;
            t.GetComponent<Collider>().enabled = false;
        }
        yield return StartCoroutine(AlphaFade(dissolveTime));
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    public IEnumerator AlphaFade(float time)
    {
        var renderers = GetComponentsInChildren<Renderer>();
        float accum = 0;
        while(true)
        {
            accum += Time.deltaTime;
            foreach(var renderer in renderers)
            {
                var color = renderer.material.color;
                renderer.material.color = new Color(color.r, color.g, color.b, Mathf.Lerp(1, 0, 1 - color.a + Time.deltaTime/time));
            }
            if (accum > time)
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}