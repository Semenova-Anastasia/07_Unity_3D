using UnityEngine;

namespace GeekBrains
{
    /// <summary>
    /// Контроллер, который отвечает за горячие клавиши.
    /// </summary>
    public class InputController : BaseController, IOnUpdate
    {
        private KeyCode _activeFlashLight = KeyCode.F;
        public void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_activeFlashLight))
            {
                Main.Instance.FlashLightController.Switch();
            }
        }
    }
}
