using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Infrastructure.GameStateMashine.States;
using UnityEngine;

public class Game : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private Apple _applePrefab;
    [SerializeField] private SnakeBody _snakeBodyPrefab;
    [SerializeField] private GameHUD _gameHUD;

    private Dictionary<Type, IState> _gameStates;

    private IState _state;

    private void Awake()
    {
        _gameStates = new Dictionary<Type, IState>()
        {
            [typeof(InitializationState)] = new InitializationState(this, _applePrefab, _snakeBodyPrefab),
            [typeof(LoadState)] = new LoadState(this, this),
        };

        DontDestroyOnLoad(this);
    }

    private void Start() => EnterState<InitializationState>();

    public void EnterState<IState>()
    {
        _state?.Exit();
        _state = _gameStates[typeof(IState)];
        _state.Enter();
    }

    public void Run(IEnumerator coroutine) => StartCoroutine(coroutine);
}