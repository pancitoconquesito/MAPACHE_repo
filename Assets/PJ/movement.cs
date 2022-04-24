using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    [SerializeField] private float gravedad = -9.8f;
    [SerializeField] private float potenciaSalto = 9f;
    [SerializeField] private float caida = 10f;
    private bool vivo = true, move = false;
    [SerializeField] private float delayCanMove;
    [SerializeField]private Rigidbody2D m_rigidbody;
    private Vector3 movimientoFinal;

    [SerializeField] private float velocidadCaminar;
    [SerializeField] private float velMaxCaida;

    [SerializeField] private Animator m_animator;
    [SerializeField] private SpriteRenderer m_spriteRendererPJ;

    void Start()
    {
        movimientoFinal.y = gravedad*2f;
        m_spriteRendererPJ.flipX = true;
        Invoke("startMove", delayCanMove);
    }
    private void startMove()
    {
        move = true;
    }
    private bool isSuelo = false;
    void Update()
    {
        if (move)
        {
            isSuelo = isGrounded();
            m_animator.SetBool("ground",isSuelo);
            if (vivo)
            {
                //if()
                movimientoFinal.x = Input.GetAxisRaw("Horizontal") * velocidadCaminar;
                if (movimientoFinal.x > 0) m_spriteRendererPJ.flipX=true;
                if (movimientoFinal.x < 0) m_spriteRendererPJ.flipX = false;
                m_animator.SetFloat("speed_X", Mathf.Abs(movimientoFinal.x));
                if (isSuelo)
                {
                    //print("a");
                    //movimientoFinal.y = gravedad;

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                       // print("b");
                        movimientoFinal.y = potenciaSalto;
                    }
                }

            }
            movimientoFinal.y -= Mathf.Sqrt(caida * -gravedad * 2) * Time.deltaTime;
            if (movimientoFinal.y < velMaxCaida) movimientoFinal.y = velMaxCaida;
            if (!isSuelo) movimientoFinal.x /= 2;
            m_rigidbody.velocity = movimientoFinal;
        }
    }
    [SerializeField] private float direfenciaYRAY;
    [SerializeField] private float laserLength;
    [SerializeField] private grounded m_grounded;
    private bool isGrounded()
    {
        return m_grounded.isGrounded();
        /*
        Vector2 posicionInicial = new Vector2(transform.position.x,transform.position.y + direfenciaYRAY);
        RaycastHit2D hit = Physics2D.Raycast(posicionInicial, Vector2.down, laserLength);
        if (hit.collider != null && hit.collider.CompareTag("suelo"))
        {
            Debug.DrawRay(posicionInicial, Vector2.down * laserLength, Color.yellow);
            return true;
        }
        else
        {
            Debug.DrawRay(posicionInicial, Vector2.down * laserLength, Color.red);
        }
        return false;
        */
    }

    
    public void setMove(bool valor)
    {
        move = valor;
        if (!valor) m_rigidbody.velocity = Vector2.zero;
    }
}
