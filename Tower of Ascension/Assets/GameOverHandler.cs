using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private ScreenFader screenFader;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false); // hide gameover text initially
    }

    public void showGameOver()
    {
        StartCoroutine(showGameOverCoroutine());
        IEnumerator showGameOverCoroutine()
        {
            gameOverText.gameObject.SetActive(true); // show gameover text, go to main menu
            yield return new WaitForSeconds(5);
            screenFader.FadeToColor("MainMenu");
        }
    }
}
