using System;
using System.Collections;
using System.Collections.Generic;
using State;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private BaseState _currentState;

    public void Initialize(BaseState startState)
    {
        _currentState = startState;
        _currentState.EnterState();
    }

    public void ChangeState(BaseState newState)
    {
        _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }

    public void Update()
    {
        _currentState?.UpdateState();
    }
}
