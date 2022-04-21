using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Shows in Unity
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 passingAction = new Vector2 (15f,15f);

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myPlayerCollider;
    BoxCollider2D myFeetCollider;
    float gravityStart;

    bool isAlive = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myPlayerCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityStart = myRigidbody.gravityScale;
    }

    void Update()
    {
        if(myRigidbody.velocity.magnitude > 30)
        {
            myRigidbody.velocity = Vector2.ClampMagnitude(myRigidbody.velocity, 30);
        }

        if(!isAlive)
        {
            return;
        }
        Run();
        FlipSprite();   
        ClimbLadder();
        Passing();
    }

    void OnMove(InputValue value) 
    {
        if(!isAlive)
        {
            return;
        }

        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(!isAlive)
        {
            return;
        }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool HorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", HorizontalSpeed);
    }

    void FlipSprite()
    {
        bool HorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (HorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        } 
    }

    void ClimbLadder()
    {
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidbody.gravityScale = gravityStart;
            myAnimator.SetBool("isClimbing", false);
            return;
        }

        Vector2 climbVelocity = new Vector2 (myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;

        bool VerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", VerticalSpeed);
    }

    void Passing()
    {
        if(myPlayerCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Traps")))
        {
            isAlive = false;
            Camera.main.BroadcastMessage("ApplyScore", -250);
            myAnimator.SetTrigger("isPassing");
            myRigidbody.velocity = passingAction;
            FindObjectOfType<Session>().ProcessPlayerDeath();
        }
    }
}
