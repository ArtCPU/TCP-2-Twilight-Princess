using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{
    public class LinkInputController : MonoBehaviour
    {
        public InputActions InputActions { get; private set; }
        public InputAction Walk { get; private set; }
        public InputAction Interact { get; private set; }
        public InputAction Attack { get; private set; }
        public InputAction Guard { get; private set; }
        public InputAction TargetLock { get; private set; }
        public InputAction ItemA { get; private set; }
        public InputAction ItemB { get; private set; }
        public InputAction Map { get; private set; }
        public InputAction Menu { get; private set; }
        public InputAction Inventory { get; private set; }

        public Vector3 MovementDirection { get; private set; }
        public Vector2 CameraDirection { get; private set; }



        private void Awake()
        {
            InputActions = new InputActions();
            Walk = InputActions.CharacterInput.Walk;
            Interact = InputActions.CharacterInput.Interact;
            Attack = InputActions.CharacterInput.Attack;
            Guard = InputActions.CharacterInput.Guard;
            TargetLock = InputActions.CharacterInput.TargetLock;
            ItemA = InputActions.CharacterInput.ItemA;
            ItemB = InputActions.CharacterInput.ItemB;
            Menu = InputActions.CharacterInput.Menu;
            Inventory = InputActions.CharacterInput.Inventory;
            Map = InputActions.CharacterInput.Map;

            InputActions.CharacterInput.Walk.performed += context => MovementDirection = ConvertVector2(context.ReadValue<Vector2>());
            InputActions.CharacterInput.Walk.canceled += context => MovementDirection = ConvertVector2(context.ReadValue<Vector2>());
            InputActions.CharacterInput.Camera.performed += context => CameraDirection = context.ReadValue<Vector2>();
            InputActions.CharacterInput.Camera.canceled += context => CameraDirection = context.ReadValue<Vector2>();
        }

        public void SetActive(bool active)
        {
            if (active)
            {
                InputActions.CharacterInput.Enable();
            }

            else InputActions.CharacterInput.Disable();
        }

        private Vector3 ConvertVector2(Vector2 vector)
        {
            return new Vector3(vector.x, 0, vector.y);
        }
    }
}