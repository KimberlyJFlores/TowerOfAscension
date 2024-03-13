using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private ScreenFader screenFader;
    public void Play()
    {
        screenFader.FadeToColor("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

