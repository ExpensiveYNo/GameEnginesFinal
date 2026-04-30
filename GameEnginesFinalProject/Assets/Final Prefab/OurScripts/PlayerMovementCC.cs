using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementCC : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 2f;
    public float gravity = -9.81f;

    private CharacterController cc;
    private Vector3 velocity;
    private bool canJump; // tracks if player can jump

    private Vector2 moveInput;
    private bool jumpPressed;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        canJump = true;
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value) //Converted to use InputValue for consistency with new Input System
    {
        if (value.isPressed)
            jumpPressed = true;
    }

    void Update()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

        // Jump only if allowed and grounded
        if (jumpPressed && cc.isGrounded && canJump)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
            canJump = false;
        }
        jumpPressed = false; // consume the press each frame

        // Reset jump when touching the ground
        if (cc.isGrounded && velocity.y <= 0)
        {
            canJump = true;
            velocity.y = -2f;
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Final movement
        Vector3 finalMove = move * speed + velocity;
        cc.Move(finalMove * Time.deltaTime);
    }
}