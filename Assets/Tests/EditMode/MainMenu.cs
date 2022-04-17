using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
using NUnit.Framework;

public class MainMenu
{
    [SetUp]
    public void LoadScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Main Menu.unity", OpenSceneMode.Single);
    }

    [Test]
    public void MainMenuCanvasVisible()
    {
        var mainMenu = GameObject.Find("mainMenu");


        Assert.AreEqual(true, mainMenu.activeInHierarchy);
    }

    [Test]
    public void MainMenuScalesByScreenSize()
    {
        var mainMenu = GameObject.Find("mainMenu");
        var canvasScaler = mainMenu.GetComponent<CanvasScaler>();


        Assert.AreEqual("ScaleWithScreenSize", canvasScaler.uiScaleMode.ToString());
    }

    [Test]
    public void MuteButtonVisible()
    {
        var muteButton = GameObject.Find("mute");


        Assert.AreEqual(true, muteButton.activeInHierarchy);
    }

    [Test]
    public void PlayButtonVisible()
    {
        var playButton = GameObject.Find("playBtn");


        Assert.AreEqual(true, playButton.activeInHierarchy);
    }

    [Test]
    public void ExitButtonVisible()
    {
        var exitButton = GameObject.Find("exitBtn");



        Assert.AreEqual(true, exitButton.activeInHierarchy);
    }
}
