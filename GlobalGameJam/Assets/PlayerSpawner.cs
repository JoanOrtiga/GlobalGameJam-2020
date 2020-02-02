using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player2;

    private InputMaster controls;

    private bool player2b;

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
            controls.Player2.Move.started += ctx => player2b = true;
            controls.Player2.Move.canceled += ctx => controls.Player2.Disable();
            controls.Player2.Sprint.started += ctx => player2b = true;
            controls.Player2.Sprint.canceled += ctx => controls.Player2.Disable();
    }

    private void Update()
    {
        if (player2b)
        {
            player2b = false;
            Instantiate(player2, new Vector2(1.55f, 0.9f), transform.rotation);
            Destroy(gameObject);
            controls.Player2.Disable();
        }
    }
}
