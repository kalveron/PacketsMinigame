using System;
using UnityEngine;

namespace Packets
{
    public class Firewall : MonoBehaviour
    {
        public static event Action<PacketDestroyedArgs> PacketDestroyed;


        private void OnTriggerEnter2D(Collider2D collision)
        {

            var packet = collision.GetComponent<Packet>();

            //Ignore collisions with non-packet objects
            if (packet == null)
            {
                return;
            }
            var args = new PacketDestroyedArgs( packet);
            PacketDestroyed?.Invoke(args);

        }
    }

    public class PacketDestroyedArgs
    {
        public Packet Packet { get; private set; }

        public PacketDestroyedArgs(Packet packet)
        {
            
            Packet = packet;
            
        }

    }
}