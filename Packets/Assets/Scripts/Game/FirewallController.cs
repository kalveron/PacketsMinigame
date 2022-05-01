using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Packets
{
    public class FirewallController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _firewall;

        [SerializeField]
        private Image _firewallFill;

        [SerializeField]
        private TextMeshProUGUI _controlText;

        private bool _firewallRecharging;

        private float _firewallCooldown = 10f;
        private float _firewallActiveTime = 5f;
        private float _timer = 0f;

        void Start()
        {
            _firewall.SetActive(false);
            _firewallFill.color = Color.green;
            _firewallRecharging = false;
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.F) && _firewallFill.fillAmount == 1)
            {
                StartCoroutine(EnableFirewall());
            }

            if(_firewallRecharging)
            {
                _timer += Time.deltaTime;
                var progress = _timer / _firewallCooldown;
                _firewallFill.fillAmount = progress;
                _firewallFill.color = Color.Lerp(Color.red, Color.green, progress);

                if(progress >=1)
                {
                    _firewallFill.fillAmount = 1;
                    _firewallFill.color = Color.green;
                    _firewallRecharging = false;
                    _controlText.gameObject.SetActive(true);
                  
                }

            }
        }

        public void UpgradeCooldown()
        {
            _firewallCooldown = 5f;
        }

        public void UpgradeDuration()
        {
            _firewallActiveTime = 10f;
        }
        private IEnumerator EnableFirewall()
        {
            _controlText.gameObject.SetActive(false);
            _firewallFill.fillAmount = 0;
            _firewall.SetActive(true);
            yield return new WaitForSeconds(_firewallActiveTime);
            _firewall.SetActive(false);            
            _firewallRecharging = true;
            _timer = 0;
        }
    }

    
}