using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creacher : MonoBehaviour
{
    [SerializeField] Creacher creacher;
    [SerializeField] Player player;
    ProjectileThrower projectileThrower;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            player.Hurt();
        }
    }
    void Start()
    {
        projectileThrower = creacher.GetComponent<ProjectileThrower>();
        ThrowFireballs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ThrowFireballs()
    {
        StartCoroutine(ThrowFireBallsCoroutine());
        IEnumerator ThrowFireBallsCoroutine()
        {
            while(true)
            {
                yield return new WaitForSeconds(2);
                creacher.GetComponent<AudioSource>().Play();
                projectileThrower.Launch(true);
            }
        }
    }
}
