using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : EnemyBaseState
{
    public MoveState(EnemyStateManager enemy) : base(enemy) { }
    public override void EnterState()
    {
        enemy.waypointTarget = Waypoint.Waypoints[enemy.currentWaypointIndex]; // ตำเเหน่งที่ enemy ต้องไปโดยอิงมาจากตัวแปร currentWaypointIndex ที่เก็บค่า WaypointIndex
        Animator animator = enemy.GetComponent<Animator>();
        animator.SetBool("IsRunning", true);
        animator.SetBool("IsKicking", false);
        Debug.Log("This is UpdateState from MovingState");
        
    }
    public override void UpdateState()
    {
        enemy.NotifyObservers(EnemyAction.Walk); // เเจ้ง Observer ว่าเดินเเล้ว
        Vector3 dir = enemy.waypointTarget.position - enemy.transform.position; // ทิศทางที่ enemy ที่ต้องเคลื่อนที่ ใช้ผลลบตำเเหน่งจาก vector 3 ของ waypointTarget กับ enemy มาเก็บในตัวแปล vector3 ชื่อ dir
        enemy.transform.Translate(dir.normalized * enemy.EnemySpeed * Time.deltaTime, Space.World); // เคลื่อน enemy ไปตามทิศทางที่ตัวแปร vector3 dir ได้เก็บค่าไว้
        
        if (Vector3.Distance(enemy.transform.position, enemy.waypointTarget.position) <= 0.4f) // เช็คระยะห่างระหว่าง enemy กับ waypoint <= 0.4 หรือไม่ 
        {
            enemy.GetNextWaypoint(); // ถ้าระยะห่างระหว่าง enemy กับ waypoint ปัจจุบัน <= 0.4 ให้ใช้ฟังค์ชัน GetNextWaypoint จากตัว enemy
            enemy.transform.LookAt(enemy.waypointTarget.transform); // ให้ enemy หันหน้าไปทิศทางตำเเหน่งที่ Waypoint ต่อไปอยู่
        }

        if (enemy.waypointIndex >= Waypoint.Waypoints.Length - 1) // เช็คจำนวน waypointIndex ที่ enemy นับทีละ 1 เมื่อถึง waypoint ใหม่
        {
            enemy.ChangeState(new EnterBaseState(enemy)); // ถ้าจำนวน waypointIndex >= จำนวน waypoint ทั้งหมดที่มี scene - 1 ให้เปลี่ยน state เป็น EnterBaseState

        }

    }
    public override void HitState(Collider other)
    {
        GameObject arrow = other.gameObject; // ถ้า enemy ชน gameObject ที่มีเเท็ก Arrow ให้เปลี่ยน state เป็น DestroyState
        if (arrow.CompareTag("Arrow"))
        {         
            enemy.NotifyObservers(EnemyAction.BulletHit);
            enemy.currentEnemyHP -= 1;
            if (enemy.currentEnemyHP <= 0)
            {
                enemy.ChangeState(new DestroyState(enemy));
            }
        }
        GameObject player = other.gameObject; // ถ้า enemy ชน gameObject ที่มีเเท็ก Player ให้เปลี่ยน state เป็น AttackState
        if (player.gameObject.CompareTag("Player"))
        {
            enemy.ChangeState(new AttackState(enemy));
        }
    }

}
