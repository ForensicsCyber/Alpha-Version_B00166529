using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 4f;         // Adjust speed as needed
    private float jumpForce = 4f;     // Initial jump force
    private int jumpCount = 0;        // Track the number of jumps

    private Rigidbody playerRb;
    public GameManager gameManager;   // Reference to GameManager script

    // Add public variables for the sound effects
    public AudioClip jumpSound;       // Sound for jumping
    public AudioClip pickupSound;     // General pickup sound (for all items)
    private AudioSource audioSource;  // Reference to the AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector3(speed * move, playerRb.velocity.y);

        // Flip the player based on movement direction, but prevent flipping when moving left
        if (move != 0)
        {
            Vector3 localScale = transform.localScale;

            // Only flip when moving right (positive direction)
            if (move > 0)
            {
                localScale.x = Mathf.Abs(localScale.x); // Ensure facing right
            }
            else if (move < 0)
            {
                // Do not flip when moving left, just move in the left direction
                // localScale.x = -Mathf.Abs(localScale.x); // This line is removed to avoid flipping
            }
            transform.localScale = localScale;
        }

        // Jump logic
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumpCount < 2)  // Allow jump if within double-jump limit
            {
                float jumpMultiplier;

                // Use if-else to determine the jump multiplier
                if (jumpCount == 1)
                {
                    jumpMultiplier = 2f;  // Double the force on the second jump
                }
                else
                {
                    jumpMultiplier = 1f;  // Normal jump force
                }

                playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce * jumpMultiplier, playerRb.velocity.z);

                jumpCount++;  // Increment jump count

                // Play the jump sound when the player jumps
                if (audioSource != null && jumpSound != null)
                {
                    audioSource.PlayOneShot(jumpSound);  // Play the jump sound once
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Reset jump count when colliding with ground
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }

        // Destroy objects and update the corresponding counts when player collides with them
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject); // Destroy the coin object
            gameManager.IncreaseCoinCount(); // Update the coin count in the GameManager
        }
        else if (other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject); // Destroy the star object
            gameManager.IncreaseStarCount(); // Update the star count in the GameManager
        }
        else if (other.gameObject.CompareTag("Diamond"))
        {
            Destroy(other.gameObject); // Destroy the diamond object
            gameManager.IncreaseDiamondCount(); // Update the diamond count in the GameManager
        }
        else if (other.gameObject.CompareTag("Treasure"))
        {
            Destroy(other.gameObject); // Destroy the treasure object
            gameManager.IncreaseTreasureCount(); // Update the treasure count in the GameManager
        }

        // Play the pickup sound when any collectible is picked up
        if (other.gameObject.CompareTag("Coin") || other.gameObject.CompareTag("Star") ||
            other.gameObject.CompareTag("Diamond") || other.gameObject.CompareTag("Treasure"))
        {
            // Play the general pickup sound
            if (audioSource != null && pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound);  // Play the pickup sound once
            }
        }
    }
}
