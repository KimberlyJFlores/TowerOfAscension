using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] private ScreenFader screenFader;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            screenFader.FadeToColor("EndScreen");
        }
    }
}
