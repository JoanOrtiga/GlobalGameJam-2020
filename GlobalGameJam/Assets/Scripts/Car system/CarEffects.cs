using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum carPositions
{
    front_left, front_right, back_left, back_right, no_position
}

public class CarEffects
{
    public virtual string typeOfEffect()
    {
        return "carEffect";
    }

    public virtual carPositions effPosition()
    {
        return carPositions.no_position;
    }
}

public class Wheels : CarEffects
{
    public carPositions position;

    public Wheels()
    {
        position = (carPositions)Random.Range(1, 5);
    }

    public override string typeOfEffect()
    {
        return "wheels";
    }

    public override carPositions effPosition()
    {
        return position;
    }
}

public class Lights : CarEffects
{
    public carPositions position;

    public Lights()
    {
        position = (carPositions)Random.Range(1, 5);
    }

    public override string typeOfEffect()
    {
        return "lights";
    }

    public override carPositions effPosition()
    {
        return position;
    }

}

public class Paint : CarEffects
{
    //mix colors
    private bool purple; // color 1
    private bool orange; //color 2
    private bool green; // color 3
    public override string typeOfEffect()
    {
        return "paint";
    }

}

public class Engine : CarEffects
{
    public override string typeOfEffect()
    {
        return "engine";
    }
}

public class Oil : CarEffects
{
    public override string typeOfEffect()
    {
        return "oil";
    }
}