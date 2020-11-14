using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public bool isGrounded;
    public float verticalF;
    public float horizontalF;

    private Rigidbody2D m_rigidBody2D;
    private SpriteRenderer m_spriteRenderer;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(m_rigidBody2D.velocity.x) >= 0.1f)
        {
            m_animator.SetInteger("AnimState", 1);
        }

        if (Mathf.Abs(m_rigidBody2D.velocity.y) >= 0.1f)
        {
            m_animator.SetInteger("AnimState", 2);

        }

        if (isGrounded && (m_rigidBody2D.velocity.x == 0))
        {
            m_animator.SetInteger("AnimState", 0);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        switch (context.control.name)
        {
            case "a":
            case "leftArrow":
                m_rigidBody2D.AddForce(Vector2.left * verticalF);
                m_spriteRenderer.flipX = true;
                break;

            case "d":
            case "rightArrow":
                m_rigidBody2D.AddForce(Vector2.right * verticalF);
                m_spriteRenderer.flipX = false;
                break;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        m_rigidBody2D.AddForce(Vector2.up * verticalF);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }
}
