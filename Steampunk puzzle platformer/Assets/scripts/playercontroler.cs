using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playercontroler : MonoBehaviour
{
     public float MoveSpeed = 20f;
    public float JumpForce = 15f;
    public LayerMask WhatIsGround;
    [SerializeField] private bool _isOnGround;
    [SerializeField] private bool _canDoubleJump;

    private Rigidbody2D _playerRb;
    private CapsuleCollider2D _capsulecollider2d;
     private CapsuleCollider2D _playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        _capsulecollider2d = GetComponent<CapsuleCollider2D>();
        _playerRb = GetComponent<Rigidbody2D>();
                _playerCollider = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        Jump();
    }
    private void movement()
    {
         float _horizontalInput = Input.GetAxis("Horizontal");

       _playerRb.velocity = new Vector2(_horizontalInput * MoveSpeed, _playerRb.velocity.y);

    }

     void Jump()
    {
        if (_playerCollider.IsTouchingLayers(WhatIsGround)) //_playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))
        {
            _isOnGround = true;
            _canDoubleJump = true;
           
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
            }
              else
            {
                if (_canDoubleJump)
                {
                    _playerRb.velocity = new Vector2(_playerRb.velocity.x, JumpForce);
                    _canDoubleJump = false;
                }
}
    }}}
