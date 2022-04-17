using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Packets
{
    public class LevelCompletePresenter : MonoBehaviour
    {
        private const string SuccessMessage = "Message Decrypted: {0}";
        private const string FailureMessage = "System Corrupted: {0}";
        
        [SerializeField]
        private GameObject _completePanel;

        [SerializeField]
        private Button _playAgain;

        [SerializeField]
        private TextMeshProUGUI _messageText;

        [SerializeField]
        private GameManager _manager;

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
            _playAgain.onClick.AddListener(PlayAgain);
    
        }

        private void OnDestroy()
        {
            
            _playAgain.onClick.RemoveListener(PlayAgain);
        }

        private void OnGameManager_LevelComplete(bool success)
        {
            _completePanel.SetActive(true);
         
            string message;
            if(success)
            {
                message = string.Format(SuccessMessage, _successMessages.GetRandomItem());
            }
            else
            {
                message = string.Format(FailureMessage, _failureMessages.GetRandomItem());
            }


            _messageText.text = message;


        }

        private void PlayAgain()
        {
            _completePanel.SetActive(false);
            _manager.StartGame();

        }

       

      
    }
}