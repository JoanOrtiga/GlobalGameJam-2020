using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineMachine : MonoBehaviour
{
    public GameObject objectToPickUp;

    private InputMaster controls;
    private float x;
    public Canvas canvas;
    private bool reparing = false;
    private bool somethingRepared = false;

    public float fillAmount = 0.01f;

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
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && x == 1)
        { 
            if (other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject == true)
            {
                if(other.GetComponentInChildren<PlayerInventary>().GetComponentInChildren<itemInHand>().inHand == Item.engine_broken && reparing != true)
                {
                    other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject = false;
                    Destroy(other.GetComponentInChildren<PlayerInventary>().GetComponentsInChildren<Transform>()[1].gameObject);
                    GetComponent<Animator>().SetBool("Working", true);
                    canvas.gameObject.SetActive(true);
                    reparing = true;
                }
            }
            else
            {
                if (reparing)
                {
                    canvas.transform.GetChild(1).GetComponent<Image>().fillAmount += fillAmount;

                    if (canvas.transform.GetChild(1).GetComponent<Image>().fillAmount == 1)
                    {
                        canvas.transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
                        canvas.gameObject.SetActive(false);
                        GetComponent<Animator>().SetBool("Working", false);

                        reparing = false;
                        somethingRepared = true;
                    }
                }
                else
                {
                    if (somethingRepared)
                    {
                        GameObject childGameObject;
                         objectToPickUp.transform.position = other.transform.GetComponentInChildren<PlayerInventary>().transform.position;
                        childGameObject = Instantiate(objectToPickUp);

                        childGameObject.transform.parent = other.transform.GetComponentInChildren<PlayerInventary>().transform; //haciendo object hijo de la posicion de las manos

                        other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject = true;

                        somethingRepared = false;
                    }
                }
                
            }
        }
    }   
}
