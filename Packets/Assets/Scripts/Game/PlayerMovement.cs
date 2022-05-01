using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Packets
{
    [RequireComponent(typeof(Shuttle))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private List<Port> _ports;

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
            if (Input.GetKeyDown(KeyCode.LeftArrow)  || Input.GetKeyDown(KeyCode.A))
            {
                MovePlayer(-1);
            }
            if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                MovePlayer(1);
            }
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.W))
            {
                var port = _ports[_placementIndex];
                port.TogglePort(!port.Open);
            }
        }


        private void MovePlayer(int movement)
        {          
            _placementIndex += movement;            
            if (_placementIndex >= _ports.Count)
            {
                _placementIndex = 0;
            }
            if(_placementIndex < 0)
            {
                _placementIndex = _ports.Count -1;
            }


            _shuttle.Move(_ports[_placementIndex].transform.localPosition.WithY(transform.localPosition.y), 0);


        }
    }
}