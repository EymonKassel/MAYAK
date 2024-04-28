using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMovement : MonoBehaviour {
    public float Speed;
    private float MoveInput;

    public float JumpForce;
    public float JumpTimeCounter;
    public float JumpTime;
    public bool IsJumping;

    private bool _isGrounded;
    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask WhatIsGround;

    private Rigidbody2D _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        MoveInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(MoveInput * Speed, _rb.velocity.y);
    }

    private void Update() {
        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, WhatIsGround);

        if ( _isGrounded == true && Input.GetKeyDown(KeyCode.Space) ) {
            IsJumping = true;
            JumpTimeCounter = JumpTime;
            _rb.velocity = Vector2.up * JumpForce;
        }

        if ( Input.GetKey(KeyCode.Space) && IsJumping == true ) {
            if ( JumpTimeCounter > 0 ) {
                _rb.velocity = Vector2.up * JumpForce;
                JumpTimeCounter -= Time.deltaTime;
            } else IsJumping = false;
        }

        if ( Input.GetKeyUp(KeyCode.Space) ) {
            IsJumping = false;
        }
    }
}
