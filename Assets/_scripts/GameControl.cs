using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{
    public int score;
    public static GameControl control;
    public Text scoreText;

    public void addScore()
    {
        score++;
        scoreText.text = " " + score;
    }
    private void Awake()
    {
        control = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
