using UnityEngine;

namespace UnchordMetroidvania
{
    [AddComponentMenu("Unchord Metroidvania/IO/Input Manager")]
    public sealed class InputManager : MonoBehaviour
    {
        private static InputManager s_m_manager;
        private static bool s_mb_initialized = false;

        private void Start()
        {
            if(s_m_manager == null)
            {
                s_m_manager = this;
                s_mb_initialized = true;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void FixedUpdate()
        {
            if(!s_mb_initialized)
                return;

            InputBuffer.FixedUpdate();
        }

        private void Update()
        {
            if(!s_mb_initialized)
                return;

            InputHandler.Update();
        }
    }
}