using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : MonoBehaviour
{
    // Indicamos [SerializeField] para poder verlo desde el inspector de Unity
    [SerializeField] private float velocidad = 7f;
    [SerializeField] private bool esPala1;

    // Límite de las palas
    private float limiteY = 3.75f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()   
    {
        float movimiento;

        if(esPala1)
        {
            // Devuelve 1 o -1 si se pulda las teclas arriba (up) o abajo (down)
            movimiento = Input.GetAxisRaw("Vertical");
        }
        else
        {
            // Devuelve 1 o -1 si se pulda las teclas arriba (W) o abajo (S)
            movimiento = Input.GetAxisRaw("Vertical2");
        }

        Vector2 posicionPala = transform.position;

        // Nos permite indicar los valores mínimo y máximo que pasamos como el primer parámetro
        posicionPala.y = Mathf.Clamp(posicionPala.y + movimiento * velocidad * Time.deltaTime, -limiteY, limiteY);

        // Aplicamos el cambio de la posicion
        transform.position = posicionPala;
    }
}
