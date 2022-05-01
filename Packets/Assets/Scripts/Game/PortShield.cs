using UnityEngine;
using UnityEngine.UI;

namespace Packets
{
    public class PortShield : MonoBehaviour
    {

        [SerializeField]
        private GameObject _shieldBase;

        [SerializeField]
        private Image _shieldFill;

        private bool _shieldRecharging;
        private float _shieldCooldown = 10f;
        private float _timer = 0f;

        public bool ShieldUpgrade { get; private set; }
        public bool ShieldActive { get => _shieldFill.fillAmount == 1; }


        void Start()
        {
            _shieldBase.SetActive(false);
        }

        
        void Update()
        {
            if (ShieldUpgrade && _shieldRecharging)
            {
                _timer += Time.deltaTime;
                var progress = _timer / _shieldCooldown;
                _shieldFill.fillAmount = progress;
                _shieldFill.color = Color.Lerp(Color.grey, Color.green, progress);

                if (progress >= 1)
                {
                    _shieldFill.fillAmount = 1;
                    _shieldFill.color = Color.green;
                    _shieldRecharging = false;
                }

            }
        }

        public void ActivateUpgrade()
        {
            ShieldUpgrade = true;
            _shieldBase.SetActive(true);
            _shieldFill.fillAmount = 1;
            _shieldFill.color = Color.green;

        }

        public void UseShield()
        {
            _timer = 0;
            _shieldRecharging = true;
            _shieldFill.fillAmount = 0;
        }


    }
}