using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    { 
        Debug.Log("This is EnterState from DestroyState");
        enemy.DestroyEnemy();
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        
    }
    public override void HitState(EnemyStateManager enemy, Collider other)
    {
        
        
    }
}
