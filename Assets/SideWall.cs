using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    // GameManager script to access maxScore
    [SerializeField]
    private GameManager gameManager; 

    // which player get the score if the ball touch this wall.
    public PlayerControl player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when any object collide with the wall.
    void OnTriggerEnter2D(Collider2D anotherCollider)
    {
        // If the object named "Ball":
        if (anotherCollider.name == "Ball")
        {
            // Add score to player
            player.IncrementScore();

            // If player's score hasn't reach max value...
            if (player.Score < gameManager.maxScore)
            {
                // ...restart game after the ball touch the wall.
                anotherCollider.gameObject.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
