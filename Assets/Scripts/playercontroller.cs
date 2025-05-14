using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float maxVelocity = 10f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement Input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Apply force for rolling movement
        Vector3 force = new Vector3(moveZ, 0, -moveX) * moveSpeed;
        rb.AddForce(force, ForceMode.Acceleration);

        // Jumping logic
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Limit max speed
        rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxVelocity);
    }

    // Ground check using raycast
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.Score();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "killer")
        {
            if(!GameManager.Instance.gameOver)
            {
                GameManager.Instance.GameOver();
                moveSpeed = 0;
            }
            print("object killed");
        }

        if(collision.gameObject.tag == "flag")
        {
            print("Completed");
            collision.gameObject.GetComponent<Animator>().SetInteger("complete", 1);
        }

        if(collision.gameObject.tag == "enemy")
        {
            GameManager.Instance.Score();
        }
    }
}
