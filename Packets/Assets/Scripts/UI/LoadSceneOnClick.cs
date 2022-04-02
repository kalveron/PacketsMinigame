using UnityEngine;
using UnityEngine.SceneManagement;

namespace Packets.UI
{
    public class LoadSceneOnClick : AbstractOnClick
    {
        [SerializeField]
        private string _sceneToLoad;
        protected override void OnClick()
        {
            SceneManager.LoadScene(_sceneToLoad);
        }
    }
}