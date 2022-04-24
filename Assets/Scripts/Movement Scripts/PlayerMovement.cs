using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Shows in Unity
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 passingAction = new Vector2 (15f,15f);
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource footstepsSound;
    [SerializeField] AudioSource climbSound;
    [SerializeField] AudioSource bounceSound;
    [SerializeField] AudioSource deathSound;

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    BoxCollider2D playerCollider;
    float gravityStart;

    bool isAlive = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
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
        if(moveInput.y != 0 && playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")) && isAlive)
        {
            climbSound.Play();
        }
        else
        {
            climbSound.Pause();
        }

        if(moveInput.x != 0 && isAlive)
        {
            footstepsSound.Play();
        }
        else
        {
            footstepsSound.Pause();
        }
            
    }

    void OnJump(InputValue value)
    {
        if(!isAlive)
        {
            return;
        }
        if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            jumpSound.Play();
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
        if(!playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
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
        if(playerCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Traps")))
        {
            isAlive = false;
            deathSound.Play();
            footstepsSound.Pause();
            Camera.main.BroadcastMessage("ApplyScore", -75);
            myAnimator.SetTrigger("isPassing");
            GetComponent<BoxCollider2D>().enabled = false;
            myRigidbody.velocity = passingAction;
            FindObjectOfType<Session>().ProcessPlayerDeath();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "mushroom")
        {
            bounceSound.Play();
        }
    }
}
