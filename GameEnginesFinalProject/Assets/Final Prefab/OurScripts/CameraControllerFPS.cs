using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControllerFPS : MonoBehaviour
{
    public float sensitivity = 2f;
    private float xRotation = 0f;
    private Vector2 lookInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor
    }

    // Called automatically by the Input System (via Player Input component)
    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        // Re-lock cursor if player clicks while it's unlocked, doesn't fire weapon
        if (Mouse.current.leftButton.wasPressedThisFrame && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            return;
        }

        float mouseX = lookInput.x * sensitivity;
        float mouseY = lookInput.y * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the vertical rotation to prevent flipping

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotate the camera vertically
        transform.parent.Rotate(Vector3.up * mouseX); // Rotate
    }
}