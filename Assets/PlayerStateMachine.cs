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
    }

    public Action<States, States> onStateChange() => (previousState, newState) => { };

    private States _previousState;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _currentState = States.Roam;
        _previousState = States.Roam;
    }

    // Update is called once per frame
    void Update()
    {
        if (_previousState != _currentState)
        {
            onStateChange().Invoke(_previousState, _currentState);
            _previousState = _currentState;
        }
    }

    public enum States
    {
        Roam,
        Computer
    }
}
