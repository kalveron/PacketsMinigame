using UnityEngine;
using UnityEngine.UI;


namespace Packets
{

    public class VolumeController : MonoBehaviour
    {

        [SerializeField]
        private Slider _slider;

        private AudioSource _source;
   
        private void Start()
        {
            _source = FindObjectOfType<AudioManager>().GetComponent<AudioSource>();

            _slider.onValueChanged.AddListener(UpdateVolume);
            
            _slider.value = _source.volume;
        }

        private void UpdateVolume(float value)
        {
            _source.volume = value;
        }
     
    }
}