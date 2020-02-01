using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSystem : MonoBehaviour
{

    private InputMaster controls;
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
        controls.Player1.Interact.started += ctx => x = ctx.ReadValue<float>();
        controls.Player1.Interact.canceled += ctx => x = 0;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && x == 1)
        {
            if (other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject == true)
            {
                Debug.Log("DESTROY");
                other.transform.GetComponentInChildren<PlayerInventary>().playerHaveAObject = false;
                Destroy(other.GetComponentInChildren<PlayerInventary>().GetComponentsInChildren<Transform>()[1].gameObject);
            }
            
         
        }
    }

   
}
