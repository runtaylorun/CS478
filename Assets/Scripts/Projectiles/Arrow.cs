using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Arrow")
        {
            Physics2D.IgnoreCollision(col, GetComponent<PolygonCollider2D>());
        }

        if (col.gameObject.tag == "Platform")
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            StartCoroutine(SetDestroyTimer());
        }

        // Add extra cases here for collisions with other types of objects e.g Enemies, destructable objects
    }

    private IEnumerator SetDestroyTimer()
    {
        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
    }
}
