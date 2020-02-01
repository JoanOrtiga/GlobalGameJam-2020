using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPickUp : MonoBehaviour
{
    public GameObject lightObjet;
    private InputMaster controls;

    private GameObject childGameObject;

    private float x;
    private void Awake()
    {
        controls = new InputMaster();
        controls.Player1.Sprint.started += ctx => x = ctx.ReadValue<int>();
        controls.Player1.Sprint.canceled += ctx => x = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && x == 1)
        {
            Debug.Log("Grabing a light");
            lightObjet.transform.position = GameObject.Find("HandsPosition").transform.position;
            childGameObject = Instantiate(lightObjet);

            childGameObject.transform.parent = GameObject.Find("HandsPosition").transform; //haciendo light hijo d ela posicion de las manos
        }  
    }

    private void FixedUpdate()
    {
        Debug.Log(x);
    }
}
