using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    public Sprite muteOnSprite;
    public Sprite muteOffSprite;
    public Button muteButton;

    void Start()
    {
        if(PlayerPrefs.GetInt("mute", 0) == 0)
        {
            muteButton.image.sprite = muteOffSprite;
            AudioListener.pause = false;
        }
        else
        {
            muteButton.image.sprite = muteOnSprite;
            AudioListener.pause = true;
        }
    }

    public void ToggleMute()
    {
        if(PlayerPrefs.GetInt("mute", 0) == 0)
        {
            muteButton.image.sprite = muteOnSprite;
            PlayerPrefs.SetInt("mute", 1);
            AudioListener.pause = true;
        }
        else
        {
            muteButton.image.sprite = muteOffSprite;
            PlayerPrefs.SetInt("mute", 0);
            AudioListener.pause = false;
        }
    }
}
