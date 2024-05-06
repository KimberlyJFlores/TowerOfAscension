using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : MonoBehaviour
{
    [SerializeField] int delay;
    ProjectileThrower projectileThrower;
    // Start is called before the first frame update
    void Start()
    {
        projectileThrower = this.GetComponent<ProjectileThrower>();
        ThrowFireballs();
    }

    void ThrowFireballs()
    {
        StartCoroutine(ThrowFireBallsCoroutine());
        IEnumerator ThrowFireBallsCoroutine()
        {
            while(true)
            {
                yield return new WaitForSeconds(delay);
                this.GetComponent<AudioSource>().Play();
                projectileThrower.Launch(false);
            }
        }
    }
}
