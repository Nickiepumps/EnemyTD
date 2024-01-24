using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnState : EnemyBaseState
{
    public SpawnState(EnemyStateManager enemy) : base(enemy) { }
    public override void EnterState()
    {
        Debug.Log("Test from SpawnState");
        enemy.ChangeState(new MoveState(enemy));
        enemy.NotifyObservers(EnemyAction.Spawn); // เเจ้ง Observer ว่าเกิดเเล้ว
        // To Do : Fade in GameObject

    }
    public override void UpdateState()
    {
       

    }
    public override void HitState(Collider other)
    {

    }
}
