using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Obstacle : MonoBehaviour
{
    FPC_Motion playerMovement;
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<FPC_Motion>();
    }

    private void OnTriggerEnter (Collider c)  
    {
        if(c.tag.Equals("Player"))
        {
            Debug.Log("I collided with Obstacle");
            SceneManager.LoadScene(0);
        }
    }
    void Update()
    {
        
    }
}
