using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveX;
    public float moveY;

    public float speed;
    public Rigidbody2D player;

    public Vector2 movement;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetAxys();

        CreateMovement();

        MovePlayer();
    }

    private void GetAxys()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    private void CreateMovement()
    {
        movement = new Vector2(moveX, moveY).normalized * speed;
    }

    private void MovePlayer()
    {
        player.velocity = movement;
    }
}
