using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int totalScore;
    public bool updateScore;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        updateScore = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (updateScore)
        {
            scoreText.text = ("Score: " + totalScore.ToString("0"));
            updateScore = false;
            //print(totalScore);
        }
    }
}
