using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character2D
{
    [SerializeField]
    float delay;
    float timer;

    [SerializeField]
    Vector2 dir;

    void Update()
    {
        transform.Translate(dir * moveSpeed * Time.deltaTime);

        timer +=  Time.deltaTime;
        if(timer >= delay)
        {
            timer = 0f;
            dir.x = dir.x > 0 ? -1 : 1;
            IFlip flip = new NPCFlip();
            spr.flipX = flip.FlipSprite(dir.x, spr);
        }
    }

}
