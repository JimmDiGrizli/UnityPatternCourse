using System;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.Serialization;
using View;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;

    [FormerlySerializedAs("_restartView")] [Space] [SerializeField]
    private RestartLevelView _restartLevelView;

    [SerializeField] private TextView _healthPointView;
    [SerializeField] private TextView _levelView;

    private Player _player;
    private GamePlay _gamePlay;
    private InputService _input;

    private readonly List<IDisposable> _disposable = new();

    public void Awake()
    {
        InitPlayer();
        _input = new InputService();
        _gamePlay = new GamePlay(_input, _player);
        _disposable.Add(new RestartLevelMediator(_gamePlay, _restartLevelView));

        _gamePlay.Start();
    }

    public void Update() => _input?.Update();

    public void OnDestroy() => _disposable.ForEach(disposable => disposable.Dispose());

    private void InitPlayer()
    {
        var healthPointProperty = new Property<int>(_playerConfig.HealthPoint);
        var levelProperty = new Property<int>(_playerConfig.Level);

        _player = new Player(healthPointProperty, levelProperty);
        _disposable.Add(new PropertyMediator(healthPointProperty, _healthPointView));
        _disposable.Add(new PropertyMediator(levelProperty, _levelView));
    }
}