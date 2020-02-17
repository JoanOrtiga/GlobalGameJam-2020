using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayTutorialScript : MonoBehaviour
{
    public GameObject tutorial;

    public GameObject startButton;
    public GameObject exitButton;

    public GameObject controls;
    public GameObject credits;
    public GameObject lights;
    public GameObject wheels;
    public GameObject oil;
    public GameObject paint;    
    public GameObject motor;

    private int counter = -1;
    private void Start()
    {
        tutorial.SetActive(false);
    }
    public void StartTutorial()
    {
        Debug.Log("start tutorial");
        tutorial.SetActive(true);
        startButton.SetActive(false);
        exitButton.SetActive(false);
        credits.SetActive(false);
   
        
    }
    public void Next()
    {
        counter++;
        if (counter == 0)
        {
            lights.SetActive(true);
        }
        else if (counter == 1)
        {
            wheels.SetActive(true);       
        }
        else if (counter == 2)
        {
            oil.SetActive(true);
        }
        else if (counter == 3)
        {
            paint.SetActive(true);
        }
        else if (counter == 4)
        {
            motor.SetActive(true);
        }
        else if (counter == 5)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void closeGame()
    {
        Application.Quit();
    }
}
