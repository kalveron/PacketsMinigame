using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Packets.UI
{ 
    public class ToggleObjectsOnClick : AbstractOnClick
    {
        [SerializeField]
        private List<GameObject> _objects;

        [SerializeField]
        private bool _enable;

  
        protected override void OnClick()
        {
            foreach(var obj in _objects)
            {
                obj.SetActive(_enable);
            }

          
        }
    }
}