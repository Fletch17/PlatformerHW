using UnityEngine;

public class StateMachine : IStateChanger
{
    private State _currentState;

    public void ChangeState(State state)
    {
        _currentState?.Exit();
        _currentState = state;
        _currentState?.Enter();
    }

    public void Update()
    {
        Debug.Log(_currentState.GetType());
        _currentState?.Update();
    }
}
