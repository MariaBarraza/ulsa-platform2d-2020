﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2DUtils.GameplaySystem;

public class Player : Character2D
{
    [SerializeField]
    float maxVel;
    

    void Update()
    {
        //GameplaySystem.MovementAddForce(rb2D, moveSpeed);
    }

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
        GameplaySystem.MovementAddForce(rb2D, moveSpeed);
        float velXClamp = Mathf.Clamp(rb2D.velocity.x,-maxVel,maxVel);
        rb2D.velocity = new Vector2(maxVel,rb2D.velocity.y);
    }

    void LateUpdate()
    {
        //spr.flipX = FlipSprite;
         IFlip flip = new PlayerFlip();
            spr.flipX=flip.FlipSprite(GameplaySystem.Axis.x,spr);
        anim.SetFloat("axisX", Mathf.Abs(GameplaySystem.Axis.x));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("collectable"))
        {
            Collectable collectable = other.GetComponent<Collectable>();
            Gamemanager.instance.Score.AddPoints(collectable.Points);
            Destroy(other.gameObject);
        }
    }
}
