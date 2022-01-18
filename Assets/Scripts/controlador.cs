using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlador : MonoBehaviour
{
    int vidas;
    Text nvidas;
    Transform personaje;
    public GameObject n1,n2,n3,n4;
    int c = 1;
    public Rigidbody2D c1, c2;
    void Start()
    {

        nvidas = GameObject.Find("Text").GetComponent<Text>();
        personaje = GameObject.Find("Principal").GetComponent<Transform>();

        c1 = GameObject.Find("plataformaPerder1").GetComponent<Rigidbody2D>();
        c2 = GameObject.Find("plataformaPerder").GetComponent<Rigidbody2D>();
        personaje.transform.position = new Vector3(-10, -1, 0);
        this.vidas = 3;
        
        
    }
    private void cactus(Rigidbody2D c)
    {
        c.constraints = RigidbodyConstraints2D.None;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.name == "plataformaPerder" || other.collider.name == "plataformaPerder1")
        {
            restarVidas(true);
        }if(other.collider.name == "plataformaA")
        {
            
            cactus(c1);
        }
        if (other.collider.name == "plataformaB")
        {
            
            cactus(c2);
        }
        else if(other.collider.name == "tesoro")
        {
            c++;
            if (this.c == 2)
            {
                n1.SetActive(false);
                n2.SetActive(true);
            }if(this.c == 3)
            {
                n2.SetActive(false);
                n3.SetActive(true);
                retorarInicio();
            }if(this.c == 4)
            {
                n3.SetActive(false);
                n4.SetActive(true);
                personaje.transform.position = new Vector3(-10, 5, 0);

            }
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
        personaje.transform.position = new Vector3(-10, -1, 0);
    }
}
