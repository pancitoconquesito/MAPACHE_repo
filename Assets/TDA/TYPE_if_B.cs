using UnityEngine;
[CreateAssetMenu(fileName = "new IF_B", menuName = "TDA/IF_B")]
public class TYPE_if_B : ScriptableObject
{
    public int _ID;

    public Sprite img;
    public string nombre;
    public string especie;
    public string sexo;
    public int edad;

    [TextArea(minLines: 2, maxLines: 10)] public string info;

    [TextArea(minLines: 2, maxLines: 4)] public string[] opciones_string;

    [TextArea(minLines: 2, maxLines: 4)] public string[] opciones_string_FACILES;
}
