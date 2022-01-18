using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Linea : MonoBehaviour
{
    public GameObject lineaPre;
    public GameObject lineaActual;
    public LineRenderer lineR;
    public EdgeCollider2D collider;
    public List<Vector2> mousePos;
   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            crearLinea();
        }
        if(Input.GetMouseButton(0))
        {
            Vector2 tempPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(Vector2.Distance(tempPos, mousePos[mousePos.Count - 1]) > .05f)
            {
                UpdateLine(tempPos);
            }
        }   
    }

    void crearLinea()
    {
        lineaActual = Instantiate (lineaPre, Vector3.zero, Quaternion.identity);
        lineR = lineaActual.GetComponent<LineRenderer>();
        collider = lineaActual.GetComponent<EdgeCollider2D>();
        mousePos.Clear();
        mousePos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        mousePos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineR.SetPosition(0, mousePos[0]);
        lineR.SetPosition(0, mousePos[1]);
        collider.points = mousePos.ToArray();

    }
    void UpdateLine(Vector2 newMousePos)
    {
        mousePos.Add(newMousePos);
        lineR.positionCount++;
        lineR.SetPosition(lineR.positionCount - 1, newMousePos);
        Debug.Log(collider.transform.position);
        collider.points = mousePos.ToArray();
    }
}