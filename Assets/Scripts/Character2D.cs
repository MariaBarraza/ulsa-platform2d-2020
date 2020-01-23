using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform2DUtils.GameplaySystem;

public class Character2D : MonoBehaviour
{

    //si se pone protected se puede ver en todo lo que lo herede
    protected SpriteRenderer spr;
    protected Animator anim;

    protected Rigidbody2D rb2D;

    [SerializeField,Range(1f,10f)] protected float jumpForce = 7f;

    [SerializeField] protected float moveSpeed = 7f;

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

   protected bool FlipSprite
    {
        //Operacion ternaria
        // condicion ? si es verdad : si es falso
        get => GameplaySystem.Axis.x < 0f ? true : GameplaySystem.Axis.x > 0 ? false : spr.flipX;
    }
 
}
