using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject car;
    

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(car, this.transform.position, transform.rotation);
    }

    public void spawn()
    {
        Instantiate(car, this.transform.position, transform.rotation);
    }
}
