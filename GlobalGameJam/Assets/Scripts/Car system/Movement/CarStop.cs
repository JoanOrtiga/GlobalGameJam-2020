using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStop : MonoBehaviour
{

   public bool carStopped = false;
    public GameObject carSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(carStopped == true && collision.CompareTag("Car"))
        {
            collision.GetComponent<Rigidbody2D>().position += new Vector2(0.05f,0);
            collision.GetComponent<CarMovement>().move = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(carStopped == false && collision.CompareTag("Car"))
        {
            collision.GetComponent<CarMovement>().move = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {
            if (!collision.GetComponent<CarMovement>().inMechanic)
            {
                collision.GetComponent<CarMovement>().move = false;
                collision.GetComponent<CarMovement>().inMechanic = true;
                collision.GetComponent<CarSystem>().carStop = gameObject;
                carSpawner.GetComponent<CarSpawn>().spawn();
                carStopped = true;
            }
            
        }
    }
}
