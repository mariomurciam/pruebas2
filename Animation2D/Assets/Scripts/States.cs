using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnIdle : State
{
    FMS fms;
    public OnIdle(FMS fms){
        this.fms = fms;
    }
    public void Enter(){
        fms.gm.mov.ac.SetTrigger("Idle");
        fms.gm.mov.jumps = 0;
    }
    public void Update(){
        if ((Input.GetKeyDown(KeyCode.Space)) && fms.gm.mov.jumps < fms.gm.mov.max_jump)
        {
            fms.OnNext(fms.jump);
        }
        if (fms.gm.mov.rb.velocity.y < 0 && fms.gm.mov.isGrounded() == false)
        {
            fms.OnNext(fms.fall);
        }
    }
    public void Exit(){

    }
}

public class OnJump : State
{
    FMS fms;
    public OnJump(FMS fms){
        this.fms = fms;
    }
    public void Enter(){
        fms.gm.mov.movement_jump = (fms.gm.mov.speed * 2);
        fms.gm.mov.jump = true;
    }
    public void Update(){
        
        if ((Input.GetKeyDown(KeyCode.Space)) && fms.gm.mov.jumps < fms.gm.mov.max_jump)
        {
            fms.OnNext(fms.jump);
        }
        if (fms.gm.mov.isNextToheWall())
        {
            fms.OnNext(fms.wallJump);
        }
        if (fms.gm.mov.rb.velocity.y < 0 && fms.gm.mov.isGrounded() == false)
        {
            fms.OnNext(fms.fall);
        }
        if(fms.gm.mov.isGrounded()){
            fms.OnNext(fms.idle);
        }
    }
    public void Exit(){
        fms.gm.mov.movement_jump = 0;
    }
}

public class OnFall : State
{
    FMS fms;
    public OnFall(FMS fms){
        this.fms = fms;
    }
    public void Enter(){
        fms.gm.mov.ac.SetTrigger("Fall");
    }
    public void Update(){
        if ((Input.GetKeyDown(KeyCode.Space)) && fms.gm.mov.jumps < fms.gm.mov.max_jump)
        {
            fms.OnNext(fms.jump);
        }
        if (fms.gm.mov.isNextToheWall())
        {
            fms.OnNext(fms.wallJump);
        }
        if(fms.gm.mov.isGrounded()){
            fms.OnNext(fms.idle);
        }
    }
    public void Exit(){

    }
}

public class OnWallJump : State
{
    FMS fms;
    public OnWallJump(FMS fms){
        this.fms = fms;
    }
    public void Enter(){
        fms.gm.mov.ac.SetTrigger("WallJump");
    }
    public void Update(){

        Debug.Log("WALLJUMP");
        if (!fms.gm.mov.isNextToheWall())
        {
            fms.OnNext(fms.fall);
        }
        /*
        if ((Input.GetKeyDown(KeyCode.Space)) && fms.gm.mov.jumps < fms.gm.mov.max_jump)
        {
            fms.OnNext(fms.jump);
        }
        if (fms.gm.mov.rb.velocity.y < 0 && fms.gm.mov.isGrounded() == false)
        {
            fms.OnNext(fms.fall);
        }
        if(fms.gm.mov.isGrounded()){
            fms.OnNext(fms.idle);
        }
        */
    }
    public void Exit(){
        //fms.gm.mov.movement_jump = 0;
    }
}
