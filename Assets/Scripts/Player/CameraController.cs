using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float sensY = 1000f;

    public Camera cam;
    

    //Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("MouseY");

        transform.Rotate(new Vector3(mouseY, 0, 0) * Time.deltaTime * sensY);

        sensY = Mathf.Clamp(sensY, -60, 60);
        //I don't know what's wrong...

    }
}
