using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSystem : MonoBehaviour
{

    private InputMaster controls;
    private Animator animationWorkTable;
    private float x;

    private int player;

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
        if (GetComponent<Animator>() != null)
        {
            animationWorkTable = this.GetComponent<Animator>();
            animationWorkTable.enabled = false;
        }


        controls.Player1.Interact.started += ctx => x = ctx.ReadValue<float>();
        controls.Player1.Interact.started += ctx => player = 1;
        controls.Player1.Interact.canceled += ctx => x = 0;

        controls.Player2.Interact.started += ctx => x = ctx.ReadValue<float>();
        controls.Player2.Interact.started += ctx => player = 2;
        controls.Player2.Interact.canceled += ctx => x = 0;

        controls.Player3.Interact.started += ctx => x = ctx.ReadValue<float>();
        controls.Player3.Interact.started += ctx => player = 3;
        controls.Player3.Interact.canceled += ctx => x = 0;

        controls.Player4.Interact.started += ctx => x = ctx.ReadValue<float>();
        controls.Player4.Interact.started += ctx => player = 4;
        controls.Player4.Interact.canceled += ctx => x = 0;
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
        if (other.CompareTag("Player") && x == 1 && player == other.GetComponent<PlayerMovement>().PlayerNumber)
        {
            if (other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject == true)
            {
               
                other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject = false;
                Destroy(other.GetComponentInChildren<PlayerInventary>().GetComponentsInChildren<Transform>()[1].gameObject);
            }
            
         
        }
    }

   
}
