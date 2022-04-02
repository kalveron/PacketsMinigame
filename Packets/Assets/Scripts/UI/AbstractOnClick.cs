using UnityEngine;
using UnityEngine.UI;

namespace Packets.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class AbstractOnClick : MonoBehaviour
    {
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }
        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }

        protected abstract void OnClick();


    }
}