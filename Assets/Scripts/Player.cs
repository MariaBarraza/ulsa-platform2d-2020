using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Platform2DUtils.GameplaySystem;

public class Player : Character2D
{
     [SerializeField] Color rayColor = Color.red;
     [SerializeField, Range(0.1f, 20f)] float rayDistance = 5f;
    [SerializeField] LayerMask groundLayer;


      void Update()
    {
        GameplaySystem.TMovementDelta(this.transform,moveSpeed);
        
    }
        void FixedUpdate()
    {
        if(Grounding)
        {
             if(GameplaySystem.JumpBtn)
            {
            anim.SetTrigger("Jump");
            GameplaySystem.Jump(rb2D,jumpForce);
            }
        }
    }

    //hace lo mismo que el update pero se ejecuta despues de el
    void LateUpdate()
    {
        spr.flipX = FlipSprite;
        anim.SetFloat("axisX", Mathf.Abs(GameplaySystem.Axis.x));
       
    }

    
         bool Grounding
        {
          
            get => Physics2D.Raycast(transform.position,Vector2.down,rayDistance,groundLayer);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = rayColor;
            Gizmos.DrawRay(transform.position, Vector2.down *  rayDistance);
        }
}
