using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combateJugador : MonoBehaviour
{
    private bool atacando;
    public Animator anim;
    public Transform puntodeAtaque;
    public float rangodeAtaque;
    public LayerMask layerEnemigos;
    public int dañodeAtaque = 20;    
    

   

    // Start is called before the first frame update
    void Start()
    {
        
        
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool atacando = stateInfo.IsName("jugador-atacando");

        if (Input.GetMouseButtonDown(0) && !atacando) //si el se clickea y no esta atacando se ejecuta la animacion atacando
        {
            //Ejecuta la animacion atacar
            anim.SetTrigger("atacando");
            ataque();

        }
        

    }

    void ataque()
    {

        //Ejecuta la animacion atacar
        //anim.SetTrigger("atacando");
        

        //Verifica si el enemigo esta en rango de ataque

        Collider2D[] hitEnemigos = Physics2D.OverlapCircleAll(puntodeAtaque.position, rangodeAtaque, layerEnemigos);



        //Hace el daño a los enemigos que esta detectando y guarndo en la matriz de arriba

        foreach (Collider2D enemy in hitEnemigos)
        {
            enemy.GetComponent<CombateEnemigo>().RecibeDaño(dañodeAtaque);

           //Debug.Log("le pegaste capo" + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (puntodeAtaque == null)
            return;
        Gizmos.DrawWireSphere(puntodeAtaque.position, rangodeAtaque);
    }
}

