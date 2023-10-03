using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Librería para los textos

public class ControladorJuego : MonoBehaviour
{
    // Textos de los marcadores
    [SerializeField] private TMP_Text marcadorPala1;
    [SerializeField] private TMP_Text marcadorPala2;

    // Componentes transform de las palas y la bola => para reiniciar posición
    [SerializeField] private Transform pala1Transform;
    [SerializeField] private Transform pala2Transform;
    [SerializeField] private Transform bolaTransform;

    // Variables que almacenen el valor de las puntuaciones
    private int golesPala1, golesPala2;

    // Patrón Singleton para tener un única instancia
    private static ControladorJuego instance;
    public static ControladorJuego Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ControladorJuego>();
            }
            return instance;
        }
    }

    // Actualizamos los marcadores
    public void GolPala1()
    {
        golesPala1++;
        marcadorPala1.text = golesPala1.ToString();
    }
    public void GolPala2()
    {
        golesPala2++;
        marcadorPala2.text = golesPala2.ToString();
    }

    // Cuando se anota un punto / gol reiniciamos posiciones de las palas y de la bola
    public void Reiniciar()
    {
        pala1Transform.position = new Vector2(pala1Transform.position.x, 0);
        pala2Transform.position = new Vector2(pala2Transform.position.x, 0);
        bolaTransform.position = new Vector2(0, 0);
    }
}
