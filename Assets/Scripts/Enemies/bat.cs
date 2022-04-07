using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{

    public float leftXBoundary;
    public float rightXBoundary;
    public float upperYBoundary;
    public float lowerYBoundary;
    public float horizontalMovementSpeed;
    public float verticalMovementSpeed;

    private Rigidbody2D batRigidBody;
    private Animator batAnimator;
    private bool movingLeft;
    private bool movingUp;

    void Start()
    {
        batRigidBody = GetComponent<Rigidbody2D>();
        batAnimator = GetComponent<Animator>();

        batRigidBody.velocity = new Vector2(horizontalMovementSpeed, verticalMovementSpeed);
        movingUp = verticalMovementSpeed > 0;
        movingLeft = horizontalMovementSpeed < 0;
    }

    void Update()
    {
        if((batRigidBody.transform.position.x <= leftXBoundary && movingLeft) || (batRigidBody.transform.position.x >= rightXBoundary && !movingLeft))
        {
            batRigidBody.velocity = new Vector2(horizontalMovementSpeed *= -1, verticalMovementSpeed);
            movingLeft = !movingLeft;
        }

        if((batRigidBody.transform.position.y >= upperYBoundary && movingUp) || (batRigidBody.transform.position.y <= lowerYBoundary && !movingUp))
        {
            batRigidBody.velocity = new Vector2(horizontalMovementSpeed, verticalMovementSpeed *= -1);
            movingUp = !movingUp;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);

            // Subtract score here?
            // Subtract life
            // Game over screen shown if out of lives otherwise send back to start
        }

        if(collision.gameObject.tag == "Arrow")
        {
            StartCoroutine(SetDestroyTimer());

            // Play hit animation
            // Add score here?
        }
    }

    private IEnumerator SetDestroyTimer()
    {
        batAnimator.SetTrigger("hit");
        batRigidBody.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.25f);

        Destroy(this.gameObject);
    }
}
