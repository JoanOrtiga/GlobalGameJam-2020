using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject objectToPickUp;
    private InputMaster controls;

    private GameObject childGameObject;
    private Animator animationWorkTable;

    private float x;

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
        animationWorkTable = this.GetComponent<Animator>();
        animationWorkTable.enabled = false;

        controls.Player1.Interact.started += ctx => x = ctx.ReadValue<float>();
        controls.Player1.Interact.canceled += ctx => x = 0;

        controls.Player2.Interact.started += ctx => x = ctx.ReadValue<float>();
        controls.Player2.Interact.canceled += ctx => x = 0;

  //      controls.Player3.Interact.started += ctx => x = ctx.ReadValue<float>();
   //     controls.Player3.Interact.canceled += ctx => x = 0;

    //    controls.Player4.Interact.started += ctx => x = ctx.ReadValue<float>();
    //    controls.Player4.Interact.canceled += ctx => x = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (collision.GetComponent<PlayerMovement>().PlayerNumber)
            {
                case 1:
                    controls.Player1.Enable();
                    break;
                case 2:
                    controls.Player2.Enable();
                    break;
                case 3:
                    controls.Player3.Enable();
                    break;
                case 4:
                    controls.Player4.Enable();
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (collision.GetComponent<PlayerMovement>().PlayerNumber)
            {
                case 1:
                    controls.Player1.Disable();
                    break;
                case 2:
                    controls.Player2.Disable();
                    break;
                case 3:
                    controls.Player3.Disable();
                    break;
                case 4:
                    controls.Player4.Disable();
                    break;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        print(x);
        if (other.CompareTag("Player") && x == 1)
        {
            if (other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject == false)
            {
                
                objectToPickUp.transform.position = other.transform.GetComponentInChildren<PlayerInventary>().transform.position;
                childGameObject = Instantiate(objectToPickUp);

                childGameObject.transform.parent = other.transform.GetComponentInChildren<PlayerInventary>().transform; //haciendo object hijo de la posicion de las manos

                other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject = true;
                animationWorkTable.enabled = true;
            }   
        }
    }

   
    
}
