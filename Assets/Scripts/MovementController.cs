using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    float speed = 4;
    float rotationSpeed = 80;
    float rot = 0f;
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
        if(controller.isGrounded){
            if(Input.GetKey (KeyCode.UpArrow)){
                anim.SetInteger ("condition", 1);
                movDir = new Vector3 (0, 0, 1);
                movDir *= speed;
                movDir = transform.TransformDirection (movDir);
            }
            if(Input.GetKeyUp (KeyCode.UpArrow)){
                anim.SetInteger ("condition", 0);
                movDir = new Vector3 (0, 0, 0);
                
            }

        }
        rot += Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3 (0, rot, 0);

        movDir.y -= gravity * Time.deltaTime;
        controller.Move (movDir * Time.deltaTime);
    }
}
