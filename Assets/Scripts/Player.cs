using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _Speed;
    [SerializeField] float _JumpForce;

    [SerializeField] bool _isJumping;
    [SerializeField] bool _dubleJump;

    private Rigidbody2D _rig;
    private Animator _anim;


    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * _Speed;

        if(Input.GetAxis("Horizontal") > 0f)
        {
            _anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            _anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            _anim.SetBool("walk", false);
        }


    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") /*&& _isJumping == false*/)
        {
            if (!_isJumping)
            {
              _rig.AddForce(new Vector2(0f, _JumpForce), ForceMode2D.Impulse);
              _dubleJump = true;
              _anim.SetBool("jump", true);
            }
            else
            {
                if (_dubleJump)
                {
                  _rig.AddForce(new Vector2(0f, _JumpForce), ForceMode2D.Impulse);
                  _dubleJump = false;
                }
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            _isJumping = false;
            _anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            _isJumping = true;
        }
    }
}
