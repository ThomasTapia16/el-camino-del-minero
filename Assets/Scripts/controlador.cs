using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlador : MonoBehaviour
{
    int vidas;
    Text nvidas;
    Transform personaje;
    void Start()
    {
        nvidas = GameObject.Find("Text").GetComponent<Text>();
        personaje = GameObject.Find("Principal").GetComponent<Transform>();
        personaje.transform.position = new Vector3(-6, 1, 0);
        this.vidas = 3;
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.name == "plataformaPerder")
        {
            restarVidas(true);
        }
    }
    private void restarVidas(bool c)
    {   
        
        if(c)
        {
            this.vidas--;
            if (this.vidas == -1)
            {
                Debug.Log("perdiste");
            }
            else
            {
                
                restarVidasG();
                retorarInicio();
            }
        }
        
        Debug.Log(vidas);
    }
    private void restarVidasG()
    {
        if(this.vidas == 2)
        {
            nvidas.text = "x2";

        }
        if (this.vidas == 1)
        {
            nvidas.text = "x1";
        }
        if (this.vidas == 0)
        {
            nvidas.text = "x0";
        }
    }
    private void retorarInicio()
    {
        personaje.transform.position = new Vector3(-6, 1, 0);
    }
}
