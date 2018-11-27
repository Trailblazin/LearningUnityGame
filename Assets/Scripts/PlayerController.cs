using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float runningSpeed = 1.5f;
    public float jumpMagnitude = 20f;
    public Animator animator;
    public LayerMask groundLayer;
    public static PlayerController instance;

    private Rigidbody2D rigidBody;
    private Vector2 initialPosition;

    //Used to make sure that object components is assigned before the game starts
    void Awake()
    {
        //Created singleton object for player controller
        instance = this;   
        //Created rigidBody variable to hold rigidbody data
        rigidBody = GetComponent<Rigidbody2D>();
        //Assigns the position of the Player object on initialization to initialPostion
        initialPosition = this.transform.position;
    }

    //Used to initialize the player logic in the game, referenced in GameManager
    public void StartGame()
    {
        //Sets the animator live state to true.
        animator.SetBool("isAlive", true);
        //Alters the position of this game object to that assigned in intialPosition
        this.transform.position = initialPosition;
    }

    // Update called on each frame for constant events
    void Update ()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {


            //If the LMB is clicked, the player will jump
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }

            //Sets the animator state depending on if the player is grounded
            animator.SetBool("isGrounded", IsGrounded());

        }
	}

    private void FixedUpdate()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            if (rigidBody.velocity.x < runningSpeed)
            {
                rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
            }
        }
    }

    void Jump()
    {  //On call, applys an instant upwards vertical force using rigidbody mass
        if (IsGrounded())
        {
            rigidBody.AddForce(Vector2.up * jumpMagnitude, ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        //If there is a distance of less than 0.2 between the gameObject and any groundlayer object; return true.
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void KillPlayer()
    {
        //Changes the game state to Game Over
        GameManager.instance.GameOver();

        //Sets the animator state for a live player to false, effectively "killing" the player
        animator.SetBool("isAlive", false);
    }
}
