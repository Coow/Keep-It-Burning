using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreCounter;
    public int score = 0;
    private float scoreTimer = 5f;
    private float timer;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            timer += Time.deltaTime;
            if (timer > scoreTimer)
            {
                AddScore(10);
                timer = 0;
            }
        }

    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreCounter.text = "Score: " + score;
    }
}
