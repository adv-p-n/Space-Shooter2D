using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 0.1f;
    [SerializeField] float paddingLeft = 0f;
    [SerializeField] float paddingRight = 0f;
    [SerializeField] float paddingTop = 0f;
    [SerializeField] float paddingBottom = 0f;
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    Shooter shooter;

    void Awake() 
    {
        shooter=GetComponent<Shooter>();      
    }

    void Start()
    {
        InitBounds();
    }

    void InitBounds()
    {
        minBounds = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));
        maxBounds = Camera.main.ViewportToWorldPoint(new Vector2 (1,1));
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 delta = rawInput* Time.deltaTime * playerSpeed;
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + delta.x,minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y,minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPosition ;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        
    }

    void OnFire(InputValue value)
    {
        if(shooter != null) {shooter.isFiring = value.isPressed;}
    }
}
