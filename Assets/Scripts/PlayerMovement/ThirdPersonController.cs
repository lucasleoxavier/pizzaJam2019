using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _rotationSpeed = 7f;
    [SerializeField]
    private float _jumpForce = 5f;
    [SerializeField]
    private float _mouseSensibility = 3.5f;
    [SerializeField]
    private Camera _cam;
    private Vector3 _mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        this.Movement();
        this.Jump();
        this.ThirdPersonCamera();
    }

    void Movement()
    {
        //movimenta para a esquerda/direita e frente/tras
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime * horizontal);
        transform.Translate(Vector3.back * _speed * Time.deltaTime * vertical);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponentInChildren<Rigidbody>().AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        }
    }

    void ThirdPersonCamera()
    {

        float _x = Input.GetAxis("Mouse Y");
        float _y = Input.GetAxis("Mouse X");
        Debug.Log("X: " + _x + "///Y: " + _y);

        
        Vector3 pos = _cam.transform.localEulerAngles;
        float rotationY = pos.y + _y * _mouseSensibility;
        float rotationX = pos.x - _x * _mouseSensibility;
        pos = new Vector3(rotationX, rotationY, 0);
        Debug.Log("position: " + pos);        
        _cam.transform.localEulerAngles = pos;        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
