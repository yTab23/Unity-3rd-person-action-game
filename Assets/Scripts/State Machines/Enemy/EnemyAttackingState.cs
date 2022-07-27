using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    private readonly int AttackHash = Animator.StringToHash("Attack");

    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;

    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine) {}


    public override void Enter()
    {
        FacePlayer(); //The enemy will reorient itself after the attack

        stateMachine.Weapon.SetAttack(stateMachine.AttackDamage, stateMachine.AttackKnockback);
        stateMachine.Animator.CrossFadeInFixedTime(AttackHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        if(GetNormalizedTime(stateMachine.Animator, "Attack") >= 1)
        {
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
        }

        //FacePlayer(); //The enemy will reorient itself before the attack
    }

    public override void Exit(){}
}
