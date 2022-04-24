
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static GameObject objBeingDraged;

    private Vector3 startPosition;
    private Transform startParent;
    private CanvasGroup canvasGroup;
    private Transform itemDraggerParent;

    private void Start() 
    {
        canvasGroup = GetComponent<CanvasGroup>();
        itemDraggerParent = GameObject.FindGameObjectWithTag("DragParent").transform;
    }

    #region DragFunctions

    public void OnBeginDrag(PointerEventData eventData)
    {
        objBeingDraged = gameObject;

        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(itemDraggerParent);
        transform.localScale = new Vector3(1,1,1);//TODO
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        objBeingDraged = null;

        canvasGroup.blocksRaycasts = true;
        if (transform.parent == itemDraggerParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }

    #endregion


    public void volver()
    {
        objBeingDraged = null;

        //canvasGroup.blocksRaycasts = true;
        if (transform.parent.name != "Pool_a")
        {
            transform.position = startPosition;
            transform.localScale = new Vector3(1, 1, 1);//TODO
            transform.SetParent(startParent);
            transform.localScale = tamOriginal;
        }

        //print("volviendo item_padre: "+transform.parent.name);
    }
    private Vector3 tamOriginal;
    private void OnEnable()
    {
        transform.localScale = new Vector3(1, 1, 1);//TODO
        tamOriginal = transform.localScale;
    }
}
