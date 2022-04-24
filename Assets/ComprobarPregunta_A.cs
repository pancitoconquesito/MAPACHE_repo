using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarPregunta_A : MonoBehaviour
{
    private GLOBAL_TYPES.TIPO_PREGUNTA tipoPregunta;
    [Header("-- IF_A --")]
    [SerializeField] private GameObject[] Slots;

    [SerializeField] private GameObject Contenedor_Tipo_A;

    [Header("-- Retorno --")]
    [SerializeField] private movement movPJ;
    [SerializeField] private Animator animPJ;
    [SerializeField] private GameObject GANO_OBJ;
    [SerializeField] private GameObject PERDIO_OBJ;
    [SerializeField] private float tiempoEsperaOK;
    [SerializeField] private float tiempoEsperaNO_OK;
    [SerializeField] private float tiempoAnimaPerdio;
    [SerializeField] private float tiempoAnimVictoria;


    [Header("-- UI --")]
    [SerializeField] private ui_manzanas m_ui_manzanas;
    [SerializeField] private ui_puntaje m_ui_puntaje;

    [SerializeField] private Animator animator_UI_estatico;
    //vincular los slot, ver si tienen hijos, ver si la primera es true y la segunda es false, retornar ok o equivocada, restar o sumar
    //logica del timer


    [Header("-- IF_B --")]
    [SerializeField] private GameObject[] Slots_B;


    [Header("-- pantalla final etapa --")]
    [SerializeField] private GameObject panelFinalStage;
    [SerializeField] private TimerManager timer;
    public void setTipoPregunta(GLOBAL_TYPES.TIPO_PREGUNTA value)
    {
        tipoPregunta = value;
    }
    public void BTN_preguntar()
    {
        timer.setComplete(true);

        bool acceso = true;
        int largoSlots = Slots.Length;


        if (tipoPregunta == GLOBAL_TYPES.TIPO_PREGUNTA.tipoaA)
        {

            for (int i = 0; i < largoSlots; i++){
                if (Slots[i].transform.childCount < 1)
                {
                    acceso = false;
                    break;
                }
            }
        }

        if (tipoPregunta == GLOBAL_TYPES.TIPO_PREGUNTA.tipoB)
        {
            largoSlots = Slots_B.Length;
            for (int i = 0; i < largoSlots; i++)
            {
                if (Slots_B[i].transform.childCount < 1)
                {
                    acceso = false;
                    break;
                }
            }
        }


        if (acceso){
            bool acierto = false;
            switch (tipoPregunta)
            {
                case GLOBAL_TYPES.TIPO_PREGUNTA.tipoaA:
                {
                    acierto = verificar_TipoA();
                    break;
                }
                case GLOBAL_TYPES.TIPO_PREGUNTA.tipoB:
                {
                    acierto = verificar_TipoB();
                    break;
                }

            }
            animator_UI_estatico.SetTrigger("enter");

            if (acierto)
            {
                reset_UI_pregunta();

                //print("acertaste");
                GANO_OBJ.SetActive(true);
                Contenedor_Tipo_A.SetActive(false);//promover a aniamcion
                //sumar puntaje
                Invoke("lanzarGano", tiempoEsperaOK);

                m_ui_puntaje.addPuntaje(100);//promover a variable
                if (m_ui_manzanas.addManzana())
                    Invoke("reactivarPJ", tiempoAnimVictoria+ tiempoEsperaOK);
                //StartCoroutine(function_OK());
            }
            else
            {
                reset_UI_pregunta();

                //print("fallaste");
                PERDIO_OBJ.SetActive(true);
                Contenedor_Tipo_A.SetActive(false);//promover a aniamcion
                //restar puntaje
                Invoke("lanzarPerdio", tiempoEsperaNO_OK);

                m_ui_puntaje.addPuntaje(-100);//promover a variable
                if (m_ui_manzanas.addManzana())
                    Invoke("reactivarPJ", tiempoAnimaPerdio + tiempoEsperaNO_OK);
                else
                    Invoke("mostrarFinEtapa", tiempoEsperaNO_OK*0.9f);
            }
        }
        else{
            print("No esta completo");
        }
    }
    
    private void mostrarFinEtapa()
    {
        panelFinalStage.SetActive(true);
    }
    private void lanzarGano()
    {
        GANO_OBJ.SetActive(false);
        animPJ.SetTrigger("win");
        //m_ui_puntaje.addPuntaje(100);//promover a variable
       // if(m_ui_manzanas.addManzana())
           // Invoke("reactivarPJ", tiempoAnimVictoria);
    }
    private void lanzarPerdio()
    {
        PERDIO_OBJ.SetActive(false);
        animPJ.SetTrigger("loose");
        //m_ui_puntaje.addPuntaje(-100);//promover a variable
        //if(m_ui_manzanas.addManzana())
         //   Invoke("reactivarPJ", tiempoAnimaPerdio);
    }
    private void reactivarPJ()
    {
        //sumar pregunta
        
        movPJ.setMove(true);
        animPJ.SetTrigger("normalAnim");
    }
    private bool verificar_TipoA()
    {
        if (Slots[0].transform.GetChild(0).GetComponent<indicadorTrueFalse>().getValor() == true
            &&
            Slots[1].transform.GetChild(0).GetComponent<indicadorTrueFalse>().getValor() == false)
        {
            return true;
        }
        else return false;
    }
    private bool verificar_TipoB()
    {
        if (Slots_B[0].transform.GetChild(0).GetComponent<indicadorTrueFalse>().getValor() == false
            &&
            Slots_B[1].transform.GetChild(0).GetComponent<indicadorTrueFalse>().getValor() == true
            &&
            Slots_B[2].transform.GetChild(0).GetComponent<indicadorTrueFalse>().getValor() == true
            &&
            Slots_B[3].transform.GetChild(0).GetComponent<indicadorTrueFalse>().getValor() == false

            )
        {
            return true;
        }
        else return false;
    }
    private void reset_UI_pregunta()
    {
        if (tipoPregunta == GLOBAL_TYPES.TIPO_PREGUNTA.tipoaA)
        {
            for (int i = 0; i < Slots.Length; i++){
                Slots[i].transform.GetChild(0).transform.GetComponent<DragHandler>().volver();
            }
        }
        if (tipoPregunta == GLOBAL_TYPES.TIPO_PREGUNTA.tipoB)
        {

            for (int i = 0; i < Slots_B.Length; i++)
            {
                Slots_B[i].transform.GetChild(0).transform.GetComponent<DragHandler>().volver();
            }
        }
    }
}
