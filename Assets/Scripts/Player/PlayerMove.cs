using UnityEngine;

namespace spaceExplorer.player
{
    public class PlayerMove : MonoBehaviour
    {
        private InputSystem_Actions action;
        public Transform playerTransform { get; set; }
        private Vector3 moveDir;
        private float moveSpeed = 5f;
        public bool isMoving {  get; private set; }
        private void Start()
        {
            moveDir = playerTransform.position;
            isMoving = false;
            action = new InputSystem_Actions();
            action.Enable();
        }

        private void Update()
        {
            HandleMove();
        }

        public void HandleMove()
        {
            Vector2 inputMoveDir = action.Player.Move.ReadValue<Vector2>();
            moveDir = new Vector3(inputMoveDir.x, inputMoveDir.y, 0);
            if (moveDir != Vector3.zero)
            {
                isMoving = true;
                moveDir = moveDir.normalized;
                playerTransform.position += moveDir * moveSpeed * Time.deltaTime;
            }
            else
            {
                isMoving = false;
            }
        }
    }
}

