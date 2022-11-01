using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : MonoBehaviour
{
    public float jumpForce;
    public float velocity;
    public float timeJump;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    float horizontal;
    float maxTimeJump;
    bool jump;
    int jumps = 0;
    bool jumpdown;
    bool grounded;
    bool inJump;

    void Start() {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        //captura si se presionan  botones de movimiento horizontal
        horizontal = Input.GetAxisRaw("Horizontal");

        //activa la animacion de correr
        Animator.SetBool("run",true);
        

        //Debug.DrawRay(transform.position, Vector3.down * 0.28f, Color.red); //Depura con raycast

        Animator.SetBool("jump",inJump);

        if(Input.GetKeyUp(KeyCode.Space)){
            jumps = 1;
        }
        
        //activa la capacidad de saltar
        if(Input.GetKey(KeyCode.Space))
        {
            jump = true;  
        } else {
            jump = false;
        }

        //Conprobacion de ejecucion de caida
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && grounded == false)
        {
            jumpdown = true;
        } else {
            jumpdown = false;
        } 

        //Reset de, tiempo de salto, cant de saltos, animacion de caida y en salto en caso de que este tocando tierra
        if(grounded == true){
            maxTimeJump = 0;
            jumps = 0;
            Animator.SetBool("fall",false);
            inJump = false; 
        } else {
            inJump = true;  
        }

        //si esta callendo activar animacion de caida
        if(Rigidbody2D.velocity.y < 0){
            Animator.SetBool("fall",true);
        }

        //comprueba si esta por debajo de los limites para volver al inicio
        if(transform.position.y<-2.0f){
            transform.position = new Vector2(0.0f,0.0f);
        }
        
    }

    private void FixedUpdate()
    {
        //Movimiento en vertical
        Rigidbody2D.velocity = new Vector2(horizontal * velocity, Rigidbody2D.velocity.y);
        
        //Comprobacion de tocar el piso
        if(Physics2D.Raycast(transform.position, Vector3.down, 0.28f))
        {
            grounded = true;
        } else {
            grounded = false;
        }

        //Conprobacion de salto
        if(jump == true && maxTimeJump < timeJump && jumps < 1){
            maxTimeJump += Time.deltaTime;
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x,jumpForce);
        }

        //si caida esta activa que ejersa fuerza hacia abajo
        if(jumpdown == true){
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x,-jumpForce); 
        }

    }
}
