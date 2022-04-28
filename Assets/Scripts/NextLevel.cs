using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public Animator transition;
    public AudioSource transitionSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            int nextScene = currentScene + 1;
            PlayerPrefs.SetInt($"level{nextScene}Unlocked", 1);

            if (nextScene == SceneManager.sceneCountInBuildSettings)
            {
                nextScene = 1;
                PlayerPrefs.SetInt("score", 0);
                PlayerPrefs.SetInt("lives", 3);
            }

            StartCoroutine(LoadNextScene(nextScene));
        }
        
    }

    private IEnumerator LoadNextScene(int nextScene)
    {
        transitionSound.Play();
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(nextScene);
    }
}
