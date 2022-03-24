using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using System.Collections;
using NUnit.Framework;

public class MainMenu
{
    [SetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("Assets/Scenes/Main Menu.unity");
    }

    [UnityTest]
    public IEnumerator PlayButtonShowsLevelSelectionOnClick()
    {
        yield return new WaitForSeconds(3);

        var playButton = GameObject.Find("playBtn");
        var playButtonComponent = playButton.GetComponent<Button>();

        playButtonComponent.onClick.Invoke();

        yield return new WaitForSeconds(0.1f);

        var levelSelection = GameObject.Find("levelSelection");
        var mainMenu = GameObject.Find("mainMenu");

        Assert.AreEqual(true, levelSelection.activeInHierarchy);
        Assert.AreEqual(null, mainMenu);
    }
}
