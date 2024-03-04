using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed = 5f;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position +offset;
        transform.position = Vector3.Lerp(
                                        transform.position,
                                        new Vector3(transform.position.x,desiredPosition.y,transform.position.z),
                                        smoothSpeed*Time.deltaTime
                                        ); //interpolation!!
    }
}
