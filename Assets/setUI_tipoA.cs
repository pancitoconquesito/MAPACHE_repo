using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class setUI_tipoA : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TX_name;
    [SerializeField] private TextMeshProUGUI TX_especie;
    [SerializeField] private TextMeshProUGUI TX_sexo;
    [SerializeField] private TextMeshProUGUI TX_edad;

    [SerializeField] private Image img;

    [SerializeField] private TextMeshProUGUI textINFO;

    [SerializeField] private TextMeshProUGUI[] opcionTX;

    private TYPE_if_A currentTipoA = null;
    private TYPE_if_B currentTipoB = null;
    [SerializeField]private indicadorTrueFalse[] OpcionesIF_script;
    [SerializeField] private TimerManager timer;

    [SerializeField] private GameObject[] opcionesIF_OBJ;


    [Header("-- IF_B --")]
    [SerializeField] private TextMeshProUGUI[] opcionTX_IF_B;
    [SerializeField] private indicadorTrueFalse[] OpcionesIF_script_IFB;
    //[SerializeField] private GameObject[] opcionesIF_OBJ_IFB;
    public void setInfoPregunta(TYPE_if_A preguntaTipoA, bool modoFacil)
    {
        //timer
        timer.comenzarConteo();
        timer.setComplete(false);

        currentTipoA = preguntaTipoA;

        TX_name.text = "Nombre: "+currentTipoA.nombre;
        TX_especie.text = "Especie: "+currentTipoA.especie;
        TX_sexo.text = "Sexo: "+ currentTipoA.sexo;
        TX_edad.text = "Edad: " + currentTipoA.edad;

        img.sprite = currentTipoA.img;

        textINFO.text = currentTipoA.info;


        if (modoFacil)
        {
            setRandomOption_easy();
        }
        else
        {
            setRandomOption_notEasy();
        }

    }
    public void setInfoPregunta(TYPE_if_B preguntaTipoB, bool modoFacil)
    {
        timer.comenzarConteo();
        timer.setComplete(false);

        currentTipoB = preguntaTipoB;

        TX_name.text = "Nombre: " + currentTipoB.nombre;
        TX_especie.text = "Especie: " + currentTipoB.especie;
        TX_sexo.text = "Sexo: " + currentTipoB.sexo;
        TX_edad.text = "Edad: " + currentTipoB.edad;

        img.sprite = currentTipoB.img;

        textINFO.text = currentTipoB.info;


        //ajustar opciones, randomizarlas todo segun easy mode, asignar valor true or false
        int[] indicesRandom = getIndiceRandom(4);
        if (modoFacil)
        {
            for (int i = 0; i < 4; i++)
            {
                opcionTX_IF_B[i].text = currentTipoB.opciones_string_FACILES[indicesRandom[i]];
                if (indicesRandom[i] < 2) OpcionesIF_script_IFB[i].setBool(true);
                else OpcionesIF_script_IFB[i].setBool(false);
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                opcionTX_IF_B[i].text = currentTipoB.opciones_string[indicesRandom[i]];
                if (indicesRandom[i] < 2) OpcionesIF_script_IFB[i].setBool(true);
                else OpcionesIF_script_IFB[i].setBool(false);
            }
        }
        //ajustar valores de comprobacion para el boton
    }
    private void setRandomOption_notEasy()
    {
        for (int i = 0; i < opcionesIF_OBJ.Length; i++)
        {
            opcionesIF_OBJ[i].SetActive(true);
        }

        int[] indicesRandom = getIndiceRandom(DATA.instance.getCantOPciones_TIPO_A());
        for (int i = 0; i < DATA.instance.getCantOPciones_TIPO_A(); i++)
        {
            opcionTX[i].text = currentTipoA.opciones_string[indicesRandom[i]];
        }

        int largoOpcionesIF = OpcionesIF_script.Length;
        for (int i = 0; i < largoOpcionesIF; i++)
        {
            if (indicesRandom[i] < 2)
                OpcionesIF_script[i].setBool(true);
            else
                OpcionesIF_script[i].setBool(false);
        }
    }

    private void setRandomOption_easy()
    {
        string[] condicionalesSeleccionados = new string[2];
        float nRandom_a = Random.Range(0f, 1f);
        if (nRandom_a < 0.5f)
        {
            condicionalesSeleccionados[0] = currentTipoA.opciones_string[0];
        }
        else condicionalesSeleccionados[0] = currentTipoA.opciones_string[1];
        float nRandom_b = Random.Range(0f, 1f);
        if (nRandom_b < 0.5f)
        {
            condicionalesSeleccionados[1] = currentTipoA.opciones_string[2];
        }
        else condicionalesSeleccionados[1] = currentTipoA.opciones_string[3];

        float nRandom_c = Random.Range(0f, 1f);
        if (nRandom_c < 0.5f)
        {
            opcionTX[0].text = condicionalesSeleccionados[0];
            OpcionesIF_script[0].setBool(true);
            opcionTX[1].text = condicionalesSeleccionados[1];
            OpcionesIF_script[1].setBool(false);
        }
        else
        {
            opcionTX[1].text = condicionalesSeleccionados[0];
            OpcionesIF_script[1].setBool(true);
            opcionTX[0].text = condicionalesSeleccionados[1];
            OpcionesIF_script[0].setBool(false);
        }

        opcionesIF_OBJ[2].SetActive(false);
        opcionesIF_OBJ[3].SetActive(false);
    }

    private int[] getIndiceRandom(int cant)
    {
        int[] listaRetorno = new int[cant];
        int[] listaPivote = new int[cant];
        for (int i = 0; i < cant; i++)
        {
            listaPivote[i] = i;
        }
        for (int i = 0; i < cant; i++)
        {
            while (true)
            {
                int indiceRandom = Random.Range(0,cant);
                if (listaPivote[indiceRandom] != -1)
                {
                    listaRetorno[i] = listaPivote[indiceRandom];
                    listaPivote[indiceRandom] = -1;
                    break;
               }
            }
        }
        return listaRetorno;
    }
}
