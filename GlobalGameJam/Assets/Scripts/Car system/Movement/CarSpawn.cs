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
        //InvokeRepeating("spawn", 3, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void spawn()
    {
        Instantiate(car, this.transform.position, transform.rotation);
    }
}
