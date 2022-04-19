using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = score.ToString();
    }

    void ApplyScore(int amount)
    {
        score += amount;
        PlayerPrefs.SetInt("score", score);
        scoreText.text = score.ToString();
    }
}
