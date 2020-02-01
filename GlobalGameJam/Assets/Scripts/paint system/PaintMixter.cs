using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMixter : MonoBehaviour
{
    public float timeToMakePaint = 5;

    //Primate colors
    private bool blue = false;
    private bool red = false;
    private bool yellow = false;


    //mixt colors
    private bool purple = false;
    private bool orange = false;
    private bool green = false;

   

    private int maxColors = 2;
   
    // Update is called once per frame
    void Update()
    {
        Mixter();

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
        }
    }

    void Mixter()
    {
        if (yellow == true && red == true)
        {
            orange = true;
            yellow = false;
            red = false;
            countDown();
        }
        else if (blue == true && red == true)
        {
            countDown();
            purple = true;
        }
        else if (yellow == true && blue == true)
        {
            countDown();
            green = true;
        }
    }

    void countDown()
    {
        timeToMakePaint -= Time.deltaTime;

        if (timeToMakePaint == 0)
        {
            if (orange == true)
            {
                //instacia pintura en el inventario
            }
            else if (purple == true)
            {
                //instacia pintura en el inventario
            }
            else if (green == true)
            {
                //instacia pintura en el inventario
            }
            

        }
    }
}
