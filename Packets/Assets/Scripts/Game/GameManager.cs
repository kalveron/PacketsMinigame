using System;
using UnityEngine;
using UnityEngine.UI;

namespace Packets
{
    public class GameManager : MonoBehaviour
    {
        public static event Action<bool> LevelComplete;

        private const float ProgressPerPacket = .1f;

        [SerializeField]
        private PacketSpawner _spawner;

        [SerializeField]
        private Slider _progressSlider;

        [SerializeField]
        private Slider _corruptionSlider;

        public bool GameActive { get; private set; }

        private float _waveCooldown = 0f;
        private float _waveDelay;

        private void Start()
        {
            Port.PacketProcessed += OnPort_PacketProcessed;
            StartGame();
        }

        private void OnPort_PacketProcessed(PacketProcessedArgs obj)
        {
           if(obj.Accepted)
            {
                var slider = obj.Packet.Friendly ? _progressSlider : _corruptionSlider;

                slider.value += ProgressPerPacket;
                if(slider.value >= slider.maxValue)
                {
                    LevelComplete?.Invoke(obj.Packet.Friendly);
                    StopGame();
                }
            }
        }

        void Update()
        {
            if (GameActive)
            {
                _waveCooldown += Time.deltaTime;
                if (_waveCooldown >= _waveDelay)
                {

                    bool friendly = UnityEngine.Random.Range(0, 2) == 0;
                    _spawner.SpawnPacket(friendly);

                    _waveCooldown = 0;
                    _waveDelay = UnityEngine.Random.Range(3f, 5f);
                }
            }
        }

        public void StartGame()
        {
            _progressSlider.value = 0;
            _corruptionSlider.value = 0;
            GameActive = true;
        }
        public void StopGame()
        {
            GameActive = false;
        }

        public void PauseGame(bool toggle)
        {
            GameActive = toggle;
        }
    }
}