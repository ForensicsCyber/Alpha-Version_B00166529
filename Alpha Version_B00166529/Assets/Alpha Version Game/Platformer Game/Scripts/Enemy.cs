using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveDistance = 5f; // Distance to move back and forth
    public float moveSpeed = 2f;   // Speed of movement
    private Vector3 startPosition;
    private bool isGameOver = false; // Tracks if the game is over
    private bool movingRight = true; // Tracks the current direction of movement

    // Start is called before the first frame update
    void Start()
    {
        // Record the initial position of the enemy
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            // Stop movement when the game is over
            return;
        }

        MoveEnemy();
    }

    private void MoveEnemy()
    {
        // Calculate the new position
        float targetX = startPosition.x + (movingRight ? moveDistance : -moveDistance);
        float step = moveSpeed * Time.deltaTime;

        // Move the enemy towards the target position
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), step);

        // Reverse direction if the enemy reaches the target position
        if (Mathf.Approximately(transform.position.x, targetX))
        {
            movingRight = !movingRight;
        }
    }

    // This method can be called to trigger game over
    public void TriggerGameOver()
    {
        isGameOver = true;
    }
}
