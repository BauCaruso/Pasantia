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
    {
        if (mov != Vector2.zero)
        {
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            anim.SetBool("caminando", true);
        }
        else
        {
            anim.SetBool("caminando", false);
        }

        if (enRango && !enRangoAtaque)
        {
            MoveCharacter(mov);
        }
        if (enRangoAtaque)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
}
