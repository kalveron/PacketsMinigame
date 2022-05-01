using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Packets
{
    public class UpgradeManager : MonoBehaviour
    {
        private const string Message = "Nice work! The adversary is getting smarter, choose one of the following upgrades to help out.";

        [SerializeField]
        private GameObject _upgradePanel;
        [SerializeField]
        private GameManager _gameManager;
        [SerializeField]
        private PortShield _portShield;
        [SerializeField]
        private Firewall _firewall;
        [SerializeField]
        private FirewallController _firewallController;


        [Header("Upgrade Buttons")]
        [SerializeField]
        private Button _firewallFilterButton;

        [SerializeField]
        private Button _firewallCooldownButton;
        
        [SerializeField]
        private Button _firewallDurationButton;

        [SerializeField]
        private Button _packetCompressionButton;

        [SerializeField]
        private Button _packetConversionButton;

        [SerializeField]
        private Button _packetShieldButton;
     
        private void Start()
        {
            _firewallFilterButton.onClick.AddListener(FirewallFilterOnClick);
            _firewallDurationButton.onClick.AddListener(FirewallDurationOnClick);
            _firewallCooldownButton.onClick.AddListener(FirewallCooldownOnClick);
            _packetCompressionButton.onClick.AddListener(PacketCompressionOnClick);
            _packetShieldButton.onClick.AddListener(PacketShieldOnClick);
            _packetConversionButton.onClick.AddListener(PacketConverterOnClick);
        }
        private void OnDestroy()
        {
            _firewallFilterButton.onClick.RemoveListener(FirewallFilterOnClick);
            _firewallDurationButton.onClick.RemoveListener(FirewallDurationOnClick);
            _firewallCooldownButton.onClick.RemoveListener(FirewallCooldownOnClick);
            _packetCompressionButton.onClick.RemoveListener(PacketCompressionOnClick);
            _packetShieldButton.onClick.RemoveListener(PacketShieldOnClick);
            _packetConversionButton.onClick.RemoveListener(PacketConverterOnClick);
        }

        public void ShowUpgrades()
        {
            _upgradePanel.SetActive(true);

        }

        private void StartNextRound()
        {
            _upgradePanel.SetActive(false);
            _gameManager.RestartGame();
        }

        private void FirewallFilterOnClick()
        {
            _firewall.UpgradeEnabled = true;
            _firewallFilterButton.interactable = false;
            StartNextRound();
        }

        private void FirewallCooldownOnClick()
        {
            _firewallController.UpgradeCooldown();
            _firewallCooldownButton.interactable = false;
            StartNextRound();
        }

        private void FirewallDurationOnClick()
        {
            _firewallController.UpgradeDuration();
            _firewallDurationButton.interactable = false;
            StartNextRound();
        }

        private void PacketConverterOnClick()
        {
            _gameManager.PacketConverterUpgrade = true;
            _packetConversionButton.interactable = false;
            StartNextRound();
        }

        private void PacketShieldOnClick()
        {
            _portShield.ActivateUpgrade();
            _packetShieldButton.interactable = false;
            StartNextRound();
        }
        private void PacketCompressionOnClick()
        {
            _gameManager.PacketProgressUpgrade = true;
            _packetCompressionButton.interactable = false;
            StartNextRound();
        }
    }
}