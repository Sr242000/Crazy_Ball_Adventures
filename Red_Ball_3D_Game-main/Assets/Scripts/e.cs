using UnityEngine;

public class ContinuousEnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Speed of the enemy
    public float leftBound = -10f; // Left boundary
    public float rightBound = 10f; // Right boundary
    private int direction = 2; // 1 for right, -1 for left

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        // Move the enemy in the current direction
        transform.position += Vector3.right * speed * direction * Time.deltaTime;

        // Check for boundary conditions
        if (transform.position.z >= rightBound)
        {
            direction = -1; // Change direction to left
        }
        else if (transform.position.z <= leftBound)
        {
            direction = 1; // Change direction to right
        }
    }
}