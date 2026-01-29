using UnityEngine;

public class GamepadControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 120f;

    void Update()
    {
        HandleControllerInput();
    }

    void HandleControllerInput()
    {
        //Left stick
        float stickX = Input.GetAxis("Horizontal"); //X
        float stickY = Input.GetAxis("Vertical");   //Y

        //Button movement
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.JoystickButton0)) //A
            moveZ += 1f;

        if (Input.GetKey(KeyCode.JoystickButton1)) //B
            moveZ -= 1f;

        if (Input.GetKey(KeyCode.JoystickButton2)) //X
            moveX -= 1f;

        if (Input.GetKey(KeyCode.JoystickButton3)) //Y
            moveX += 1f;

        moveZ += stickY;

        Vector3 movement = (transform.forward * moveZ + transform.right * moveX).normalized;

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        //Left stick rotation
        transform.Rotate(Vector3.up * stickX * turnSpeed * Time.deltaTime);
    }
}
