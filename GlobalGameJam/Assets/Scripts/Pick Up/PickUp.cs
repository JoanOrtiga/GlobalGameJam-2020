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
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        print(x);
        if (other.CompareTag("Player") && x == 1)
        {
            if (other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject == false)
            {
                Debug.Log("Grabing a light");
                objectToPickUp.transform.position = other.transform.GetComponentInChildren<PlayerInventary>().transform.position;
                childGameObject = Instantiate(objectToPickUp);

                childGameObject.transform.parent = other.transform.GetComponentInChildren<PlayerInventary>().transform; //haciendo light hijo d ela posicion de las manos

                other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject = true;
                animationWorkTable.enabled = true;
                


            }
            
        }
    }

   
    
}
