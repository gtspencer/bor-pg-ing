using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private States _currentState;

    public States currentState
    {
        get => _currentState;
        set
        {
            var previousState = _currentState;
            _currentState = value;
            onStateChange().Invoke(previousState, _currentState);
        }
    }

    public Action<States, States> onStateChange() => (previousState, newState) => { };

    public enum States
    {
        Roam,
        Computer,
        Inventory
    }
}
