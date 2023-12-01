using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBaseState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("This is EnterState from EnterBaseState");
        BaseHP.baseHp--;
        Debug.Log("Base Hp" + BaseHP.baseHp.ToString());
        enemy.DestroyEnemy();
    }
    public override void UpdateState(EnemyStateManager enemy)
    {

    }
    public override void HitState(EnemyStateManager enemy, Collider other)
    {


    }
}
