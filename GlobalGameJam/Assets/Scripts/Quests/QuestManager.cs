﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public GameObject car;

    public Image[] images;
    public Sprite[] icons;

    public Image progressBar;

    public float time = 5f;
    public float InitialTime = 5f;

    private void Update()
    {
        progressBar.fillAmount = (time / InitialTime) - 0.083f;
        time -= Time.deltaTime;

        if(time <= 0 && time > -500)
        {
            GetComponent<AudioSource>().Play();
            time = -500;
            car.GetComponent<CarSystem>().debugFinish = true;
                        
            Destroy(gameObject, 0.5f);
        }
    }

    public void SetupQuest(List<CarEffects> errors)
    {
        int f = 0;
        
        if(errors.Count == 2)
        {
            Destroy(images[2].transform.gameObject);
        }
        else if(errors.Count == 1)
        {
            Destroy(images[2].transform.gameObject);
            Destroy(images[1].transform.gameObject);


        }

        foreach (CarEffects x in errors)
        {
            switch (x.typeOfEffect())
            {
                
                case "lights":
                    images[f].sprite = icons[1];
                    break;
                case "wheels":
                    images[f].sprite = icons[5];
                    break;
                case "paint":
                    images[f].sprite = icons[2];
                    break;
                case "engine":
                    images[f].sprite = icons[0];
                    break;
                case "oil":
                    images[f].sprite = icons[6];
                    break;
            }
            f++;
        }

       
    }

    private void OnDestroy()
    {
        GetComponent<AudioSource>().Stop();
    }
}
