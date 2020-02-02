using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limits : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().position = new Vector2(3.29f, 1.19f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().position = new Vector2(3.29f, 1.19f);
        }
    }
}
