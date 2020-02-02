using System.Collections;
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
                case "engine":
                    images[f].sprite = icons[0];
                    break;
                case "oil":
                    images[f].sprite = icons[6];
                    break;
                case "paint":
                    switch (x.paintColor())
                    {
                        case paintings.blue_paint:
                            images[f].sprite = icons[2];
                            break;
                        case paintings.red_paint:
                            images[f].sprite = icons[4];
                            break;
                        case paintings.yellow_paint:
                            images[f].sprite = icons[3];
                            break;
                        case paintings.orange_paint:
                            images[f].sprite = icons[9];
                            break;
                        case paintings.purple_paint:
                            images[f].sprite = icons[8];
                            break;
                        case paintings.green_paint:
                            images[f].sprite = icons[7];
                            break;
                    }
                    
                    break;
            }
            f++;
        }  


    }

    public void Repaired(string fixing, List<CarEffects> errors)
    {
        int f = 0;
        print(fixing);
        foreach (CarEffects item in errors)
        {
            if(item.typeOfEffect() == fixing)
            {
                transform.GetChild(f).GetComponent<Image>().enabled = false;
            }
            f++;
        }
    }

    private void OnDestroy()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void finish()
    {
        Destroy(gameObject, 0.5f);
    }
}
