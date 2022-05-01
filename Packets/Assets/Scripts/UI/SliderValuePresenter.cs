using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Packets
{
    public class SliderValuePresenter : MonoBehaviour
    {
        private const string ProgressString = "{0}%";
        [SerializeField]
        private TextMeshProUGUI _text;

        [SerializeField]
        private Slider _slider;

        private void Start()
        {
            UpdateText(_slider.value);
            _slider.onValueChanged.AddListener(UpdateText);
        }
        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveListener(UpdateText);
        }


        private  void UpdateText(float value)
        {
            var progress = (value / 1) * 100;
            _text.text = string.Format(ProgressString, progress.ToString("0")) ;
        }
    }
}