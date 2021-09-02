using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float velocidad = 5f;
    public Rigidbody2D rb;

    Vector2 movimiento;
    Vector2 mousePos;
   
    void Update()// en el update ponemos el input para tomar las teclas y en el fixed ejecutariamos el movimiento , asi evitamos problemas
    {

        // Con esto estamos guardando la tecla horizontal(a,d) y vertical (w,s) que esta presionando el jugador en un vector de 2
        MovInput();

    }

    private void FixedUpdate()
    {      
        rb.velocity = movimiento * velocidad;

    }
    void MovInput ()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movimiento = new Vector2(x, y).normalized;
            }
}
