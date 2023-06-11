using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Assault : MonoBehaviour, IEnemyState
{
    EnemyState state = new();
    EnemyStatus status;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<EnemyStatus>();

        Normal();
    }

    void Update()
    {
        //Aggressiveà⁄çs
        if (state.state == EnemyState.State.Normal
            && Vector3.Distance(transform.position, status.target.transform.position) <= status.activeDistance)
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
        agent.SetDestination(status.target.transform.position);
    }

    public void Negative()
    {
    }

    public void Normal()
    {
        if (state.state == EnemyState.State.Normal)
            return;

        state.state = EnemyState.State.Normal;
    }

    void Action()
    {
        agent.SetDestination(status.target.transform.position);
    }
}