using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateEnemigo : MonoBehaviour
{
    public int vidaMax = 100;
    int vidaActual;

    private void Start()
    {
        vidaActual = vidaMax;
    }
    public void RecibeDaño(int daño)
    {
        vidaActual -= daño;

        if (vidaActual <= 0)
        {
            Muere();
        }

    }

    void Muere()
    {
        Debug.Log("Enemigo muerto");
    }
}
