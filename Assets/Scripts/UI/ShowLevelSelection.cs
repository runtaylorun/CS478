using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLevelSelection : MonoBehaviour
{

    public GameObject levelSelection;
    public GameObject mainMenu;

    public void Show()
    {
        levelSelection.SetActive(true);
        mainMenu.SetActive(false);
    }
}
