using UnityEngine;
using UnityEngine.InputSystem;
using UnityTddBeginner.Abstracts.Inputs;

namespace UnityTddBeginner.Inputs
{
    public class InputReader : IInputReader
    {
        readonly GameInputActions _input;
        readonly InputActionReference _movementAction;
        
        public float Horizontal { get; private set; }
        public bool Jump => _input.Player.Jump.WasPressedThisFrame();

        public InputReader(InputActionReference movementAction)
        {
            _input = new GameInputActions();
            _movementAction = movementAction;

            _movementAction.action.performed += HandleOnMovement;
            _movementAction.action.canceled += HandleOnMovement;
            
            _input.Enable();
            _movementAction.action.Enable();
        }

        void HandleOnMovement(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<Vector2>().x;
            Debug.Log(Horizontal);
        }
    }    
}

