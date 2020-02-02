using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Errors : MonoBehaviour
{
    public int errors = 0;
    private Text text;

    public GameObject lose;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Errors: " + errors + "/3";

        if(errors == 4)
        {
            lose.SetActive(true);
            lose.GetComponentsInChildren<Text>()[1].text = "Score: " + transform.parent.GetComponentInChildren<Score>().score;
            StartCoroutine("Lose");
        }
    }

    IEnumerator Lose()
    {
        yield return new WaitForSeconds(3f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


}
