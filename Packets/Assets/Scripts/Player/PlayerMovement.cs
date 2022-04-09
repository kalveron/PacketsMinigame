using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Packets
{
    [RequireComponent(typeof(Shuttle))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _ports;

        private int _placementIndex;
        private Shuttle _shuttle;

        private void Start()
        {
            _shuttle = GetComponent<Shuttle>();
            _placementIndex = _ports.Count % 2;
            MovePlayer(0);
            
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MovePlayer(-1);
            }
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                MovePlayer(1);
            }
        }


        private void MovePlayer(int movement)
        {          
            _placementIndex += movement;            
            if (_placementIndex >= _ports.Count)
            {
                _placementIndex = _ports.Count - 1;
            }
            if(_placementIndex < 0)
            {
                _placementIndex = 0;
            }


            _shuttle.Move(_ports[_placementIndex].transform.localPosition.WithY(transform.localPosition.y), 0);


        }
    }
}