using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : EnemyBaseState
{
    private Transform waypointTarget;
    private int waypointIndex = 0;
    public override void EnterState(EnemyStateManager enemy)
    {
        waypointTarget = Waypoint.Waypoints[0];
        Debug.Log("This is UpdateState from MovingState");
        
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        Vector3 dir = waypointTarget.position - enemy.transform.position;
        enemy.transform.Translate(dir.normalized * enemy.EnemySpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(enemy.transform.position, waypointTarget.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        if (waypointIndex >= Waypoint.Waypoints.Length - 1)
        {
            enemy.ChangeState(enemy.destroyState);
            
        }

    }
    public override void ExitState(EnemyStateManager enemy)
    {

    }
    public void GetNextWaypoint()
    {       
        waypointIndex++;
        waypointTarget = Waypoint.Waypoints[waypointIndex];
    }
}
