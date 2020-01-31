using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSystem : MonoBehaviour
{
    public List<CarEffects> errors = new List<CarEffects>();

    private List<int> problemsDone = new List<int>();

    public int numberOfErrors = 3;
    private int randomProblem;

    void Start()
    {
        for (int i = 0; i < numberOfErrors; i++)
        {
            randomProblem = Random.Range(1, 4);
            for (int numbers = 0; numbers < problemsDone.Count; numbers++)
            {
                if (problemsDone[numbers] != randomProblem)
                {
                    problemsDone.Add(randomProblem);
                }
                else
                {
                    randomProblem = Random.Range(1, 4);
                }
            }
           

            switch (randomProblem)
            {
                case 1: // pintura
                    errors.Add(new Paint());
                    break;

                case 2: //ruedasWheels
                    errors.Add(new Wheels ());
                    break;

                case 3: // luces
                    errors.Add(new Lights());
                    break;

                case 4: // nada
                    errors.Add(new Nothing());
                    break;

                default: 
                    break;
            }
        }

        for (int i = 0; i < errors.Count; i++)
        {
            //ejecutar 
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
