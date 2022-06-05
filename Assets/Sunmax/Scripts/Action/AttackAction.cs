using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : MonoBehaviour
{
    [SerializeField] private Transform Root;
    [SerializeField] private Animator animator;
    void Start()
    {
        if (Root == null) Root = this.transform;

        animator = Root.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) SetAnimatorTrigger("Punch1");

        if (Input.GetMouseButtonDown(1)) SetAnimatorTrigger("Punch2");
        if (Input.GetMouseButtonDown(2)) SetAnimatorTrigger("Kick1");
    }

    private void SetAnimatorTrigger(string anim)
    {
        animator.SetTrigger(anim);
    }
}
