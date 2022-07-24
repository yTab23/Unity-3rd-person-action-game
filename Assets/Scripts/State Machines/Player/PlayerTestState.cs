using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    float timer = 5f;
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        Debug.Log("Enter");
    }

    public override void Tick(float deltaTime)
    {
        timer -= deltaTime;
        Debug.Log("Time in this state: " + timer);  
        if(timer <= 0)
        {
            stateMachine.SwitchState(new PlayerTestState(stateMachine));
        } 
    }

    public override void Exit()
    {
        Debug.Log("Exit");
    }
}
    

