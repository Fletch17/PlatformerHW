using UnityEngine;

public class EnemyStateMachineFactory : MonoBehaviour
{
    public StateMachine Create(Enemy enemy, Player player)
    {
        var stateMachine = new StateMachine();

        var agrToHeroState = new AgrToHeroState(stateMachine, enemy);
        var attackState = new AttackState(stateMachine, enemy);
        var followTargetState = new FollowTargetState(stateMachine, enemy, player);
        var patrolState = new PatrolState(stateMachine, enemy);
        var deadState = new DeadState(stateMachine);

        var toAgrToHeroTransition = new ToAgrToHeroTransition(agrToHeroState, enemy);
        var toAttackTransition = new ToAttackTransition(attackState, enemy);
        var toFollowTransition = new ToFollowTransition(followTargetState, enemy);
        var toPatrolTransition = new ToPatrolTransition(patrolState, enemy);
        var toDeadTransition = new ToDeadTransition(deadState, enemy);

        agrToHeroState.AddTransition(toFollowTransition);
        attackState.AddTransition(toFollowTransition);
        patrolState.AddTransition(toAgrToHeroTransition);
        followTargetState.AddTransition(toAttackTransition);
        followTargetState.AddTransition(toPatrolTransition);
        agrToHeroState.AddTransition(toDeadTransition);
        attackState.AddTransition(toDeadTransition);
        patrolState.AddTransition(toDeadTransition);
        followTargetState.AddTransition(toDeadTransition);

        stateMachine.ChangeState(patrolState);
        return stateMachine;
    }
}
