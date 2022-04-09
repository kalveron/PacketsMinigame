using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Packets
{
    
    
    public class Port : MonoBehaviour
    {
        public static event Action<PacketProcessedArgs> PacketProcessed;
        

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private Sprite _openSprite;

        [SerializeField]
        private Sprite _closedSprite;


        public bool Open { get; private set; }
       
        void Start()
        {
            TogglePort(true);
        }

        public void TogglePort(bool open)
        {
            Open = open;
            _spriteRenderer.sprite = Open ? _openSprite : _closedSprite;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            var packet = collision.GetComponent<Packet>();

            //Ignore collisions with non-packet objects
            if (packet == null)
            {
                return;
            }
            var args = new PacketProcessedArgs(this, packet, Open);
            PacketProcessed?.Invoke(args);
         
        }

      






    }

    public class PacketProcessedArgs
    {
        public Port Port { get; private set; }
      
        public Packet Packet { get; private set; }

        public bool Accepted { get; private set; }

        public PacketProcessedArgs(Port port, Packet packet, bool accepted)
        {
            Port = port;
            Packet = packet; 
            Accepted = accepted;
        }

    }
}