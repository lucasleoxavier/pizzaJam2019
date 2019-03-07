using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform2DController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _jumpForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.Movement();
        this.Jump();
    }

    void Movement()
    {
        //movimenta para a esquerda e direita
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.left * _speed * Time.deltaTime * horizontal);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
