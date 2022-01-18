using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    bool esIzq = false;
    bool esDer = false;
    public Rigidbody2D personaje;
    public float fuerza;

    void Start()
    {
        this.fuerza = 500;
    }

    public void izq()
    {
        esIzq = true;
    }
    public void noIzq()
    {
        esIzq = false;
    }
    public void der()
    {
        esDer = true;
    }
    public void noDer()
    {
        esDer = false;
    }

    private void FixedUpdate()
    {
        if (esIzq)
        {
            Debug.Log("izq");
            personaje.AddForce(new Vector2(-fuerza, 0) * Time.deltaTime);
        }
        if (esDer)
        {
            Debug.Log("der");
            personaje.AddForce(new Vector2(fuerza, 0) * Time.deltaTime);
        }
    }
}
