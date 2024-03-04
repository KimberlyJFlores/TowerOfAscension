using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int hearts = 4;
    [SerializeField] float speed = 1f;

    [Header("Physics")]
    [SerializeField] float jumpRadius = .25f;
    [SerializeField] float jumpOffset = -.5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] LayerMask platformMask;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCreatureTransform(Vector3 direction)
    {
        Vector3 currentVelocity = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = (currentVelocity) + (direction * speed);

        if(rb.velocity.x < 0)
        {
            rb.transform.localScale = new Vector3(-2,2,2);
        }
        else if(rb.velocity.x > 0)
        {
            rb.transform.localScale = new Vector3(2,2,2);
        }
    }

    public void Jump()
    {
        if(Physics2D.OverlapCircleAll(transform.position + new Vector3(0,jumpOffset,0),jumpRadius,platformMask).Length > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

}
