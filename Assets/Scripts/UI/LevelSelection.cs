using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public GameObject level2GameObject;
    public GameObject level3GameObject;
    public Sprite level2Sprite;
    public Sprite level3Sprite;

    void Start()
    {
            var level2Button = level2GameObject.GetComponent<Button>();
            var level3Button = level3GameObject.GetComponent<Button>();

            if(PlayerPrefs.GetInt("level2Unlocked", 0) == 1)
            {
                level2Button.image.sprite = level2Sprite;
            }

            if(PlayerPrefs.GetInt("level3Unlocked", 0) == 1) {
                level3Button.image.sprite = level3Sprite;
            }
    }
}
