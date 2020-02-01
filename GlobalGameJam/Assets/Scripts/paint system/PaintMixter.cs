using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintMixter : MonoBehaviour
{
    public float waitTime = 5;
    private float timeToMakePaint;
    public float fillAmount = 0.01f;


    //Primate colors
    private bool blue = false;
    private bool red = false;
    private bool yellow = false;

    private InputMaster controls;

    //mixt colors
    private bool purple = false;
    private bool orange = false;
    private bool green = false;

    //finish Mix
    private bool isMixting = false;
    private bool finishMix = false;
    private bool progresBarWorking = false;

    public Canvas canvas;
    public GameObject purpleGameObject;
    public GameObject orangeGameObject;
    public GameObject greenGameObject;
    private GameObject childGameObject;

    private float x = 1;

    private int maxColors = 2;


    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    private void Awake()
    {
        controls = new InputMaster();
        controls.Player1.Interact.started += ctx => x = ctx.ReadValue<float>();
        controls.Player1.Interact.canceled += ctx => x = 0;

        controls.Player2.Interact.started += ctx => x = ctx.ReadValue<float>();
        controls.Player2.Interact.canceled += ctx => x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Mixter();
        countDown();

       
       
        

    }

    private void Start()
    {
        timeToMakePaint = waitTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (finishMix == true && x == 1) //COgiendo la mezcla
            {
                other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject = true;
                childGameObject.transform.position = other.transform.GetComponentInChildren<PlayerInventary>().transform.position;
                childGameObject.transform.parent = other.transform.GetComponentInChildren<PlayerInventary>().transform; //haciendo object hijo de la posicion de las manos

                
                finishMix = false;
            }

            //PRIMERA PARTE poniendo colores 
            if ((other.GetComponentInChildren<PlayerInventary>().playerHaveAObject) && x == 1 && isMixting == false)
            {
                
                if (other.GetComponentInChildren<PlayerInventary>().transform.GetChild(0).GetComponent<itemInHand>().inHand == Item.blue_paint && blue == false)
                {
                    other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject = false;
                    Destroy(other.GetComponentInChildren<PlayerInventary>().GetComponentsInChildren<Transform>()[1].gameObject);
                    blue = true;
                }
                else if (other.GetComponentInChildren<PlayerInventary>().transform.GetChild(0).GetComponent<itemInHand>().inHand == Item.yellow_paint && yellow == false)
                {
                    other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject = false;
                    Destroy(other.GetComponentInChildren<PlayerInventary>().GetComponentsInChildren<Transform>()[1].gameObject);
                    yellow = true;
                }
                else if(other.GetComponentInChildren<PlayerInventary>().transform.GetChild(0).GetComponent<itemInHand>().inHand == Item.red_paint && red == false)             
                {
                    other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject = false;
                    Destroy(other.GetComponentInChildren<PlayerInventary>().GetComponentsInChildren<Transform>()[1].gameObject);
                    red = true;
                }
            }


            //SEGUNDA PARTE
            

        }
    }

    void Mixter()
    {
        if (yellow == true && red == true)
        {
            orange = true;
            yellow = false;
            red = false;
            
        }
        else if (blue == true && red == true)
        {
           
            blue = false;
            red = false;
            purple = true;
           
        }
        else if (yellow == true && blue == true)
        {
            
            yellow = false;
            blue = false;
            green = true;
           
        }
    }

    void countDown()
    {
        

        if (purple== true)
        {
            ProgresBar();
            isMixting = true;
            timeToMakePaint -= Time.deltaTime;
            if (timeToMakePaint <= 0)
            {
                canvas.transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
                canvas.gameObject.SetActive(false);
                purpleGameObject.transform.position = this.gameObject.transform.position;
                childGameObject = Instantiate(purpleGameObject);
                finishMix = true;
                isMixting = false;

                purple = false;
                timeToMakePaint = 5;
            }
        }

        else if (orange ==true)
        {
            ProgresBar();
            isMixting = true;
            timeToMakePaint -= Time.deltaTime;
            if (timeToMakePaint <= 0)
            {
                canvas.transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
                canvas.gameObject.SetActive(false);
                orangeGameObject.transform.position = this.gameObject.transform.position;
                childGameObject = Instantiate(orangeGameObject);
                finishMix = true;
                isMixting = false;

                orange = false;
                timeToMakePaint = 5;
            }
        }
         else if (green == true)
        {
            ProgresBar();
            timeToMakePaint -= Time.deltaTime;
            isMixting = true;
            if (timeToMakePaint <= 0)
            {
                canvas.transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
                canvas.gameObject.SetActive(false);
                greenGameObject.transform.position = this.gameObject.transform.position;
                childGameObject = Instantiate(greenGameObject);
                finishMix = true;
                isMixting = false;

                green = false;
                timeToMakePaint = 5;
            }
        }
    }

    void ProgresBar()
    {  
        canvas.gameObject.SetActive(true);
        canvas.transform.GetChild(1).GetComponent<Image>().fillAmount += 1.0f / waitTime * Time.deltaTime;       
    }
    
  
}
