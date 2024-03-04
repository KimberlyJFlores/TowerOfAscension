using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] Player playerCreature; //gets access to the Creature script
    SpriteRenderer sr;
    // ProjectileThrower projectileThrower;

    void Start()
    {
        // projectileThrower = playerCreature.GetComponent<ProjectileThrower>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;
        
        if(Input.GetKey(KeyCode.A))
        {
            input.x += -1;
        }

        if(Input.GetKey(KeyCode.D))
        {
            input.x += 1;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerCreature.Jump();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            // projectileThrower.Launch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        playerCreature.MoveCreatureTransform(input);
    }
}

