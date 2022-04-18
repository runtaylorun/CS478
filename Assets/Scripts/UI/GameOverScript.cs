using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour

{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Animator transition;

    private bool isGameOver = false;
    
    void Start()
    {
        //Disables panel if active
        gameOverPanel.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        //Trigger game over manually and check with bool so it isn't called multiple times
        if (player == null && !isGameOver)
        {
            isGameOver = true;
            
            StartCoroutine(GameOverSequence());
        }
        
        //If game is over
        if (player == null && isGameOver)
        {
            //If R is hit, restart the current scene
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartLevel();
            }
            
            //If Q is hit, quit the game
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Exit();
            }
        }
        
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        print("Application Quit");
        SceneManager.LoadScene("Main Menu");
    }

    //controls game over canvas and there's a brief delay between main Game Over text and option to restart/quit text
    private IEnumerator GameOverSequence()
    {
        yield return new WaitForSeconds(1.0f);

        gameOverPanel.GetComponent<Canvas>().enabled = true;
    }
}