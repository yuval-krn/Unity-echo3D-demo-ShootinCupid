using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeandScoreUpdater : MonoBehaviour
{

    float currentTime;
    float gameTime = 20f;
    public bool timerStarted = false;
    ButtonDestroyer loser;
    ButtonDestroyer winner;

    int score = 0;

    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text scoreText;

    // Start is called before the first frame update
    private void Start()
    {
        currentTime = gameTime;
        timerText.text = ("Timer: " + currentTime.ToString("f1"));
        scoreText.text = ("Score: " + score.ToString());

        loser = GameObject.Find("EndButton").GetComponent<ButtonDestroyer>();
        loser.PlayGame();

        winner = GameObject.Find("WinButton").GetComponent<ButtonDestroyer>();
        winner.PlayGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                timerStarted = false;
                currentTime = 0;
                loser.EndGame();
                Debug.Log("game over");
            }
            timerText.text = ("Timer: " + currentTime.ToString("f1"));
        }
    }

    
    public void restart()
    {
        currentTime = gameTime;
        timerStarted = true;
        score = 0;
        scoreText.text = ("Score: " + score.ToString());
    }

    public void scoreAdd()
    {
        score++;
        scoreText.text = ("Score: " + score.ToString());
        if (score >= 5)
        {
            winner.EndGame();
            timerStarted = false;
        }
    }
}
