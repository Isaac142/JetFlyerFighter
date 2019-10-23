using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour
{

    //public float forwardSpeed = 1.0f;
    public Vector3 userDirection = Vector3.forward;

    public GameObject jetPrefab;
    public float spinSpeed;


    public float boostTime = 2.0f;
    public float currentBoostTime;
    public float boostDelayTime = 5.0f;
    public float currentBoostDelayTime;
    public bool boosting = false;
    public float time;

    public float baseSpeed = 10.0f;
    public float speedBoost = 500.0f;
    public float speed;

    //These fields control the movement of the jet
    public float speedTurn = 30f;
    public float rollMult = -45f;
    //public float pitchMult = 30f;


    public bool canMove = true;
    //Code was for the barrel roll

    //public float smooth = 1f;
    //private Quaternion targetRotation;

    //float rotationLeft = 180;
    //public float rotationSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        currentBoostTime = 0f;
        currentBoostDelayTime = 0f;
        speed = baseSpeed;

        //Code was for the barrel roll

        //targetRotation = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        //Pull in information from the Input class


        if(canMove)
        {
            float xAxis = Input.GetAxis("Horizontal");
            Vector3 pos = transform.localPosition;
            pos.x += xAxis * speedTurn * Time.deltaTime;
            transform.localPosition = pos;
            transform.rotation = Quaternion.Euler(0 * rollMult, 0, xAxis * rollMult);
        }
        
        //float yAxis = Input.GetAxis("Vertical");

        //Change transform.position based on the axes
        
        //pos.y += yAxis * speedTurn * Time.deltaTime;
        

        //The code bellow was for the barrel roll. Didn't work as it wouldnt allow me to spin the plane 360 degrees.

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    targetRotation *= Quaternion.Euler(-5, 0, 180);
        //}
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);

        //Rotate the jet to make it feel more dynamic. Didnt want the jet moving up and down.

        //transform.rotation = Quaternion.Euler(yAxis * rollMult, 0, xAxis * rollMult);

        //Rotate the jet to make it feel more dynamic
        

        //float rotation = rotationSpeed * Time.deltaTime;


        //The code bellow was for the barrel roll. Didn't work as it constantly made the jet spin, or not work at all.

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (rotationLeft > rotation)
        //    {
        //        rotationLeft -= rotation;
        //    }
        //}
        //else
        //{
        //    rotation = rotationLeft;
        //    rotationLeft = 0;
        //}
        //transform.Rotate(0, 0, rotation);
    }

    private void FixedUpdate()
    {
        //transform.Translate(userDirection * speed * Time.deltaTime);

        BoostJet();
    }

    IEnumerator BarrelRoll()
    {
        //These go at the top of script
        //float speed;
        //bool canRotate;

        //These go in here
        //speed *= 2f;
        //canRotate = false;
        canMove = false;

        float timeToRoll = 2f;
        float timer = 0f;
        Vector3 start = Vector3.zero;
        Vector3 target = new Vector3(0, 0, 360f);
        while (timer < timeToRoll)
        {                                                                                                   //The commented lines are the lines of code Max showed to make it simpler,
                                                                                                            //instead of making a new function
            timer += Time.deltaTime;
            transform.eulerAngles = Vector3.Lerp(start, target, (timer / timeToRoll));
            transform.RotateAround(jetPrefab.transform.localPosition, Vector3.forward, spinSpeed * Time.deltaTime);
            yield return null;

        }
        canMove = true;
        //speed /= 2f;
        //canRotate = true;
    }

    void BoostJet()
    {
        if (Input.GetKeyDown(KeyCode.S) && !boosting && Time.time > currentBoostDelayTime)
        {
            currentBoostTime = Time.time + boostTime;
            boosting = true;
            StartCoroutine("BarrelRoll");
        }

        if ((Time.time > currentBoostTime) && boosting)
        {
            boosting = false;
            currentBoostDelayTime = Time.time + boostDelayTime;
        }

        if (boosting)
        {
            speed = speedBoost;
        }

        if (!boosting)
        {
            speed = baseSpeed;
        }
    }
}
