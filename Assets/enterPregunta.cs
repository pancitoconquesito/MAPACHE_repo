using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterPregunta : MonoBehaviour
{
    
    [SerializeField] private GLOBAL_TYPES.TIPO_PREGUNTA tipoPregunta;
    [SerializeField] private movement movPJ;
    [SerializeField] private ComprobarPregunta_A botonComprobar;


    [Header("-- TIPO _ A --")]
    [SerializeField] private GameObject UI_pregunta_GO_Tipo_A;
    [SerializeField] private setUI_tipoA setTipoA;
    [SerializeField] private GameObject subPanel_if_A;


    [SerializeField]private Animator animator_UI_estatico;

    [SerializeField] private bool modoFacil;
    [SerializeField] private Animator at_Pregunta;


    [Header("-- if B --")]
    [SerializeField] private GameObject subPanel_if_B;
    private void OnTriggerEnter2D(Collider2D collision)//pregunta colisiona con pj
    {
        movPJ.setMove(false);

        modoFacil = false;
        if (DATA.instance.sePuedeGetFacil())
        {
            float nRandom = Random.Range(0f,1f);
            if(nRandom < 0.5f)
            {
                DATA.instance.addCountFacil();
                modoFacil = true;
            }
            //print("nRandom : " + nRandom);
        }

        botonComprobar.setTipoPregunta(tipoPregunta);

        //lanzar ui pregunta con data pregunta
        switch (tipoPregunta)
        {
            case GLOBAL_TYPES.TIPO_PREGUNTA.tipoaA:
                {
                    startTipo_A();
                    break;
                }
            case GLOBAL_TYPES.TIPO_PREGUNTA.tipoB:
                {
                    startTipo_B();
                    break;
                }
        }
        Destroy(gameObject);
    }
    private void startTipo_A()
    {
        //
        animator_UI_estatico.SetTrigger("exit");

        subPanel_if_A.SetActive(true);
        subPanel_if_B.SetActive(false);
        UI_pregunta_GO_Tipo_A.SetActive(true);

        at_Pregunta.SetTrigger("enter");
        setTipoA.setInfoPregunta(DATA.instance.getTipoA(), modoFacil);
    }
    private void startTipo_B()
    {
        animator_UI_estatico.SetTrigger("exit");
        subPanel_if_A.SetActive(false);
        subPanel_if_B.SetActive(true);
        UI_pregunta_GO_Tipo_A.SetActive(true);

        at_Pregunta.SetTrigger("enter");
        setTipoA.setInfoPregunta(DATA.instance.getTipoB(), modoFacil);
    }
}
