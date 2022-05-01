using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Packets
{
    public class GameManager : MonoBehaviour
    {
        public static event Action<bool> LevelComplete;

        [SerializeField]
        private PacketSpawner _spawner;

        [SerializeField]
        private Slider _progressSlider;

        [SerializeField]
        private Slider _corruptionSlider;

        [SerializeField]
        private PortShield _portShield;

        public bool GameActive { get; private set; }
        public int Level { get; private set; } = 0;
        public bool PacketConverterUpgrade { get; set; }
        public bool PacketProgressUpgrade { get; set; }

        private float _waveCooldown = 0f;
        private float _waveDelay;
        private float _conversionChance = .1f;

        private List<float> _packetProgressionFriendly = new List<float>()
        {
            .1f,
            .05f,
            .025f,
            .025f,
        };

        private List<float> _packetProgressionMalicious = new List<float>()
        {
            .1f,
            .2f,
            .3f,
            .3f,
        };

        private List<Vector2> _waveDelayMapping = new List<Vector2>()
        {
            new Vector2(2, 3),
            new Vector2(1.5f, 2.5f),
            new Vector2(1, 1.5f),
            new Vector2(.5f, 1f),
        };



        private void Start()
        {
            Port.PacketProcessed += OnPort_PacketProcessed;
            StartGame();
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
                    var delay = _waveDelayMapping[Level];
                    _waveDelay = UnityEngine.Random.Range(delay.x, delay.y);
                }


            }
        }

        private void OnPort_PacketProcessed(PacketProcessedArgs obj)
        {
            if (obj.Accepted)
            {
                bool friendly;
                if (PacketConverterUpgrade)
                {
                    var chance = UnityEngine.Random.Range(0f, 1);
                    if (chance <= _conversionChance)
                    {
                        friendly = true;
                    }
                    else
                    {
                        friendly = obj.Packet.Friendly;
                    }

                }
                else
                {
                    friendly = obj.Packet.Friendly;
                }

                var slider = friendly ? _progressSlider : _corruptionSlider;
                

                if (_portShield.ShieldUpgrade && _portShield.ShieldActive && !friendly)
                {
                    _portShield.UseShield();            
                }
                else
                {
                    var progress = friendly ? _packetProgressionFriendly : _packetProgressionMalicious;
                    slider.value += PacketProgressUpgrade ? progress[Level] * 2 : progress[Level];
                }

                if(slider.value >= slider.maxValue)
                {
                    LevelComplete?.Invoke(obj.Packet.Friendly);
                    StopGame();
                }
            }
        }



        public void StartGame()
        {
            _progressSlider.value = 0;
            _corruptionSlider.value = 0;
            GameActive = true;
        }

        public void RestartGame()
        {
            _progressSlider.value = 0;
            _corruptionSlider.value -= 5;
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
        public void IncreaseLevel()
        {
            Level++;
        }
    }
}