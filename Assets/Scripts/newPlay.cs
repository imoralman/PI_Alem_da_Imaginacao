using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class newPlay : MonoBehaviour
{

    [SerializeField] Rigidbody _rig;
    [SerializeField] bool _ground;
    [SerializeField] float _forcePule;
    [SerializeField] float _speed;
    float _speedY;


    bool m_FacingRight;
    float _speedAnim;
    float _MoveH;


    //variavel jotapê

    bool _ativaTime = false;
    float _time = 0f;




    Animator _anim;
    int _runHash = Animator.StringToHash("correndo");
    int _jumpHash = Animator.StringToHash("Pulo");

  
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
        Move();
        Jump();
        Andando();
        //_anim.SetBool(_runHash, _MoveH != 0);
        //_anim.SetBool(_jumpHash, _ground);
        _anim.SetBool("groundCheck", _ground);
        _anim.SetFloat("VelocidadeY", _rig.velocity.y);
    }

    void Move() //Movimento do Persoangem 
    {
        _MoveH = Input.GetAxisRaw("Horizontal");
        _rig.velocity = new Vector2(_MoveH * _speed, _rig.velocity.y);
        _anim.SetFloat("correndo", _speedAnim);
        _speedAnim = Mathf.Abs(_MoveH);

        if (_MoveH > 0 && m_FacingRight)
        {
            Flip();
        }
        
        else if (_MoveH < 0 && !m_FacingRight)
        {
            Flip();
        } 
    }

    void Andando()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //_speed= 8f;
            _anim.SetLayerWeight(0, 0);
            _anim.SetLayerWeight(1, 1);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //_speed = 16f;
            _anim.SetLayerWeight(0, 0);
            _anim.SetLayerWeight(1, 0);
        }
    }

    void Jump() //Pulo do Personagem
    {
        if (Input.GetAxisRaw("Jump") > 0 && _ground == true)
        { 
           _rig.velocity = Vector3.up * _forcePule;
        }
    }

    
    void Dash() //Dash do Jogador
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _speed == 6f)
        {
            _speed = 25f;
            _ativaTime = true;
            //time = 0f;
        }

        if (_ativaTime == true && _paraShift == false)
        {
            _time += 1 * Time.deltaTime; //Contador de Tempo ao ativar o Dash

            if (_time >= .2f && _speed == 25f && _ground == true) 
            {
                _ativaTime = false;
                _speed = 6f;
                _time = 0f;
            }
            /*else if (_time >= .2f && _speed == 25f && _ground == false) //Dash CupHead e Hollow Knight
            {
                _ativaTime = false;
                _speed = 0f;
                _time = 0f;
                
            }*/

            if(_time >= .2f && _speed == 25f && _ground == false) //Dash Metroidvania 
            {
                _rig.velocity += Vector3.down * 3;
                _ativaTime = false;
                _speed = 6f;
                _time = 0f;
            }
        }
    }


    private void Flip() // Flip do Personagem (Direita e Esquerda)
    {
        m_FacingRight = !m_FacingRight;

        Vector2 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            _ground = true;
            _speed = 6f;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _ground = false;
        }
    }
}
