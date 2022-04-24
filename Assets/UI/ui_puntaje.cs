using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_puntaje : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPuntaje;
    private int puntajeActual = 0;
    void Start()
    {
        textPuntaje.text = "Puntaje: "+puntajeActual;
    }

    public void addPuntaje(int valor)
    {
        puntajeActual += valor;
        textPuntaje.text = "Puntaje: " + puntajeActual;
    }
}
