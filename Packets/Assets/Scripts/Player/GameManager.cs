using UnityEngine;

namespace Packets
{
    public class GameManager : MonoBehaviour
    {
        private const float WaveDelay = 20f;


        [SerializeField]
        private PacketSpawner _spawner;
        
        private float _waveCooldown = 0f;
        

      
        void Update()
        {
            _waveCooldown += Time.deltaTime;
            if(_waveCooldown >= WaveDelay)
            {
                for(int i = 0; i < _spawner.PacketLimit; i++)
                {
                    bool friendly = Random.Range(0, 2) == 0;
                    _spawner.SpawnPacket(friendly);
                }
            }
        }
    }
}