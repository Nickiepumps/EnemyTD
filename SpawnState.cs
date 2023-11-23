using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Test from SpawnState");
        enemy.ChangeState(enemy.moveState);

    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        
    }
    public override void ExitState(EnemyStateManager enemy)
    {

    }
}
