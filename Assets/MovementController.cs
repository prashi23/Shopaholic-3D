using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    float speed = 4;
    float rotationSpeed = 80;
    float gravity = 8;

    Vector3 movDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
        anim = GetComponent<Animator> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller){
            if(Input.GetKey (KeyCode.W)){
                movDir = new Vector3 (0, 0, 1);
                movDir *= speed;
            }
        }

        movDir.y -= gravity * Time.deltaTime;
        controller.Move (movDir * Time.deltaTime);
    }
}
