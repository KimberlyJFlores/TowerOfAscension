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
    [SerializeField] List<GameObject> heartDisplay;
    public bool faceRight = true;
    int heartDisplayIdx = 3;
    [SerializeField] private List<AnimationStateChanger> animationStateChangers;
    AudioSource[] soundEffects;

    [SerializeField] ContactFilter2D colFilter;
    Collider2D col;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        soundEffects = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCreatureTransform(Vector3 direction)
    {
        Vector3 currentVelocity = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = (currentVelocity) + (direction * speed);

        if(direction != Vector3.zero){
            foreach(AnimationStateChanger asc in animationStateChangers){
                asc.ChangeAnimationState("Walk",1);
            }
            if(rb.velocity.x < 0)
            {
                rb.transform.localScale = new Vector3(-2,2,2); // flip left
                faceRight = false;
            }
            else if(rb.velocity.x > 0)
            {
                rb.transform.localScale = new Vector3(2,2,2); // flip right
                faceRight = true;
            }
        }
        else
        {
            foreach(AnimationStateChanger asc in animationStateChangers){
                asc.ChangeAnimationState("Idle");
            }
        }
    }

    public void Jump()
    {
        var results = new Collider2D[5];
        if(Physics2D.OverlapCollider(col, colFilter, results) > 0)
        {
            
            soundEffects[0].Play(); // jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void PickupCoin()
    {
        soundEffects[5].Play();
        ScoreCounter.singleton.RegisterCoin();
    }

    public void Hurt()
    {
        soundEffects[2].Play();
        if(hearts > 1) // player can get hurt
        {
            hearts -= 1;
            heartDisplay[heartDisplayIdx].gameObject.GetComponent<Renderer>().enabled = false; // hide heart
            heartDisplayIdx -= 1; // move idx back 1 so the next heart can hide
        }
        else // show gameover, send player back to home screen
        {
            soundEffects[3].Play();
            hearts -= 1;
            heartDisplay[heartDisplayIdx].gameObject.GetComponent<Renderer>().enabled = false; // hide heart
            GameObject.Find("GameOverHandler").GetComponent<GameOverHandler>().showGameOver(); // show game over
        }
    }

    public void Teleport(Vector3 teleportTo)
    {
        this.transform.position = teleportTo;
    }

}
