using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn4 : MonoBehaviour
{
    public GameObject player4;

    private InputMaster controls;

    private bool player4b;

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

        controls.Player4.Interact.started += ctx => player4b = true;
        controls.Player4.Move.started += ctx => player4b = true;
        controls.Player4.Sprint.started += ctx => player4b = true;
    }

    private void Update()
    {
        if (player4b)
        {
            player4b = false;
            Instantiate(player4, new Vector2(1.55f, 0.9f), transform.rotation);
            Destroy(gameObject);
            controls.Player4.Disable();
        }
    }
}
