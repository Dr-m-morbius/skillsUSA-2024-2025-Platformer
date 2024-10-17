using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playercomtroler : MonoBehaviour
{
     public float MoveSpeed = 8f;
    public float JumpForce = 15f;

    private Rigidbody2D _playerRb;
    private CapsuleCollider2D _capsulecollider2d;
    // Start is called before the first frame update
    void Start()
    {
        _capsulecollider2d = GetComponent<CapsuleCollider2D>();
        _playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void movement()
    {
         float _horizontalInput = Input.GetAxis("Horizontal");
        _playerRb.velocity = new Vector2(_horizontalInput * MoveSpeed, _playerRb.velocity.y);
    }
}
