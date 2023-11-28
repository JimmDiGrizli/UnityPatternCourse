using System;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.Serialization;
using View;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;

    [FormerlySerializedAs("_restartView")] [Space] [SerializeField] private RestartLevelView _restartLevelView;
    [SerializeField] private PlayerPropertyView _healthPointView;
    [SerializeField] private PlayerPropertyView _levelView;

    private Player _player;
    private Level _level;
    private InputService _input;

    private readonly List<IDisposable> _disposable = new();

    public void Awake()
    {
        InitPlayer();
        _input = new InputService();
        _level = new Level(_input, _player);
        _disposable.Add(new RestartLevelMediator(_level, _restartLevelView));

        _level.Start();
    }

    public void Update() => _input?.Update();

    public void OnDestroy()
    {
        _disposable.ForEach(mediator => mediator.Dispose());
    }

    private void InitPlayer()
    {
        var healthPointProperty = new Property(_playerConfig.HealthPoint);
        var levelProperty = new Property(_playerConfig.Level);

        _player = new Player(healthPointProperty, levelProperty);
        _disposable.Add(new PlayerPropertyMediator(_player, healthPointProperty, _healthPointView));
        _disposable.Add(new PlayerPropertyMediator(_player, levelProperty, _levelView));
    }
}