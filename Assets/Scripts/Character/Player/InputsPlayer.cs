using UnityEngine;

namespace Character.Player
{
    public class InputsPlayer : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _joystick;
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        



        private void Update()
        {
            Horizontal = _joystick.Horizontal;
            Vertical = _joystick.Vertical;
        }
    }
}
