using System;
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

    public string tag;
    public Dictionary<string, GameObject> collisions;

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
        tag = collision.tag;
        targets.Add(collision.gameObject);
        //collisions.Add(collision.gameObject.GetComponent<GameElement>().ObjectId, collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        targets.Remove(collision.gameObject);
        //collisions.Remove(collision.gameObject.GetComponent<GameElement>().ObjectId);
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
        if (Input.GetButtonDown("Fire1") && tag == "enemigo")
        {
            targets.ForEach(target =>
            {
                var enemy = target.GetComponent<HealthController>();
                enemy.GetDamage(2);
            });
        }
    }
}
