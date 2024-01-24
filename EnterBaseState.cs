using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBaseState : EnemyBaseState
{
    public EnterBaseState(EnemyStateManager enemy) : base(enemy) { }
    public override void EnterState()
    {
        Debug.Log("This is EnterState from EnterBaseState");
        enemy.EnterBase();
    }
    public override void UpdateState()
    {

    }
    public override void HitState(Collider other)
    {


    }

}
