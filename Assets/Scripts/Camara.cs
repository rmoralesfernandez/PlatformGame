using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform personaje;
    public float suavizado = 5f;
    public Vector3 desfase;
    // Start is called before the first frame update
    void Start()
    {
        desfase = transform.position - personaje.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 posicionPersonaje = personaje.position + desfase;
        transform.position = Vector3.Lerp(transform.position, posicionPersonaje, suavizado * Time.deltaTime);
    }
}
