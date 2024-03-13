using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float speed = 5;

    public void Launch(bool faceRight)
    {
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        if(faceRight)
        {
            newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.right * speed;
        }
        else // facing left, flipping sprite
        {
            newProjectile.GetComponent<Rigidbody2D>().velocity = -newProjectile.transform.right * speed;
            newProjectile.GetComponent<Rigidbody2D>().transform.localScale = new Vector3(-1,1,1);
        }
        Destroy(newProjectile,15);
    }
}
