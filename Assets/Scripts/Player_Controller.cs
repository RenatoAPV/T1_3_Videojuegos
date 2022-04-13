using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float JumpForce = 10;
    public float Velocity = 10;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sr;

    private bool vivo = true;

    private static readonly string ANIMATOR_STATE = "Estado";
    private static readonly int ANIMATOR_P_RUN = 1;
    private static readonly int ANIMATOR_P_JUMP = 2;
    private static readonly int ANIMATOR_P_DEAD = 3;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vivo == true)
        {
            Caminar();
        }
        if (vivo == false)
        {
            Muerte();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Saltar();
        }
    }
    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }

    private void Caminar()
    {
        _rb.velocity = new Vector2(Velocity, _rb.velocity.y);
        ChangeAnimation(ANIMATOR_P_RUN);
    }
    private void Saltar()
    {
        _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        ChangeAnimation(ANIMATOR_P_JUMP);
    }
    private void Muerte()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        ChangeAnimation(ANIMATOR_P_DEAD);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Enemy")
        {
            vivo = false;
        }

    }
}
