using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private ScreenFader screenFader;
    [SerializeField] private GameObject menuCanvas;

    void Start()
    {
        GameObject.Find("MenuCanvas").SetActive(false);
    }
    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        screenFader.FadeToColor("MainMenu");
    }

    public void ShowPauseMenu()
    {
        menuCanvas.SetActive(true);
    }

    public void HidePauseMenu()
    {
        menuCanvas.SetActive(false);
    }   
}
