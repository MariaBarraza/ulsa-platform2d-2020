using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2DUtils.GameplaySystem;

public class Player : Character2D
{

    void FixedUpdate()
    {
        if(GameplaySystem.JumpBtn)
        {
            if(Grounding)
            {
                anim.SetTrigger("jump");
                GameplaySystem.Jump(rb2D, jumpForce);
            }
        }
        anim.SetBool("grounding", Grounding);
    }

    void Update()
    {
        GameplaySystem.TMovementDelta(transform, moveSpeed);
    }

    void LateUpdate()
    {
        spr.flipX = FlipSprite;
        anim.SetFloat("axisX", Mathf.Abs(GameplaySystem.Axis.x));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("collectable"))
        {
            Collectable collectable = other.GetComponent<Collectable>();
            Gamemanager.instance.Score.AddPoints(collectable.Points);
            //score.AddPoints(collectable.Points);
            Destroy(other.gameObject);
        }
    }
}
