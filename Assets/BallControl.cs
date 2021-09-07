using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
 
    public float xInitialForce;
    public float yInitialForce;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        // Start the game
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetBall()
    {
        // Reset ball position to (0,0)
        transform.position = Vector2.zero;
 
        // Reset ball velocity to (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        // Pick random Initial force value for y component
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        float randomDirection = Random.Range(0, 2);

        // If direction <1, push the ball to the left and vice versa. 
        if (randomDirection < 1.0f)
        {
            // Apply the force to the ball.
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }

    void RestartGame()
    {
        // Reset ball position
        ResetBall();
 
        // Apply force to the ball after 2 seconds
        Invoke("PushBall", 2);
    }

    
}
