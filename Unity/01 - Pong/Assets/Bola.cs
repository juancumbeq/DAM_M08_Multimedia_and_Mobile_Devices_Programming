using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    // Establecemos la velocidad inicial y valor de multiplicación
    [SerializeField] private float velocidadInicial = 4f;
    [SerializeField] private float valorDeMultiplicacion = 1.1f;

    // Cogemos referencia a su Rigidbody
    private Rigidbody2D bolaRb;

    // Start is called before the first frame update
    void Start()
    {
        bolaRb = GetComponent<Rigidbody2D> ();
        Lanzar();
    }

    // Método que se encarga de lanzar la bola en el comienzo
    private void Lanzar()
    {
        float velocidadX = Random.Range(0, 2) == 0 ? 1 : -1; // Range nos da 0 o 1 y lo convertimos a 1 o -1
        float velocidadY = Random.Range(0, 2) == 0 ? 1 : -1;

        // Asignamos a la velocidad de la bola un Vector2 y la multiplicamos por esa velocidad inicial
        bolaRb.velocity = new Vector2(velocidadX, velocidadY) * velocidadInicial;
    }

    // Método para saber cuándo se produce una colisión
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si colisiona con un objeto con TAG "PalaTag" => aumentamos velocidad
        if(collision.gameObject.CompareTag("PalaTag"))
        {
            bolaRb.velocity *= valorDeMultiplicacion;
        }
    }

    // Detectamos si se alcanzó alguan de las 2 zonas de gol
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GolPala2Tag"))
        {
            ControladorJuego.Instance.GolPala1();
        }
        else
        {
            ControladorJuego.Instance.GolPala2();
        }
        // Reiniciamos los elementos del juego y lanzamos la bola
        ControladorJuego.Instance.Reiniciar();
        Lanzar();
    }
}
