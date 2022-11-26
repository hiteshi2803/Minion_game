﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;
    public float speedIncrease = 0.1f;
    [SerializeField] float verticalForce = 400f;
    [SerializeField] LayerMask groundMask;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene("EndScreen");;
        }
    }
    // public void Die()
    // {
    //     alive = false;
    //     // Restart the game
    //     Invoke("Restart", 2);
    // }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //trigger text
    }

    void Jump()
    {
        //check whether we are grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        //If grounded, then you can jump
        rb.AddForce(Vector3.up * verticalForce);
    }
}