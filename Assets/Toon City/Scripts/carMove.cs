using UnityEngine;
using System.Collections;
public class carMove : MonoBehaviour
{

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime); //
    }
}
