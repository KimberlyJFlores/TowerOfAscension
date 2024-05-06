using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBall : MonoBehaviour
{
    [SerializeField] Player player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){ // destroy enemies
            player.Hurt();
            this.gameObject.SetActive(false);
        }
        else if(other.gameObject.tag == "Blockable") // stop projectile from going through platforms
        {
            this.gameObject.SetActive(false);
        }
    }
}
