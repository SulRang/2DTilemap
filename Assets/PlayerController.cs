using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    Animator animator;
    float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("dirX", x);
        animator.SetFloat("dirY", y);
        rigidbody2D.velocity = new Vector2(x, y) * moveSpeed;
        animator.SetBool("isMove",rigidbody2D.velocity.magnitude > 0);
    }
}
