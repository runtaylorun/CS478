using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    private bool isCollidingWithArrow = false;
    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2 (moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        FlipEnemy();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Arrow" && !isCollidingWithArrow)
        {
            isCollidingWithArrow = true;
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Camera.main.BroadcastMessage("ApplyScore", 100);
            StartCoroutine(DestroyTimer());
        }
    }

    void FlipEnemy()
    {
        transform.localScale = new Vector2 ((Mathf.Sign(myRigidbody.velocity.x)) , 1f);
    }

    private IEnumerator DestroyTimer()
    {
        gameObject.GetComponent<Animator>().SetTrigger("hit");
        myRigidbody.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.25f);

        Destroy(gameObject);
    }
}
