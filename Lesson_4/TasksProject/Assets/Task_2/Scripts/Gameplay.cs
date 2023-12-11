using System;
using UnityEngine;

namespace Task_2.Scripts
{
    public class Gameplay
    {
        private readonly InputService _inputService;
        private readonly Player.Player _player;

        public event Action Defeat;

        public Gameplay(InputService inputService, Player.Player player)
        {
            _inputService = inputService;
            _player = player;
            
            Start();
        }

        public void Restart()
        {
            _player.Restart();
            Start();
        }

        private void Start()
        {
            _player.Died += OnDefeat;

            _inputService.UpLevelPressed += InputServiceOnUpLevelPressed;
            _inputService.DecreaseHealthPressed += InputServiceOnDecreaseHealthPressed;

            Debug.Log("Start game.");
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
}