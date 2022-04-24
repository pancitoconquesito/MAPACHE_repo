using UnityEngine;
public class setActive_array : MonoBehaviour
{
    [SerializeField] private GameObject[] list_obj;
    private void Awake()
    {
        foreach (GameObject item in list_obj)
        {
            item.SetActive(true);
        }
    }
}
