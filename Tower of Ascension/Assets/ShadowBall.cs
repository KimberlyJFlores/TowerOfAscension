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
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "Blockable") // stop projectile from going through platforms
        {
            Destroy(this.gameObject);
        }
    }
}
