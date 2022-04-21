using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InGame : MonoBehaviour
{
    public Text scoreText;
    public Text lifeText;
    private int score = 0;

    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        lifeText.text = PlayerPrefs.GetInt("lives", 3).ToString();
        scoreText.text = score.ToString();
    }

    void SetLivesText(int numberOfLives)
    {
        lifeText.text = numberOfLives.ToString();
    }

    void ApplyScore(int amount)
    {
        PlayerPrefs.SetInt("score", Math.Max(0, score + amount));
        score = Math.Max(0, score + amount);

        scoreText.text = score.ToString();
    }
}
