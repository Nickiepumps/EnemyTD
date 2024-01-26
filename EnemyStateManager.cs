using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : Subject
{
    EnemyBaseState currentState;
    [SerializeField] public float EnemySpeed = 5f; // ความเร็วการเคลื่อนที่ของ Enemy
    [SerializeField] public float currentEnemyHP, maxEnemyHp = 2f; // เก็บค่าเลือดปัจจุบัน และค่าเลือดสูงสุดของศัตรู
    public Transform waypointTarget; // เป้าหมายที่ต้องเดินไปหา
    public int waypointIndex = 0; // หมายเลขเป้าหมาย = 0
    public int currentWaypointIndex;// เป้าหมายปัจจุบัน
    private void Start()
    {
        currentState = new SpawnState(this);
        currentState.EnterState();
        currentEnemyHP = maxEnemyHp; // เลือดซอมบี้ = เลือดสูงสุด 
    }
    private void Update()
    {
        currentState.UpdateState();
        currentWaypointIndex = waypointIndex; // เป้าหมายปัจจุบัน = หมายเลขเป้าหมาย
    }

    private void OnTriggerEnter(Collider other) // State ที่ใช้ตอน Enemy ชน trigger ใดๆ ใน Scene
    {
        currentState.HitState(other);
    }
    public void ChangeState(EnemyBaseState newState)
    {
        currentState = newState;
        newState.EnterState();
    }

    public void DestroyEnemy() // ทำลาย GameObject Enemy
    {
        Debug.Log("Dead");
        NotifyObservers(EnemyAction.Dead); // เเจ้ง Observer ว่าตายเเล้ว
        Destroy(gameObject); // ทำลาย GameObject enemy     
        return;
    }
    public void EnterBase()
    {

        Debug.Log("Enemy is Enter your Base");
        Destroy(gameObject); // ทำลาย GameObject enemy     
        return;
    }
    public void GetNextWaypoint() // ไป Waypoint ต่อไป
    {
        waypointIndex++; // เพิ่มค่า waypointIndex +1
        waypointTarget = Waypoint.Waypoints[waypointIndex]; // waypoint ต่อไปที่ enemy จะเดินไปหาคือ waypoint หมายเลขเดียวกับ waypointIndex
    }
    


}
