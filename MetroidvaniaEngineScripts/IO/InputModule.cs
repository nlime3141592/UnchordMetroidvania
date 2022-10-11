using UnityEngine;

namespace UnchordMetroidvania
{
    [AddComponentMenu("Unchord Metroidvania/IO/Input Module")]
    public class InputModule : MonoBehaviour
    {
        public InputData data => m_data;
        public bool isRestricted => mb_restricted;

        private InputData m_data;
        private bool mb_restricted;
        private bool mb_restrictedBefore;

        private void Update()
        {
            mb_restrictedBefore = mb_restricted;

            if(!mb_restricted)
                m_data.Copy(InputHandler.data);
            else if(!mb_restrictedBefore)
                m_data = new InputData();
            else
                return;
        }

        public void RestrictInput()
        {
            mb_restricted = true;
        }

        public void AcceptInput()
        {
            mb_restricted = false;
        }
    }
}