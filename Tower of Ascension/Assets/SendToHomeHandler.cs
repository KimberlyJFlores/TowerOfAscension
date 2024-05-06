using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToHomeHandler : MonoBehaviour
{
    [SerializeField] private ScreenFader screenFader;
    void Start()
    {
        ChangeToHome();
    }

    void ChangeToHome()
    {
        StartCoroutine(GoBackHome());
        IEnumerator GoBackHome(){
            yield return new WaitForSeconds(5);
            screenFader.FadeToColor("MainMenu");
        }
    }
}
