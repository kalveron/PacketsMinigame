using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Packets
{
    public class LevelCompletePresenter : MonoBehaviour
    {
        private const string SuccessMessage = "Message Received: {0}";
        private const string FailureMessage = "System Corrupted: {0}";
        
        [SerializeField]
        private GameObject _completePanel;

        [SerializeField]
        private TextMeshProUGUI _messageText;

        [SerializeField]
        private GameManager _manager;
        [SerializeField]
        private UpgradeManager _upgradeManager;

    

        private List<string> _successMessages = new List<string>()
        {
            "Hello World",
            "The answer is 42.",
            "Look at Kirby dance! (>'-')> <( '-' )> <('-'<)"
        };

        private List<string> _failureMessages = new List<string>()
        {
            "All your computer are belong to me.",
            "Better luck next time.",
         };

        void Start()
        {
            GameManager.LevelComplete += OnGameManager_LevelComplete;    
        }

        private void OnDestroy()
        {
            GameManager.LevelComplete -= OnGameManager_LevelComplete;
        }

        private void OnGameManager_LevelComplete(bool success)
        {
            if (success)
            {
                
                if(_manager.Level < 3)
                {
                    _manager.IncreaseLevel();
                    _upgradeManager.ShowUpgrades();
                }
                else
                {
                    ShowPanel(true);
                }
            }
            else
            {
                ShowPanel(false);
            }         


        }

        private void ShowPanel(bool success)
        {
            _completePanel.SetActive(true);
            string message;
            if (success)
            {
                message = string.Format(SuccessMessage, _successMessages.GetRandomItem());
            }
            else
            {
                message = string.Format(FailureMessage, _failureMessages.GetRandomItem());
            }
            _messageText.text = message;
        }

    }


}