using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Assault : MonoBehaviour, IEnemyState
{
    EnemyState state = new();
    EnemyStatus status;
    NavMeshAgent agent;
    GameObject target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<EnemyStatus>();
        target = GameObject.FindGameObjectWithTag("Player");

        Normal();
    }

    void Update()
    {
        //Aggressiveà⁄çs
        if (state.state == EnemyState.State.Normal
            && Vector3.Distance(transform.position, target.transform.position) <= status.activeDistance)
        {
            Aggressive();
        }

        if(state.state == EnemyState.State.Aggressive)
        {
            Action();
        }
    }

    public void Aggressive()
    {
        if (state.state == EnemyState.State.Aggressive)
            return;

        state.state = EnemyState.State.Aggressive;
        agent.SetDestination(target.transform.position);
    }

    public void Normal()
    {
        if (state.state == EnemyState.State.Normal)
            return;

        state.state = EnemyState.State.Normal;
    }

    void Action()
    {
        agent.SetDestination(target.transform.position);
    }
}