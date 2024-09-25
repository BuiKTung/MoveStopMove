using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Characters
{
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] private float roamRadius = 10f;
    [SerializeField] public float randomTime = 2f;
    private Vector3 destination;
    private IState currentState;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        OnInnit();
    }
    private void Update()
    {
        CheckListTarget();
        if (currentState != null)
            currentState.OnExecute(this);
    }
    public void MoveToRandomPoint()
    {
        if (canMove)
        {
            Vector3 randomDir = Random.insideUnitSphere * roamRadius;
            randomDir += transform.position;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDir, out hit, roamRadius, NavMesh.AllAreas))
            {
                destination = hit.position;
                agent.SetDestination(destination);
            }
            ChangeAnim(ConstanString.anim_Run);
        }
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    public void StopMoving()
    {
        destination = transform.position;
        agent.SetDestination(destination);
        this.ChangeAnim(ConstanString.anim_Idle);
    }
    public void StartAttack()
    {
        StartCoroutine(Attack_Corotine());
    }
    public override void OnInnit()
    {
        int random = Random.Range(1, 3);
        currentWeaponType = (WeaponType)random;
        base.OnInnit();
        ChangeState(new IdleState());
    }
    public override void onDeath()
    {
        base.onDeath();
    }
}
