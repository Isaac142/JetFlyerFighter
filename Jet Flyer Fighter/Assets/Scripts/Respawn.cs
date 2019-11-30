using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject player;

    public GameObject youLost;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This was apart of the "die" and "respawn"

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.CompareTag("Rocket"))
        {
            Debug.Log("hit");
            //Destroy(player);
            youLost.SetActive(true);
            Time.timeScale = 0f;
            player.GetComponent<Renderer>().material.color = Color.green;
            //SceneManager.LoadScene("_Scene_0");
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
