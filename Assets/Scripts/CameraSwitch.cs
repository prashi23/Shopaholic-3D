using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    Animator anim;
    GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.enabled = !anim.enabled;
            GetComponent<CameraFollow>().enabled = true;
            
        }
    }
}
