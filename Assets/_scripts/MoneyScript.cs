using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoneyScript : MonoBehaviour
{
    public float rotateSpeed = 90;
    FPC_Motion playerMovement;
    private void OnTriggerEnter (Collider c)
    {
        if(c.gameObject.tag != "Player")
        {
            return;
        }
        GameControl.control.addScore();
        Destroy(gameObject);
        playerMovement.speed += 0.03f;
    }
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<FPC_Motion>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        if(GameControl.control.score == 100)
        {
            SceneManager.LoadScene(1);
        }
    }
}
