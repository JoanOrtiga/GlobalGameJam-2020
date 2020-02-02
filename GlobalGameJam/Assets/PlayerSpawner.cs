using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player2, player3, player4;

    private InputMaster controls;

    private bool player2b, player3b, player4b;

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


            controls.Player2.Interact.started += ctx => player2b = true;
        controls.Player2.Interact.canceled -= ctx; 
            controls.Player2.Move.started += ctx => player2b = true;
            controls.Player2.Move.canceled += ctx => controls.Player2.Disable();
            controls.Player2.Sprint.started += ctx => player2b = true;
            controls.Player2.Sprint.canceled += ctx => controls.Player2.Disable();

            controls.Player3.Interact.started += ctx => player3b = true;
            controls.Player3.Interact.canceled += ctx => controls.Player3.Disable();
            controls.Player3.Move.started += ctx => player3b = true;
            controls.Player3.Move.canceled += ctx => controls.Player3.Disable();
            controls.Player3.Sprint.started += ctx => player3b = true;
            controls.Player3.Sprint.canceled += ctx => controls.Player3.Disable();

            controls.Player4.Interact.started += ctx => player4b = true;
            controls.Player4.Interact.canceled += ctx => controls.Player4.Disable();
            controls.Player4.Move.started += ctx => player4b = true;
            controls.Player4.Move.canceled += ctx => controls.Player4.Disable();
            controls.Player4.Sprint.started += ctx => player4b = true;
            controls.Player4.Sprint.canceled += ctx => controls.Player4.Disable();
    }

    private void Update()
    {
        if (player2b)
        {
            player2b = false;
            Instantiate(player2, new Vector2(1.55f, 0.9f), transform.rotation);
            controls.Player2.Disable();
        }

        if (player3b)
        {
            player3b = false;
            Instantiate(player3, new Vector2(1.55f, 0.9f), transform.rotation);
            controls.Player3.Disable();
        }
        if (player4b)
        {
            player4b = false;
            Instantiate(player4, new Vector2(1.55f, 0.9f), transform.rotation);
            controls.Player4.Disable();
        }
    }
}
