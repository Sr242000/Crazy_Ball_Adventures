using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Transform cameraTransform;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // If camera not assigned, automatically find main camera
        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void FixedUpdate()
    {
        MoveBall();
    }

    void MoveBall()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A and D keys
        float vertical = Input.GetAxis("Vertical");     // W and S keys

        // Direction based on camera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Ignore vertical rotation (we don't want ball to move up/down based on camera pitch)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * vertical + right * horizontal).normalized;

        rb.AddForce(moveDirection * moveSpeed, ForceMode.Force);
    }
}
