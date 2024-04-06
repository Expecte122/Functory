using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    float speed = 5f;
    float sensX = 1000f;

    public bool jumped;
    public bool touching_floor;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, 0);

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("MouseX");
        float jump = Input.GetAxis("Jump");

        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * speed);

        transform.Rotate(new Vector3(0, mouseX, 0) * Time.deltaTime * sensX);

        if (rb.velocity.y < 0.1 && !jumped)
        {
            if (jump > 0)
            {
                //rb.AddForce(0,4,0);
                rb.velocity = new Vector3(0, 10, 0);
                jumped = true;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumped = false;
            touching_floor = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (jumped)
        {
            jumped = true;
            touching_floor = false;
        }

    }
}
//ctrl k and u undo/ k and c comment