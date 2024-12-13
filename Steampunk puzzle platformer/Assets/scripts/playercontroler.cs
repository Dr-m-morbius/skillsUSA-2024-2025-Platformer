using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playercontroler : MonoBehaviour
{
     public float MoveSpeed = 20f;
     
    public float JumpForce = 15f;
    public bool running;
    public bool landed;
    public float landtime;
    public bool jumping;
    public bool falling;
    public LayerMask WhatIsGround;
    public LayerMask WhatIsWall;
    Animator m_Animator;
    [SerializeField] private bool _isOnGround;
    
    [SerializeField] private bool _canDoubleJump;
    public bool walljump;
    public bool notwalljumped;

    private Rigidbody2D _playerRb;
    private CapsuleCollider2D _capsulecollider2d;
     private CapsuleCollider2D _playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        _capsulecollider2d = GetComponent<CapsuleCollider2D>();
        _playerRb = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator> ();
        Vector2 Velocity = _playerRb.velocity;
                _playerCollider = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
         m_Animator.SetBool ("is jumping", jumping);
         m_Animator.SetBool ("is running", running);
         m_Animator.SetBool ("is falling", falling);
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            
        }
        if (_playerRb.velocity.y < 0)
        {
            falling = true;
        }
        else 
        {
            falling = false;
        }
        
        
        movement();
        Jump();
       

       
        if (_playerRb.velocity.x > 0)
        {
            running =true;
        }
         if (_playerRb.velocity.x < 0)
        {
            running =true;
        }
         if (_playerRb.velocity.x == 0)
        {
            running =false;
        }
        
        
        
    }
    private void movement()
    {
         float _horizontalInput = Input.GetAxis("Horizontal");

       _playerRb.velocity = new Vector2(_horizontalInput * MoveSpeed, _playerRb.velocity.y);

    }


     void Jump()
    {
        if (_playerCollider.IsTouchingLayers(WhatIsWall))
        {
            walljump = true;
        }
        else
        {
            walljump = false;
        }
        if (_playerCollider.IsTouchingLayers(WhatIsGround)) //_playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))
        {
            _isOnGround = true;
            _canDoubleJump = true;
            jumping = false;
            notwalljumped = true;
           
        }
        else
        {
            _isOnGround = false;
            
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (_isOnGround)
            {
                _playerRb.velocity = new Vector2(_playerRb.velocity.x, JumpForce);
                jumping = true;
            }
              else
            {
                if (_canDoubleJump)
                {
                    _playerRb.velocity = new Vector2(_playerRb.velocity.x, JumpForce);
                    _canDoubleJump = false;
                }
                else
                {
                    if ((walljump)&& notwalljumped)
                    {
                        _playerRb.velocity = new Vector2(_playerRb.velocity.x, JumpForce);
                    walljump = false;
                    notwalljumped = false;
                    }
                }
}
    }}
}
