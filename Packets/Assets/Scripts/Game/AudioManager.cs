using System.Linq;
using UnityEngine;

namespace Packets
{
    public class AudioManager : MonoBehaviour
    {
        void Start()
        {
            if(FindObjectsOfType<AudioManager>().Count() > 1)
            {
                Destroy(this.gameObject);
            }
            GameObject.DontDestroyOnLoad(this.gameObject);
        }

    }
}