using System.Collections;
using UnityEngine;

public class slime : MonoBehaviour
{

    public float leftXBoundary;
    public float rightXBoundary;
    public float horizontalMovementSpeed;

    private Rigidbody2D slimeRigidBody;
    private Animator slimeAnimator;
    private bool movingLeft;

    void Start()
    {
        slimeRigidBody = GetComponent<Rigidbody2D>();
        slimeAnimator = GetComponent<Animator>();

        slimeRigidBody.velocity = new Vector2(horizontalMovementSpeed, 0);
        movingLeft = horizontalMovementSpeed < 0;
    }

    void Update()
    {
        if ((slimeRigidBody.transform.position.x <= leftXBoundary && movingLeft) || (slimeRigidBody.transform.position.x >= rightXBoundary && !movingLeft))
        {
            slimeRigidBody.velocity = new Vector2(horizontalMovementSpeed *= -1, 0);
            movingLeft = !movingLeft;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);

            // Subtract score here?
            // Subtract life
            // Game over screen shown if out of lives otherwise send back to start
        }

        if (collision.gameObject.tag == "Arrow")
        {
            StartCoroutine(SetDestroyTimer());

            // Play hit animation
            // Add score here?
        }
    }

    private IEnumerator SetDestroyTimer()
    {
        slimeAnimator.SetTrigger("hit");
        slimeRigidBody.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.25f);

        Destroy(this.gameObject);
    }
}
