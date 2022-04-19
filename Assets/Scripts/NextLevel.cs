using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public Animator transition;
    void OnTriggerEnter2D(Collider2D other)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt($"level{nextScene}Unlocked", 1);

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 1;
        }

        StartCoroutine(LoadNextScene(nextScene));
    }

    private IEnumerator LoadNextScene(int nextScene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(nextScene);
    }
}
