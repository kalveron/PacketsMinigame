using UnityEngine;

namespace Packets.UI
{
    public class ExitGameOnClick : AbstractOnClick
    {
        protected override void OnClick()
        {
            Application.Quit();
        }

    }
}