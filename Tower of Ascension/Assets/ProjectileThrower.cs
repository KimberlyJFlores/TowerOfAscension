using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float speed = 5;
    [SerializeField] int poolSize;
    List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject newFireball = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            newFireball.SetActive(false);
            pool.Add(newFireball);
        }
    }

    public void Launch(bool faceRight)
    {
        foreach(GameObject fireball in pool)
        {
            if( fireball.activeSelf ) continue;
            fireball.transform.position = transform.position;
            fireball.SetActive(true);

            if(faceRight)
            {
                fireball.GetComponent<Rigidbody2D>().velocity = fireball.transform.right * speed;
            }
            else // facing left, flipping sprite
            {
                fireball.GetComponent<Rigidbody2D>().velocity = -fireball.transform.right * speed;
                fireball.GetComponent<Rigidbody2D>().transform.localScale = new Vector3(-1,1,1);
            }
            StartCoroutine(FireballPoolRoutine(fireball));
            break;
        }
    }

    private IEnumerator FireballPoolRoutine( GameObject fireball )
    {
        yield return new WaitForSeconds(15);
        fireball.SetActive(false);
    }
}
