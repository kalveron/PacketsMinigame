using UnityEngine;

namespace Packets
{
    public class Shuttle : MonoBehaviour
    {
        public float TransitionTime { get; private set; }
        public bool IsMoving { get; private set; }
        private Vector3 _startingLocation;
        private Vector3 _endingLocation;
        private float _movementTime;
        private void Start()
        {
            IsMoving = false;
        }

        void FixedUpdate()
        {
            if (IsMoving)
            {
                _movementTime += Time.fixedDeltaTime;
                var progress = _movementTime / TransitionTime;

                transform.localPosition = Vector3.Lerp(_startingLocation, _endingLocation, progress);

                if (progress >= 1)
                {
                    transform.localPosition = _endingLocation;
                    IsMoving = false;
                }
            }
        }

        public void Move(Vector3 newLocation, float transitionTime)
        {
            _startingLocation = transform.localPosition;
            _endingLocation = newLocation;
            IsMoving = true;
            TransitionTime = transitionTime;
            _movementTime = 0;

        }

    }
}