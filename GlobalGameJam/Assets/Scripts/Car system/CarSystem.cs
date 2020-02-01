using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSystem : MonoBehaviour
{
    public List<CarEffects> errors = new List<CarEffects>();

    public int numberOfErrors = 3;
    private int randomProblem;

    void Awake()
    {
        for (int i = 0; i < numberOfErrors; i++)
        {
            CarEffects item = null;

            int counter = 0;
            bool whil = false;

            do
            {
                whil = false;
                randomProblem = Random.Range(1, 5);
                switch (randomProblem)
                {
                    case 1: // pintura
                        item = new Paint();
                        break;

                    case 2: //ruedasWheels
                        item = new Wheels();
                        break;

                    case 3: // luces
                        item = new Lights();
                        break;

                    case 4: // nada
                        item = null;
                        print("hola");
                        break;
                }

            //    print(item);

                counter++;
                if (counter > 10)
                {
                    print("PENE");
                    break;
                }

                if(item != null)
                {
                    foreach (CarEffects x in errors)
                    {
                        if (x.typeOfEffect() == item.typeOfEffect())
                        {
                            whil = true;
                        }
                    }
                }
                
            } 
            while (whil);

            if(item != null)
            {
                errors.Add(item);
            }
            
        }

        for (int e = 0; e < errors.Count; e++)
        {
            print(errors[e]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
