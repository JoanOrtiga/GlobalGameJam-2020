using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum paintings
{
    blue_paint, red_paint, yellow_paint, orange_paint, purple_paint, green_paint
}

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

    public virtual paintings paintColor()
    {
        return paintings.blue_paint;
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
    public paintings paint_color;

    public Paint()
    {
        paint_color = (paintings)Random.Range(1, 7);
    }

    public override paintings paintColor()
    {
        return paint_color;
    }

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