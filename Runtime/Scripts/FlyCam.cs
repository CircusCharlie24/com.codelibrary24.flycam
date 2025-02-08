using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeLibrary24.FlyCam
{
    public class FlyCam : MonoBehaviour
    {
        public float movementSpeed = 5.0f;
        public float fastMovementSpeed = 15.0f;
        public float mouseSensitivity = 0.2f;
        public float rotationSmoothTime = 0.12f;
        public float movementSmoothTime = 0.1f;
        public bool lockCursor = true;

        private Vector3 currentVelocity;
        private Vector2 currentMouseDelta;
        private Vector2 mouseSmoothVelocity;
        private Vector2 targetMouseDelta;

        private void Start()
        {
            // Initialize with current camera rotation angles
            targetMouseDelta = new Vector2(transform.eulerAngles.x, transform.eulerAngles.y);
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        private void Update()
        {
            LookAround();
            Move();
        }

        private void LookAround()
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            mouseDelta *= mouseSensitivity;

            targetMouseDelta += new Vector2(-mouseDelta.y, mouseDelta.x);
            targetMouseDelta.x = Mathf.Clamp(targetMouseDelta.x, -90f, 90f); // Clamp vertical look to prevent flipping

            currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref mouseSmoothVelocity,
                rotationSmoothTime);
            transform.eulerAngles = new Vector3(currentMouseDelta.x, currentMouseDelta.y, 0f);
        }

        private void Move()
        {
            Vector2 moveInput = new Vector2(
                Keyboard.current.aKey.isPressed ? -1 : Keyboard.current.dKey.isPressed ? 1 : 0,
                Keyboard.current.sKey.isPressed ? -1 : Keyboard.current.wKey.isPressed ? 1 : 0);
            float verticalMoveInput =
                (Keyboard.current.eKey.isPressed ? 1 : 0) - (Keyboard.current.qKey.isPressed ? 1 : 0);

            bool isFast = Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed;
            float speed = isFast ? fastMovementSpeed : movementSpeed;

            Vector3 direction = (transform.forward * moveInput.y + transform.right * moveInput.x +
                                 transform.up * verticalMoveInput);
            Vector3 targetPosition = transform.position + direction * speed * Time.deltaTime;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity,
                movementSmoothTime);
        }
    }
}