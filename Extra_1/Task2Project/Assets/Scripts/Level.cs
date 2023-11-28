using System;
using UnityEngine;

public class Level
{
    private readonly InputService _inputService;
    private readonly Player _player;

    public event Action Defeat;

    public Level(InputService inputService, Player player)
    {
        _inputService = inputService;
        _player = player;
    }

    public void Start()
    {
        _player.Died += OnDefeat;

        _inputService.UpLevelPressed += InputServiceOnUpLevelPressed;
        _inputService.DecreaseHealthPressed += InputServiceOnDecreaseHealthPressed;

        Debug.Log("Start game.");
    }

    public void Restart()
    {
        _player.Restart();
        Start();
    }

    private void InputServiceOnUpLevelPressed() => _player.UpLevel();

    private void InputServiceOnDecreaseHealthPressed() => _player.DecreaseHealth();

    private void OnDefeat()
    {
        _inputService.UpLevelPressed -= InputServiceOnUpLevelPressed;
        _inputService.DecreaseHealthPressed -= InputServiceOnDecreaseHealthPressed;

        Defeat?.Invoke();

        Debug.Log("Game over.");
    }
}