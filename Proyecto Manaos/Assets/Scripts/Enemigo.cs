using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{   
    public float Velocidad = 3f;
    [SerializeField] Transform Player;   
    Rigidbody2D rb;
    Vector3 direccion;
    void Start()
    {
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
    }

    void Move()
    {
        rb.MovePosition(transform.position + (direccion.normalized * Velocidad * Time.deltaTime));
    }
}
  


