using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1Controller : MonoBehaviour
{

    private Animator _animator;

    private static readonly string ANIMATOR_STATE = "Estado";
    private static readonly int ANIMATOR_P_WALK = 1;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Quieto();
    }
    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }
    private void Quieto()
    {
        ChangeAnimation(ANIMATOR_P_WALK);

    }
}
