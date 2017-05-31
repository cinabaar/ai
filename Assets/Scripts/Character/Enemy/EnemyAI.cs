using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    protected NavMeshAgent _agent;
    protected GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
        _agent = GetComponent<NavMeshAgent>();
        RunAI();
    }

    protected virtual void RunAI() { }
}
