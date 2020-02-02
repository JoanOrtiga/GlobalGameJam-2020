using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int minuts;
    public float seconds;

    private Text text;

    public GameObject lose;
    string min, sec;

    

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        text.text = minuts + ":" + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        seconds -= Time.deltaTime;

        if(seconds <= 0)
        {
            minuts--;
            seconds = 60;
        }


        if (minuts < 10)
        {
            min = "0" + minuts;
            
            if(minuts < 0)
            {
                min = "0";
            }
        }


        if(minuts > 0)
        {
            if(seconds < 9.5f)
            {
                sec = "0" + seconds.ToString("F0");
            }
            else
            {
                sec = seconds.ToString("F0");
            }
        }
        else
        {
            if (seconds < 9.5f)
            {
                sec = "0" + seconds.ToString("F2");
            }
            else
            {
                sec = seconds.ToString("F2");
            }
        }

        text.text = min + ":" + sec;

        if(minuts <= 0 && seconds <= 0)
        {
            lose.SetActive(true);

            StartCoroutine("Lose");
        }


    }

    IEnumerator Lose()
    {
        yield return new WaitForSeconds(3f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
