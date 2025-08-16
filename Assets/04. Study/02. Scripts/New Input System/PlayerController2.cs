using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{
    public class PlayerController2 : MonoBehaviour
    {
        private CharacterController cc;

        private Vector2 moveInput;
        public float speed = 5f;

        private PlayerInput playerInput;

        private InputAction moveAction;
        private InputAction jumpAction;

        void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            
            moveAction = playerInput.actions.FindAction("Player/Move");
            jumpAction = playerInput.actions.FindAction("Player/Jump");

            cc = GetComponent<CharacterController>();
        }

        void OnEnable()
        {
            moveAction.Enable();
            moveAction.performed += Move;
            moveAction.canceled += MoveCancel;
            
            jumpAction.Enable();
            jumpAction.performed += Jump;
        }

        void OnDisable()
        {
            moveAction.Disable();
            moveAction.performed -= Move;
            moveAction.canceled -= MoveCancel;

            jumpAction.Disable();
            jumpAction.performed -= Jump;
        }

        void Update()
        {
            var dir = new Vector3(moveInput.x, 0, moveInput.y);

            cc.Move(dir * speed * Time.deltaTime);
        }

        public void Move(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }

        public void MoveCancel(InputAction.CallbackContext context)
        {
            moveInput = Vector2.zero;
        }

        public void Jump(InputAction.CallbackContext context)
        {
            Debug.Log("Jump");
        }
    }
}