using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyStatus), typeof(EnemyWeapon), typeof(TacticalPositionSearch))]
public class Infantry : MonoBehaviour, IEnemyState
{
    EnemyState state = new();
    EnemyStatus status;
    TacticalPositionSearch tacticalPosition;
    NavMeshAgent agent;

    private void Start()
    {
        tacticalPosition = GetComponent<TacticalPositionSearch>();
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<EnemyStatus>();

        Normal();
    }

    void Update()
    {
        //Aggressiveà⁄çs
        if (state.state == EnemyState.State.Normal
            && Vector3.Distance(transform.position, status.target.transform.position) <= 50)
        {
            Aggressive();
        }

        //çsìÆ
        Action();
    }

    public void Aggressive()
    {
        if (state.state == EnemyState.State.Aggressive)
            return;

        state.state = EnemyState.State.Aggressive;
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
        if (agent.destination != null 
            && Vector3.Distance(transform.position, agent.destination) <= 2)
        {
            GameObject pos = tacticalPosition.Search(status.target.transform, false, false);

            if(pos != null)
            {
                agent.SetDestination(pos.transform.position);
            }
        }
    }
}