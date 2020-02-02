using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn2 : MonoBehaviour
{
    public GameObject player3;

    private InputMaster controls;

    private bool player3b;

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
        controls.Player3.Interact.started += ctx => player3b = true;
        controls.Player3.Move.started += ctx => player3b = true;
        controls.Player3.Sprint.started += ctx => player3b = true;

    }

    private void Update()
    {
        if (player3b)
        {
            player3b = false;
            Instantiate(player3, new Vector2(1.55f, 0.9f), transform.rotation);
            Destroy(gameObject);

            controls.Player3.Disable();
        }

    }
}
