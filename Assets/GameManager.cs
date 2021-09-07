using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Player1
    public PlayerControl player1; // scipt
    private Rigidbody2D player1Rigidbody;
 
    // Player2
    public PlayerControl player2; // scipt
    private Rigidbody2D player2Rigidbody;
 
    // Ball
    public BallControl ball; // scipt
    private Rigidbody2D ballRigidbody;
    private CircleCollider2D ballCollider;

    public int maxScore;

    // Start is called before the first frame update
    // Initiate Rigid bodies and colliders
    private void Start()
    {
        player1Rigidbody = player1.GetComponent<Rigidbody2D>();
        player2Rigidbody = player2.GetComponent<Rigidbody2D>();
        ballRigidbody = ball.GetComponent<Rigidbody2D>();
        ballCollider = ball.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Showing stuffs on GUI
    void OnGUI()
    {
        // Show Player1 score on top-left and Player2 on top-right
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + player1.Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + player2.Score);
 
        // Restart button
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            // When pressed, reset player1 & player2 score...
            player1.ResetScore();
            player2.ResetScore();
           
            // ...and restart the game.
            ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }
 
        // If Player1 reach max score, ...
        if (player1.Score == maxScore)
        {
            // ...show "PLAYER ONE WINS" on the left side of the screen...
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 10, 2000, 1000), "PLAYER ONE WINS");
 
            // ...and reset ball position to center.
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        // If Player2 reach max score, ...
        else if (player2.Score == maxScore)
        {
            // ...show "PLAYER TWO WINS" on the right side of the screen... 
            GUI.Label(new Rect(Screen.width / 2 + 30, Screen.height / 2 - 10, 2000, 1000), "PLAYER TWO WINS");
 
            // ...and reset ball position to center.
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}
