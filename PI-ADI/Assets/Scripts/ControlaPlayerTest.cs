using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class ControlaPlayerTest : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    [SerializeField] bool checkChao = false;
    [SerializeField] bool jump = false;

    //Vector3 velocity;

    //[SerializeField] float _gravidade = -9f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimentoPlayer();
       

    }

    public void SetPula(InputAction.CallbackContext value)
    {
        if (checkChao == true)
        {
            _rb.AddForce(0, _jumpForce * 500, 0);
            checkChao = false;
            Debug.Log("Tocou no Chão");
        }
    }


    void Gravidade()
    {
       // velocity.y += _gravidade * Time.deltaTime;
       // _rb.AddForce(velocity);
    }


    void MovimentoPlayer()
    {
        if(checkChao == true)
        {
            _rb.velocity = new Vector3(0, _rb.velocity.y, _speed);
        
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            checkChao = true;
            
        }
    }

}

