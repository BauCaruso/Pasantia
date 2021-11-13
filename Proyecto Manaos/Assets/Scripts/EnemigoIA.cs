using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    public float speed;
    public float checkRadio;
    public float attackRadio;

    public bool shouldRotate;

    public LayerMask Player;

    private Transform objetivo;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 mov;
    public Vector3 dir;

    private bool enRango;
    private bool enRangoAtaque;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        objetivo = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        anim.SetBool("Corriendo", enRango);
         //crea un circulo no visible donde sigue o ataca al jugador
        enRango = Physics2D.OverlapCircle(transform.position, checkRadio, Player);
        enRangoAtaque = Physics2D.OverlapCircle(transform.position, attackRadio, Player);

        dir = objetivo.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        mov = dir;
        if (shouldRotate)
        {
            anim.SetFloat("x", dir.x);
            anim.SetFloat("y", dir.y);
        }
    }
    private void FixedUpdate()
    { //comprueba si el movimiento no es 0 y pone la animacion correspondiente a la direccion
        if (mov != Vector2.zero)
        {
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            anim.SetBool("caminando", true);
        }
        else  //si es 0 , es porque no esta caminando y se tiene que ejecutar la animacion de parado
        {
            anim.SetBool("caminando", false);
        }
        // si el objetivo esta en rango y no en rango de ataque se acerca
        if (enRango && !enRangoAtaque) 
        {
            MoveCharacter(mov);
        }
        if (enRangoAtaque) //si esta en rango de ataque se para y deberia atacar
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir) 
    {
        // mueve el rigigbody del enemigo a la posicion
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
}
