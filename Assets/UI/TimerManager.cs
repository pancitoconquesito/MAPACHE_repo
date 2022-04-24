using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private float tiempoTotal;
    [SerializeField] private TextMeshProUGUI tiempotext;
    [SerializeField] private Image imageFill;

    [SerializeField] private GameObject timeOut_OBJ;
    [SerializeField] private movement movePJ;
    [SerializeField] private Animator animator_PJ;
    [SerializeField] private Animator animator_UI_estatico;
    [SerializeField] private ui_manzanas m_ui_manzanas;
    [SerializeField] private ui_puntaje m_ui_puntaje;
    [SerializeField] private GameObject contenedorUI_Pregunta;


    [Header("-- COLOR --")]
    [SerializeField] private Image ciruclo;
    [SerializeField] private Color verde;
    [SerializeField] private Color rojo;


    [Header("-- texto --")]
    [SerializeField] private float tamanioInicial;
    [SerializeField] private float tamanioExtra;
    [SerializeField] private TextMeshProUGUI conteoTEXT;
    [SerializeField] private GameObject RUEDA;
    [SerializeField] private float factorAumentoRueda;
    private void timeOut()
    {
        
        //esperar
        timeOut_OBJ.SetActive(false);
        animator_PJ.SetTrigger("loose");
        m_ui_puntaje.addPuntaje(-50);//promover a variable
        m_ui_manzanas.addManzana();
        Invoke("reactivarPJ", 1);//promover a variable
    }
    private void reactivarPJ()
    {
        //sumar pregunta

        movePJ.setMove(true);
        animator_PJ.SetTrigger("normalAnim");
    }

    private float currentTime;

    private float porcentaje;

    private bool run = false;


    private bool complete = true;

    public void setComplete(bool value)
    {
        complete = value;
    }
    void Update()
    {
        if (!complete)
        {

            if (run && currentTime > 0.1)
            {
                currentTime -= Time.deltaTime;
                tiempotext.text = "" + (float)(Math.Round(((double)currentTime), 1));
                //tiempotext.text = ""+ currentTime.TryFormat.;

                porcentaje = currentTime / tiempoTotal;


            }
            else
            {
                complete = true;
                run = false;
                porcentaje = 0;
                tiempotext.text = "0.000";
                timeOut_OBJ.SetActive(true);
                contenedorUI_Pregunta.SetActive(false);
                animator_UI_estatico.SetTrigger("enter");
                //invoke
                Invoke("timeOut", 1);//promover a variable
            }
            imageFill.fillAmount = porcentaje;
            ciruclo.color = verde * porcentaje + rojo * (1 - porcentaje);
            conteoTEXT.fontSize = tamanioInicial + tamanioExtra * (1 - porcentaje);
            RUEDA.transform.localScale= Vector3.one * ((1 - porcentaje)*(factorAumentoRueda-1) +1 );
        }
        
    }

    public void comenzarConteo()
    {
        complete = false;
        currentTime = tiempoTotal;
        imageFill.fillAmount = 1;
        run = true;
    }

}
