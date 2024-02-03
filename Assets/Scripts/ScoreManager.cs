using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    private int score, highScore;

    private void Awake() {
        instance=this;
    }

    private void Start() {
        score=0;
        highScore=0;
    }
    
    private void Update() {
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }

    public void countScore()
    {
        score++;
        if(highScore < score)
            highScore++;
    }

    public void setScoretoZero()
    {
        score=0;
    }
}
