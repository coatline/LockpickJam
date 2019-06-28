﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpHeight;
    Animator a;
    Rigidbody2D rb;
    bool won = false;
    bool canJump = true;
    float timer;

    void Awake()
    {
        a = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        a.enabled = false;
    }

    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(x, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            canJump = false;
            rb.AddForce(new Vector2(0, jumpHeight));
        }

        if (won)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 2.55f)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            a.enabled = true;
            a.Play("PlayerUnlock");
            won = true;
        }
        else if (collision.gameObject.CompareTag("Spikes"))
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
