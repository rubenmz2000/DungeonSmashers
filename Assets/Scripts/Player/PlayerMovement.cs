using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveX;
    public float moveY;

    public float speed;
    public Rigidbody2D player;

    public Vector2 movement;

    public List<GameObject> targets;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetAxys();

        CreateMovement();

        MovePlayer();

        Attack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        targets.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        targets.Remove(collision.gameObject);
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

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
            targets.Where(t => t.CompareTag("enemy")).ToList().ForEach(target => target.GetComponent<HealthController>().GetDamage(2));
    }
}
