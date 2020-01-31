using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarEffects
{

}

public class Wheels : CarEffects
{
    private int wheels = 4;
    private void Start()
    {

        if (wheels == 0)
        {
            //1 DONE

        }
       // Debug.Log("Wheels");
    }

    public Wheels()
    {
      //  Debug.Log("Wheels");
    }
}

public class Lights : CarEffects
{
    private bool lights = false;

    private void Start()
    {
        if (lights == true)
        {
            //DONE -lista
        }
       // Debug.Log("Light");
    }

    public Lights()
    {
       // Debug.Log("Lights");
    }

}

public class Paint : CarEffects
{


    //mix colors
    private bool purple; // color 1
    private bool orange; //color 2
    private bool green; // color 3

    private int randomColor;

    private void Start()
    {
        randomColor = Random.Range(1, 3);

        switch (randomColor)
        {
            case 1: // purple

                break;


            case 2://orange
                break;


            case 3: // green
                break;

            default:
                break;
        }
    }

    public Paint()
    {
        //Debug.Log("Paint");
    }

}