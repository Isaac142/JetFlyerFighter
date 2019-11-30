using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Win : MonoBehaviour
{

    public GameObject youWin;

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

        if (other.gameObject.tag == "Win")
        {
            Debug.Log("You Win");
            youWin.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
