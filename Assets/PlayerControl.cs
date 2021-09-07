using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // racket is RigidBody2D
    private Rigidbody2D rigidBody2D;
    
    // Button to move racket upwards
    public KeyCode upButton = KeyCode.W;

    // Button to move racket downwards
    public KeyCode downButton = KeyCode.S;

    // racket movement speed
    public float speed = 10.0f;

    // Gameplay scene boundary
    public float yBoundary = 9.0f;

    // Player1 score
    private int score;

    // Last contact point with the ball
    private ContactPoint2D lastContactPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get racket velocity.
        Vector2 velocity = rigidBody2D.velocity;

        // If player press up button, add positive speed to y component (upwards).
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }
 
        // If player press down button, add negative speed to y component (downwards).
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }

        // If player doesn't press any button, the velocity is 0.
        else
        {
            velocity.y = 0.0f;
        }
 
        // Assign the velocity to rigidBody2D.
        rigidBody2D.velocity = velocity;

        // Get current racket position.
        Vector3 position = transform.position;
 
        // If racket position exceeds upper boundary (yBoundary), return the racket to upper boundary.
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }
 
        // If racket position exceeds lower boundary (-yBoundary), return the racket to lower boundary.
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }
 
        // Assign the position
        transform.position = position;
    }

    // Menaikkan skor sebanyak 1 poin
    public void IncrementScore()
    {
        score++;
    }

    // Mengembalikan skor menjadi 0
    public void ResetScore()
    {
        score = 0;
    }

    // Mendapatkan nilai skor
    public int Score
    {
        get { return score; }
    }

    // Access last contact point from other class
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    // When collide with the ball, record the contact point.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
}
