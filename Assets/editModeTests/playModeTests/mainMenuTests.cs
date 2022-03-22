using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEngine;
using NUnit.Framework;


public class mainMenuTests
{

    [SetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("Main Menu");
    }


    [UnityTest]
    public IEnumerator muteButtonChangesImage()
    {
        yield return new WaitForSeconds(3);

        var mainMenuUI = GameObject.Find("mainMenu");

        var muteButtonGameObject = mainMenuUI.transform.Find("mute");
        var muteButton = muteButtonGameObject.GetComponent<Button>();

        muteButton.onClick.Invoke();

        Assert.AreEqual("mute-on", muteButton.image.sprite.name);
    }

    [UnityTest]
    public IEnumerator muteButtonSavesPlayerPref()
    {
        yield return new WaitForSeconds(3);

        var mainMenuUI = GameObject.Find("mainMenu");

        var muteButtonGameObject = mainMenuUI.transform.Find("mute");
        var muteButton = muteButtonGameObject.GetComponent<Button>();

        muteButton.onClick.Invoke();
        muteButton.onClick.Invoke();

        Assert.AreEqual(1, PlayerPrefs.GetInt("mute"));
    }
}
