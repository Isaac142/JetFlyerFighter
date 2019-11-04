using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public bool isWon = false;
    public bool isWonButton = false;
    public UIManager UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UI.winUI.SetActive(isWon);
        UI.winButton.SetActive(isWonButton);
    }
}
