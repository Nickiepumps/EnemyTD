using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;
    public SpawnState spawnState = new SpawnState();
    public MoveState moveState = new MoveState();
    public DestroyState destroyState = new DestroyState();
    [SerializeField] public float EnemySpeed = 5f;

    private void Start()
    {
        currentState = spawnState;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
     
    }

    public void ChangeState(EnemyBaseState newState)
    {
        currentState = newState;
        newState.EnterState(this);
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
        return;

    }

}
