using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseY = 0f;
    public float Yrotation;
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
        this.mouseY = Input.GetAxis("MouseY");

        //transform.Rotate(new Vector3(mouseY, 0, 0) * Time.deltaTime * sensY);
        
        this.Yrotation += mouseY * Time.deltaTime * sensY;

        Yrotation = Mathf.Clamp(Yrotation, -90, 90);

        transform.localRotation = Quaternion.Euler(Yrotation, 0, 0);
    }
}
