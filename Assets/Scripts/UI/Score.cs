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
        scoreText.text = score.ToString();
    }

    void ApplyScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
