using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Navigation : MonoBehaviour
{

    public GameObject levelSelection;
    public GameObject mainMenu;

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

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void LoadLevel2()
    {
        if(PlayerPrefs.GetInt("level2Unlocked", 0) == 1)
        {
            SceneManager.LoadScene("Level_2");
        }
    }

    public void LoadLevel3()
    {
        if(PlayerPrefs.GetInt("level3Unlocked", 0) == 1)
        {
            SceneManager.LoadScene("Level_3");
        }
    }
    
}
