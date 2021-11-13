using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float velocidad = 5f;
    public float dashNum = 5f;

    public Rigidbody2D rb;
    CircleCollider2D attackCollider;
    
    bool dashTrue = false;
    Vector3 movimiento;
    Vector2 mousePos;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;
    }
    void Update()// en el update ponemos el input para tomar las teclas y en el fixed ejecutariamos el movimiento , asi evitamos problemas
    {

        // Con esto estamos guardando la tecla horizontal(a,d) y vertical (w,s) que esta presionando el jugador en un vector de 2
        MovInput();


        if (Input.GetKeyDown(KeyCode.Space)) //comprueba si se apreto el espacio para poner en verdadero
        {
            dashTrue = true;
        }

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool atacando = stateInfo.IsName("jugador-atacando");

        if(Input.GetMouseButtonDown(0) && !atacando) //si el se clickea y no esta atacando se ejecuta la animacion atacando
        {
            anim.SetTrigger("atacando");
            
        }
        if (atacando) //esto es para que el collider de ataque aparezca solo a mitad de la animacion y despues se desactive
        {
            float playbackTime = stateInfo.normalizedTime;
            if (playbackTime > 0.33 && playbackTime < 0.66) attackCollider.enabled = true;
            else attackCollider.enabled = false;

        }
        if()
        {

        }

    }

    private void FixedUpdate()
    {

        rb.velocity = movimiento * velocidad;

        if (dashTrue) //comprueba si dashtrue es verdadero , si lo es teleporta al jugador a la direccion cierto numero de espacio y se pone en falso
        {

            rb.MovePosition(transform.position + movimiento * dashNum);
            dashTrue = false;
        }

        //comprueba si esta en movimiento para ver que animacion poner si caminando o parado
        if (movimiento != Vector3.zero) 
        {attackCollider.offset = new Vector2(movimiento.x / 2, movimiento.y / 2);
            anim.SetFloat("movX", movimiento.x);
            anim.SetFloat("movY", movimiento.y);

            anim.SetBool("caminando", true);
        }
        else
        {
            anim.SetBool("caminando", false);
        }
    }
    void MovInput()
    {   // basicamente el movimiento
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movimiento = new Vector3(x, y).normalized;

       
    }
}
