using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Destructable"){ // destroy enemies
            Destroy(other.gameObject);
            this.gameObject.SetActive(false);
        }
        else if(other.gameObject.tag == "Blockable") // stop projectile from going through platforms
        {
            this.gameObject.SetActive(false);
        }
    }

}
