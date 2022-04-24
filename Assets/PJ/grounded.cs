using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded : MonoBehaviour
{
    [Header("-- Grounded --")]
    [SerializeField] private BoxCollider2D capuslePJ;
    [SerializeField] private float largeRay;
    private float offset_X;
    private float offset_Y;

    //public float factorY;
    private void Start()
    {
        offset_X = (capuslePJ.bounds.size.x / 2) * 0.9f;
        offset_Y= (capuslePJ.bounds.size.y / 2) * 1.06f;
    }

    public bool isGrounded()
    {
        return
        lanzarRayo(0, offset_Y)
        && lanzarRayo(offset_X, offset_Y)
        && lanzarRayo(-offset_X, offset_Y);
    }
    private bool lanzarRayo(float offetX, float offsetY)
    {
        Vector2 newPosition = new Vector2(transform.position.x + offetX, transform.position.y - offsetY);
        RaycastHit2D hit = Physics2D.Raycast(newPosition, Vector2.down, largeRay);
        if (hit.collider != null )//&& hit.collider.CompareTag("suelo"))
        {
            Debug.DrawRay(newPosition, Vector2.down * largeRay, Color.yellow);
            return true;
        }
        else
        {
            Debug.DrawRay(newPosition, Vector2.down * largeRay, Color.red);
        }
        return false;
    }
}
