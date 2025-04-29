using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform leftPoint;
    public Transform rightPoint;
    private bool movingRight = true;

    private Rigidbody rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (movingRight)
        {
            rb.linearVelocity = new Vector3(0, 0, moveSpeed);
            sr.flipX = false;
            if (transform.position.x >= rightPoint.position.x)
                movingRight = false;
        }
        else
        {
            rb.linearVelocity = new Vector3(0, 0, -moveSpeed);
            sr.flipX = true;
            if (transform.position.x <= leftPoint.position.x)
                movingRight = true;
        }
    }


}