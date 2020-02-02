using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float carSpeed = 4f;
    public bool move = true;
    public bool inMechanic = false;

    private bool questCreated = false;
    // Start is called before the first frame update

    Rigidbody2D rigidbody2d;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        if (move)
            rigidbody2d.position += new Vector2(carSpeed * Time.deltaTime, 0);
        else
        {
            if (questCreated == false && inMechanic == true)
            {
                print("XD");
                questCreated = true;
                GetComponent<CarSystem>().createQuest();
            }
        }
    }


}
