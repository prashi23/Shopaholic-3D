using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayInstructions : MonoBehaviour
{
    public GameObject displayInstructions;

    // Start is called before the first frame update
    void Start()
    {
        displayInstructions.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyUp(KeyCode.Space))
        {
            displayInstructions.SetActive(false);
        }
    }
}
