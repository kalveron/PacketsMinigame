using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Packets
{
    public class PacketSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _packetPrefab;

        [SerializeField]
        private List<Port> _ports;

        public int PacketLimit => 15;
       
        private List<Packet> _packets;

        private void Start()
        {
            _packets = new List<Packet>();
            Port.PacketProcessed += OnPort_PacketProcessed;
          
        }

        private void OnPort_PacketProcessed(PacketProcessedArgs obj)
        {
            _packets.Remove(obj.Packet);
            Destroy(obj.Packet.gameObject);
        }

        public bool SpawnPacket(bool friendly)
        {
            if (_packets.Count < PacketLimit)
            {
               
                var packet = Instantiate(_packetPrefab, transform.localPosition, Quaternion.identity).GetComponent<Packet>();
                _packets.Add(packet);
                var portLocation = _ports.GetRandomItem().transform.localPosition;
                packet.Init(friendly, portLocation, 5);
                return true;
            }

            return false;
        }
        public bool SpawnPacket(bool friendly, Port destination)
        {
            if (_packets.Count < PacketLimit)
            {
                
                var packet = Instantiate(_packetPrefab, transform.localPosition, Quaternion.identity).GetComponent<Packet>();
                _packets.Add(packet);
                var portLocation = destination.transform.localPosition;
                packet.Init(friendly, portLocation, 5);
                return true;
            }

            return false;
        }

    
    }
}