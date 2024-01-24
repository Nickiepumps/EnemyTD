using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class WalkState : CharacterState
{
    Animator anim;
    public int PlayerAct;
    public WalkState(Player Player) : base(Player) { }

    public override void EnterState()
    {
        
    }


    public override void Update()

    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0, 0) * Player.moveSpeed;
        Player.SetVelocity(movement);


        if (horizontalInput == 0)
        {
            Player.TransitionToState(new IdleState(Player));
        }
        if (Input.GetButtonDown("Jump"))
        {
            Player.TransitionState(new JumpState(Player));
        }



    }
}

// ท่าทางการเดินหรือวิ่งของตัวละครผู้เล่น ให้สามารถเดินได้ในทิศทาง ด้านหน้า ด้านหลัง ซ้ายและขวา