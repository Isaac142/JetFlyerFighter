using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour
{

    public float forwardSpeed = 1.0f;
    public Vector3 userDirection = Vector3.forward;

    //These fields control the movement of the jet
    public float speed = 30f;
    public float rollMult = -45f;
    //public float pitchMult = 30f;


    public float smooth = 1f;
    private Quaternion targetRotation;

    float rotationLeft = 360;
    public float rotationSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        targetRotation = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        ////Pull in information from the Input class
        //float xAxis = Input.GetAxis("Horizontal");
        ////float yAxis = Input.GetAxis("Vertical");

        ////Change transform.position based on the axes
        //Vector3 pos = transform.position;
        //pos.x += xAxis * speed * Time.deltaTime;
        ////pos.y += yAxis * speed * Time.deltaTime;
        //transform.position = pos;

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    targetRotation *= Quaternion.Euler(-5, 0, 180);
        //}
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);

        //Rotate the jet to make it feel more dynamic
        //transform.rotation = Quaternion.Euler(yAxis * rollMult, 0, xAxis * rollMult);
        //transform.rotation = Quaternion.Euler(0 * rollMult, 0, xAxis * rollMult);

        float rotation = rotationSpeed * Time.deltaTime;

        if (rotationLeft > rotation)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rotationLeft -= rotation;
            }
        }
        else
        {
            rotation = rotationLeft;
            rotationLeft = 0;
        }
        transform.Rotate(0, 0, rotation);
    }

    private void FixedUpdate()
    {
        transform.Translate(userDirection * forwardSpeed * Time.deltaTime);
    }
}
