using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Navigation : MonoBehaviour
{

    public GameObject levelSelection;
    public GameObject mainMenu;
    public Animator transition;

    public void ShowLevelSelection()
    {
        levelSelection.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMainScreen()
    {
        mainMenu.SetActive(true);
        levelSelection.SetActive(false);
    }

    public void LoadMainMenu()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("lives", 3);
        StartCoroutine(LoadScene("Main Menu"));
    }

    public void LoadLevel1()
    {
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("lives", 3);
        StartCoroutine(LoadScene("Level_1"));
    }

    public void LoadLevel2()
    {
        if(LevelUnlocked("level2Unlocked"))
        {
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.SetInt("lives", 3);
            StartCoroutine(LoadScene("Level_2"));
        }
    }

    public void LoadLevel3()
    {
        if(LevelUnlocked("level3Unlocked"))
        {
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.SetInt("lives", 3);
            StartCoroutine(LoadScene("Level_3"));
        }
    }

    private bool LevelUnlocked(string prefName)
    {
        return PlayerPrefs.GetInt(prefName, 0) == 1;
    }

    private IEnumerator LoadScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(sceneName);
    }
    
}
