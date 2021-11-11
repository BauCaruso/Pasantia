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
        anim.SetBool("")
    }
}
