using UnityEngine;

public class EnemyStateMachineFactory : MonoBehaviour
{
    public StateMachine Create(Enemy enemy)
    {
        var stateMachine = new StateMachine();

        var agrToHeroState = new AgrToHeroState(stateMachine, enemy);
        var attackState = new AttackState(stateMachine, enemy);
        var followTargetState = new FollowTargetState(stateMachine, enemy);
        var patrolState = new PatrolState(stateMachine, enemy);

        var toAgrToHeroTransition = new ToAgrToHeroTransition(agrToHeroState, enemy);
        var toAttackTransition = new ToAttackTransition(attackState, enemy);
        var toFollowTransition = new ToFollowTransition(followTargetState, enemy);
        var toPatrolTransition = new ToPatrolTransition(patrolState, enemy);

        agrToHeroState.AddTransition(toFollowTransition);
        attackState.AddTransition(toFollowTransition);
        patrolState.AddTransition(toAgrToHeroTransition);
        followTargetState.AddTransition(toAttackTransition);
        followTargetState.AddTransition(toPatrolTransition);

        stateMachine.ChangeState(patrolState);
        return stateMachine;
    }
}
