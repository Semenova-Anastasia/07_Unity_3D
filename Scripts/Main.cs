using System.Collections.Generic;
using UnityEngine;

namespace GeekBrains
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    public sealed class Main : MonoBehaviour
    {
        /// <summary>
        /// Ссылка на контроллер фонарика
        /// </summary>
        public FlashLightController FlashLightController { get; private set; }

        /// <summary>
        /// Ссылка на контроллер нажатия клавиш
        /// </summary>
        public InputController InputController { get; private set; }

        /// <summary>
        /// Ссылка на контроллер игрока
        /// </summary>
        public PlayerController PlayerController { get; private set; }

        private readonly List<IOnUpdate> _updates = new List<IOnUpdate>();
        private Transform Player;

        public static Main Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            Player = GameObject.FindGameObjectWithTag("Player").transform;

            PlayerController = new PlayerController(new UnitMotor(Player));
            _updates.Add(PlayerController);

            FlashLightController = new FlashLightController();
            _updates.Add(FlashLightController);

            InputController = new InputController();
            _updates.Add(InputController);
        }

        private void Start()
        {
            FlashLightController.Init();
            InputController.On();
        }

        private void Update()
        {
            for (var i = 0; i < _updates.Count; i++)
            {
                _updates[i].OnUpdate();
            }
        }
    }
}
