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

        if(col.gameObject.tag == "Enemies")
        {
            Physics2D.IgnoreCollision(col, GetComponent<PolygonCollider2D>());
            Camera.main.BroadcastMessage("ApplyScore", 100);
        }

        if (col.gameObject.tag == "Platform")
        {
            StartCoroutine(SetDestroyTimer());
        }
    }

    private IEnumerator SetDestroyTimer()
    {
        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
    }
}
