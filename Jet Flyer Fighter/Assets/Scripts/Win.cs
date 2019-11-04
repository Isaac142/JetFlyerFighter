using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Win : MonoBehaviour
{

    public Test TT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (other.gameObject.CompareTag("Win"))
        {
            Debug.Log("You Win");
            TT.isWon = true;
            TT.isWonButton = true;
        }
    }
}
