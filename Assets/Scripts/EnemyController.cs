using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform leftPoint;
    public Transform rightPoint;
    private bool movingRight = true;

    private Rigidbody rb;
    //private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (movingRight)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, -moveSpeed);
            //sr.flipX = false;
            if (transform.position.z <= rightPoint.position.z)
                movingRight = false;
        }
        else
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, moveSpeed);
            //sr.flipX = true;
            if (transform.position.z >= leftPoint.position.z)
                movingRight = true;
        }


    }




    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.name == "ball1")
        {
            GameManager.Instance.Score();
            Destroy(gameObject);
        }

    }
}