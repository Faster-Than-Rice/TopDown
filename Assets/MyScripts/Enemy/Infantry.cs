using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyStatus), typeof(EnemyWeapon), typeof(TacticalPositionSearch))]
public class Infantry : MonoBehaviour, IEnemyState
{
    [SerializeField] float followingDistance;
    [SerializeField] bool isRandom;
    [SerializeField] bool isFar;
    EnemyState state = new();
    EnemyStatus status;
    TacticalPositionSearch tacticalPosition;
    NavMeshAgent agent;
    GameObject agentTarget;
    GameObject target;
    float counter;

    private void Start()
    {
        tacticalPosition = GetComponent<TacticalPositionSearch>();
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<EnemyStatus>();
        target = GameObject.FindGameObjectWithTag("Player");

        Normal();
    }

    void Update()
    {
        counter += Time.deltaTime;

        //Aggressiveà⁄çs
        if (state.state == EnemyState.State.Normal)
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

    public void Normal()
    {
        if (state.state == EnemyState.State.Normal)
            return;

        state.state = EnemyState.State.Normal;
    }

    void Action()
    {
        if (state.state == EnemyState.State.Aggressive 
            && (agent.destination == null || Vector3.Distance(transform.position, agent.destination) <= 10 || counter >= 3))
        {
            if(Vector3.Distance(transform.position, target.transform.position) <= followingDistance)
            {
                List<GameObject> pos = new(tacticalPosition.Search(target.transform));
                pos.RemoveAll(point => point == agentTarget);

                if (pos.Count != 0)
                {
                    if (isRandom)
                        agentTarget = MyUtility.GetRandom(pos);
                    else if (isFar)
                        agentTarget = pos[0];
                    else
                        agentTarget = pos[pos.Count - 1];

                    agent.SetDestination(agentTarget.transform.position);
                    counter = 0;
                }
            }
            else
            {
                agent.SetDestination(target.transform.position);
            }
        }
    }
}