using System.Collections;
using UnityEngine;

public class ground : MonoBehaviour
{

    public float leftXBoundary;
    public float rightXBoundary;
    public float horizontalMovementSpeed;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private bool movingLeft;
    private bool isColliding = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        rigidBody.velocity = new Vector2(horizontalMovementSpeed, 0);
        movingLeft = horizontalMovementSpeed < 0;
    }

    void Update()
    {
        if ((rigidBody.transform.position.x <= leftXBoundary && movingLeft) || (rigidBody.transform.position.x >= rightXBoundary && !movingLeft))
        {
            rigidBody.velocity = new Vector2(horizontalMovementSpeed *= -1, 0);
            rigidBody.transform.Rotate(0, 180, 0);
            movingLeft = !movingLeft;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            if (!isColliding)
            {
                isColliding = true;
                GetComponent<BoxCollider2D>().enabled = false;
                Camera.main.BroadcastMessage("ApplyScore", 50);
                StartCoroutine(SetDestroyTimer());
            }
        }
    }

    private IEnumerator SetDestroyTimer()
    {
        animator.SetTrigger("hit");
        rigidBody.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.25f);

        Destroy(gameObject);
    }
}
