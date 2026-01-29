using UnityEngine;

public class KeyboardAndMouseControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;

    public Transform camera;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Look();
        Move();
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Vertical
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        camera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Horizontal
        transform.Rotate(Vector3.up * mouseX);
    }

    void Move()
    {
        float moveX = 0f;
        float moveZ = 0f;

        //Control Keys
        if (Input.GetKey(KeyCode.A))
            moveX -= 1f;

        if (Input.GetKey(KeyCode.D))
            moveX += 1f;

        if (Input.GetKey(KeyCode.W))
            moveZ += 1f;

        if (Input.GetKey(KeyCode.S))
            moveZ -= 1f;

        Vector3 move = (transform.right * moveX + transform.forward * moveZ).normalized;
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}
