using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2D : MonoBehaviour
{
    [SerializeField,Range(0.1f,20f)]float moveSpeed = 5f;
    Animator anim;
    SpriteRenderer spr;
    Rigidbody2D rb2D;
    [SerializeField] Color rayColor = Color.red;
     [SerializeField, Range(0.1f, 20f)] float rayDistance = 5f;
    [SerializeField] LayerMask groundLayer;

    [SerializeField,Range(0.1f,20f)] float jumpForce = 7f;

    //Se ejecuta antes que start y se ejecuta este o no encendido el objeto
    void Awake()
    {
        anim = this.GetComponent<Animator>();
        spr = this.GetComponent<SpriteRenderer>();
        rb2D = this.GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Asi solo se mueve horizontal
        transform.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
           
        spr.flipX = Flip;
    }

    void FixedUpdate()
    {
        if(Grounding)
        {
            if(JumpButton)
            {
                //cuando se deja en modo de forceMode.force tarda mas en tomar la velocidad del salto y se ocupan numeros mas grandes que como impulso
                rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetTrigger("jump");
            }
        }
    }
    void LateUpdate()
    {
        anim.SetFloat("moveX", Mathf.Abs(Axis.x));
        anim.SetBool("grounding",Grounding);
    }
    Vector2 Axis
    {
        get => new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")); 
     
    }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

   bool Flip
    {
       get => Axis.x > 0f ? false : Axis.x < 0f ? true : spr.flipX;
    }

    bool JumpButton 
    {
        get => Input.GetButtonDown("Jump");
    }

    //esto es para que funcione este rayo fisicamente
    bool Grounding 
    {
        //los parametros son: de donde vengo, a donde voy, que distancia recorre y que layer busca
        get => Physics2D.Raycast(transform.position,Vector2.down,rayDistance,groundLayer);
    }

    //Esto es para poder que se dibuje el rayo y verlo y tenerlo en la interfaz
    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
