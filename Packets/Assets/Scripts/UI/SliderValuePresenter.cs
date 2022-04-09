using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Packets
{
    public class SliderValuePresenter : MonoBehaviour
    {
        private const string ProgressString = "{0}/100";
        [SerializeField]
        private TextMeshProUGUI _text;

        [SerializeField]
        private Slider _slider;

        private void Start()
        {
            UpdateText(_slider.value);
            _slider.onValueChanged.AddListener(UpdateText);
        }

       
        private  void UpdateText(float value)
        {
          
            _text.text = string.Format(ProgressString, (int)( value * 100));
        }
    }
}