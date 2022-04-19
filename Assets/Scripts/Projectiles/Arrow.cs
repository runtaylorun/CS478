using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Arrow")
        {
            Physics2D.IgnoreCollision(col, GetComponent<BoxCollider2D>());
        }

        if(col.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(col, GetComponent<BoxCollider2D>());
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Platform" || col.gameObject.tag == "Ground")
        {
            StartCoroutine(SetDestroyTimer());
        }
    }

    private IEnumerator SetDestroyTimer()
    {
        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }
}
