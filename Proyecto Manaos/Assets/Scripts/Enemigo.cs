using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Animator anim;
    public float Velocidad = 3f;
    [SerializeField] Transform Player;   
    Rigidbody2D rb;
    Vector3 direccion;
    void Start()
    {
        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direccion = Player.position - transform.position;
        float angle = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        
    }

    private void FixedUpdate()
    {
        Move();
        anim.SetFloat("movX", direccion.x);
        anim.SetFloat("movY", direccion.y);
    }

    void Move()
    {
        rb.MovePosition(transform.position + (direccion.normalized * Velocidad * Time.deltaTime));
    }
}
  


