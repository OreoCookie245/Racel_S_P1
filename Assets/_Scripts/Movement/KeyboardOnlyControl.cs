using UnityEngine;

public class KeyboardOnlyControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 90f; //degrees per second

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
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

        //Rotation
        transform.Rotate(Vector3.up * turnY * turnSpeed * Time.fixedDeltaTime);

        //Movement using Rigidbody
        Vector3 move = transform.forward * moveZ * moveSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }
}
