using UnityEngine;

namespace Packets
{
    [RequireComponent(typeof(Shuttle))]
    public class SpawnMover : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _leftLimit;

        [SerializeField]
        private Vector3 _rightLimit;

        private bool _movingRight;
        
        private Shuttle _shuttle;
     
        void Start()
        {
            _shuttle = GetComponent<Shuttle>();
            _movingRight = true;
        }

       
        void Update()
        {
            if(!_shuttle.IsMoving)
            {
                Slide();
            }
        }

        private void Slide()
        {
            var destination = _movingRight ? _rightLimit : _leftLimit;
            _shuttle.Move(destination, 5);
            _movingRight = !_movingRight;
        }
    }
}