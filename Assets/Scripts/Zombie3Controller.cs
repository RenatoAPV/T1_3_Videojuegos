using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie3Controller : MonoBehaviour
{
    public float JumpForce = 5;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sr;

    private static readonly string ANIMATOR_STATE = "Estado";
    private static readonly int ANIMATOR_P_IDLE = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Saltar()
    {
        if (_sr.flipX == false)
        {
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            _rb.velocity = new Vector2(5 * -1, _rb.velocity.y);
            _sr.flipX = true;
        }
        else
        {
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            _rb.velocity = new Vector2(5 * 1, _rb.velocity.y);
            _sr.flipX = false;
        }
 
        
        
        ChangeAnimation(ANIMATOR_P_IDLE);

    }

    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Suelo")
        {
            Saltar();
        }

    }
}
