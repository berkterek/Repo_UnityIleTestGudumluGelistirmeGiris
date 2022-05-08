using UnityEngine;
using UnityEngine.InputSystem;
using UnityTddBeginner.Abstracts.Inputs;

namespace UnityTddBeginner.Inputs
{
    public class InputReader : IInputReader
    {
        public float Horizontal { get; private set; }

        public InputReader()
        {
            GameInputActions input = new GameInputActions();

            input.Player.Move.performed += HandleOnMoved;
            input.Player.Move.canceled += HandleOnMoved;
            
            input.Enable();
        }

        void HandleOnMoved(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<Vector2>().x;
        }
    }    
}

