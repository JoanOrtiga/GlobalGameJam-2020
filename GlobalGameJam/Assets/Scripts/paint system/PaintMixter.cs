using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMixter : MonoBehaviour
{
    public float timeToMakePaint = 5;

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
    private bool finishMix = false;

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
        Debug.Log(finishMix);
        //Debug.Log(timeToMakePaint);
        

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (finishMix == true && x == 1)
            {
                purpleGameObject.transform.position = GameObject.FindWithTag("Player").transform.position;
                greenGameObject.transform.position = GameObject.FindWithTag("Player").transform.position;
                orangeGameObject.transform.position = GameObject.FindWithTag("Player").transform.position;

                childGameObject.transform.parent = other.transform.GetComponentInChildren<PlayerInventary>().transform; //haciendo object hijo de la posicion de las manos

                GameObject.FindWithTag("Player").transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject = true;
                finishMix = false;
            }

            //PRIMERA PARTE
            if ((other.GetComponentInChildren<PlayerInventary>().playerHaveAObject) && x == 1)
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
            timeToMakePaint -= Time.deltaTime;
            if (timeToMakePaint <= 0)
            {
                
                purpleGameObject.transform.position = this.gameObject.transform.position;
                childGameObject = Instantiate(purpleGameObject);
                finishMix = true;

                purple = false;
                timeToMakePaint = 5;
            }
        }

        else if (orange ==true)
        {
            timeToMakePaint -= Time.deltaTime;
            if (timeToMakePaint <= 0)
            {

                orangeGameObject.transform.position = this.gameObject.transform.position;
                childGameObject = Instantiate(orangeGameObject);
                finishMix = true;

                orange = false;
                timeToMakePaint = 5;
            }
        }
         else if (green == true)
        {
            timeToMakePaint -= Time.deltaTime;
            if (timeToMakePaint <= 0)
            {

                greenGameObject.transform.position = this.gameObject.transform.position;
                childGameObject = Instantiate(greenGameObject);
                finishMix = true;

                green = false;
                timeToMakePaint = 5;
            }
        }



    }
    
  
}
