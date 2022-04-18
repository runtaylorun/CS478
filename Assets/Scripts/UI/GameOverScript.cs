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
    
    void Start()
    {
        //Disables panel if active
        gameOverPanel.GetComponent<Canvas>().enabled = false;
    }

    public IEnumerator RestartLevel()
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator Exit()
    {
        print("Application Quit");
        transition.SetTrigger("start");

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("Main Menu");
    }
}