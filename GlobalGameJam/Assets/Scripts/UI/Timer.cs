using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int minuts;
    public float seconds;

    private Text text;

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
            seconds = 59;
        }

        if(minuts == 0)
        {
            
            text.text = 0 + minuts + ":" + seconds.ToString("F2");
        }
        else
        {
            text.text = minuts + ":" + seconds.ToString("F0");
        }
        
    }
}
