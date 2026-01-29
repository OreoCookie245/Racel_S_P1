using UnityEngine;

public class KeyboardOnlyControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 90f; //degrees per second

    void Update()
    {
        HandleMovementAndTurning();
    }

    void HandleMovementAndTurning()
    {
        float moveZ = 0f;
        float turnY = 0f;

        if (Input.GetKey(KeyCode.T))
            moveZ += 1f;

        if (Input.GetKey(KeyCode.G))
            moveZ -= 1f;

        //Left movement + left camera rotation
        if (Input.GetKey(KeyCode.F))
        {
            turnY -= 1f;
        }

        //Right movement + right camera rotation
        if (Input.GetKey(KeyCode.H))
        {
            turnY += 1f;
        }

        //Movement
        Vector3 movement = (transform.forward * moveZ).normalized;

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        //Camera direction
        transform.Rotate(Vector3.up * turnY * turnSpeed * Time.deltaTime);
    }
}
