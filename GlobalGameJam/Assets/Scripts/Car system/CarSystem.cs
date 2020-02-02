using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSystem : MonoBehaviour
{
    public GameObject carStop;
    public GameObject carQuest;

    public List<GameObject> carEffects = new List<GameObject>();

    private GameObject mom;

    public List<CarEffects> errors = new List<CarEffects>();

    public int numberOfErrors = 3;
    private int randomProblem;

    public bool debugFinish = false;

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
                randomProblem = Random.Range(1, 7);
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
                        break;

                    case 5:
                        item = new Engine();
                        break;

                    case 6:
                        item = new Oil();
                        break;
                }

                counter++;
                if (counter > 10)
                {
                    print("PENE");
                    break;
                }

                if (item != null)
                {
                    foreach (CarEffects x in errors)
                    {
                        if (x.typeOfEffect() == "oil" || x.typeOfEffect() == "engine" || x.typeOfEffect() == "paint")
                        {
                            if (x.typeOfEffect() == item.typeOfEffect())
                            {
                                whil = true;
                            }
                        }
                        else if (x.typeOfEffect() == "wheels" || x.typeOfEffect() == "lights")
                        {
                            if (x.typeOfEffect() == item.typeOfEffect())
                            {
                                if (x.effPosition() == item.effPosition())
                                {
                                    whil = true;
                                }
                            }
                        }
                    }
                }

            }
            while (whil);

            if (item != null)
            {
                if (item.typeOfEffect() == "oil")
                {
                    carEffects[9].SetActive(true);
                }
                else if (item.typeOfEffect() == "engine")
                {
                    carEffects[0].SetActive(true);
                }
                else if (item.typeOfEffect() == "wheels" || item.typeOfEffect() == "lights")
                {
                    if (item.typeOfEffect() == "wheels")
                    {
                        
                        switch (item.effPosition())
                        {
                            case carPositions.front_left:
                                carEffects[1].SetActive(true);
                                break;
                            case carPositions.front_right:
                                carEffects[2].SetActive(true);
                                break;
                            case carPositions.back_left:
                                carEffects[3].SetActive(true);
                                break;
                            case carPositions.back_right:
                                carEffects[4].SetActive(true);
                                break;
                        }
                    }
                    else if (item.typeOfEffect() == "lights")
                    {

                        switch (item.effPosition())
                        {
                            case carPositions.front_left:
                                carEffects[5].SetActive(true);
                                break;
                            case carPositions.front_right:
                                carEffects[6].SetActive(true);
                                break;
                            case carPositions.back_left:
                                carEffects[7].SetActive(true);
                                break;
                            case carPositions.back_right:
                                carEffects[8].SetActive(true);
                                break;
                        }
                    }
                }
                else if(item.typeOfEffect() == "paint")
                {
                    carEffects[10].SetActive(true);

                    print(carEffects[10]);
                    
                    foreach(Component em in carEffects[10].GetComponents(typeof(Component)))
                    {
                        print(em);
                    }

                    print(carEffects[10].GetComponent<FixObject>());

                    switch (item.paintColor())
                    {
                        case paintings.blue_paint:
                            carEffects[10].GetComponent<FixObject>().whatToDetect = Item.blue_paint;
                            break;
                        case paintings.red_paint:
                            carEffects[10].GetComponent<FixObject>().whatToDetect = Item.red_paint;
                            break;
                        case paintings.yellow_paint:
                            carEffects[10].GetComponent<FixObject>().whatToDetect = Item.yellow_paint;
                            break;
                        case paintings.orange_paint:
                            carEffects[10].GetComponent<FixObject>().whatToDetect = Item.orange_paint;
                            break;
                        case paintings.purple_paint:
                            carEffects[10].GetComponent<FixObject>().whatToDetect = Item.purple_paint;
                            break;
                        case paintings.green_paint:
                            carEffects[10].GetComponent<FixObject>().whatToDetect = Item.green_paint;
                            break;
                    }
                }

                errors.Add(item);
            }

         //   print(item);
        }

        //for (int i = 0; i < carEffects.Count; i++)
        //{
        //    int fails = 0;
        //    foreach (CarEffects item in errors)
        //    {
        //        if (item.typeOfEffect() == "oil" || item.typeOfEffect() == "engine" /*|| item.typeOfEffect() == "paint"*/)
        //        {
        //            print(carEffects[i].GetComponent<FixObject>().whatToDetect.ToString() + " " + item.typeOfEffect());

        //            if(carEffects[i].GetComponent<FixObject>().whatToDetect.ToString() != item.typeOfEffect())
        //            {
        //                fails++;
        //            }
        //        }
        //        else if (item.typeOfEffect() == "wheels" || item.typeOfEffect() == "lights")
        //        {
        //            if (x.typeOfEffect() == item.typeOfEffect())
        //            {
        //                if (x.effPosition() == item.effPosition())
        //                {
        //                    whil = true;
        //                }
        //            }
        //        }
        //    }
        //}

        //for (int i = 0; i < errors.Count; i++)
        //{
        //    print(errors[i]);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (debugFinish)
        {
            errors.Clear();
            this.GetComponent<CarMovement>().move = true;
            carStop.GetComponent<CarStop>().carStopped = false;
            debugFinish = false;

            Destroy(this.gameObject, 5f);
        }

    }
    public void createQuest()
    {
        GameObject questCanvas = GameObject.FindGameObjectWithTag("Quest");

        mom = Instantiate(carQuest, questCanvas.transform);
        mom.GetComponent<QuestManager>().SetupQuest(errors);
        mom.GetComponent<QuestManager>().car = gameObject;

    }

    public void repared(string repaired)
    {
        //carQuest.GetComponent<QuestManager>().Repaired(repaired, errors);

        int f = 0;

        foreach (CarEffects item in errors)
        {
            if (item.typeOfEffect() == repaired)
            {
                mom.transform.GetChild(f).GetComponent<Image>().enabled = false;
                errors.Remove(item);
                break;
            }
            f++;
        }

        if(errors.Count == 0)
        {
            mom.transform.Find("Tic").GetComponent<Image>().enabled = true;
            mom.GetComponent<QuestManager>().finish();debugFinish = true;
        }
    }
}
