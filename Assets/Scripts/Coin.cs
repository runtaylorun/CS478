using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Coin : MonoBehaviour
{

    public int value = 10;
    Tilemap map;

    void Start()
    {
        map = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Camera.main.BroadcastMessage("ApplyScore", value);
            Destroy(gameObject);
        }
    }
}
