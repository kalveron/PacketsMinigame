using UnityEngine;

namespace Packets
{
   
    public class Packet : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _renderer;

        [SerializeField]
        private Color _friendlyColor;

        [SerializeField]
        private Color _maliciousColor;

        [SerializeField]
        private Shuttle _shuttle;

        public bool Friendly { get; private set; }

       

        public void Init(bool friendly, Vector3 port, float transferTime)
        {
            Friendly = friendly;
            _renderer.color = Friendly ? _friendlyColor : _maliciousColor;
            _shuttle.Move(port, transferTime);

        }

    }
}