using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAction : MonoBehaviour
{
    [SerializeField] private Transform Root;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (Root == null) Root = this.transform;

        animator = Root.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) SetAnimatorTrigger("Idle");

        if (Input.GetKeyDown(KeyCode.Alpha1)) SetAnimatorTrigger("Sit");
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetAnimatorTrigger("Walk");
        if (Input.GetKeyDown(KeyCode.Alpha3)) SetAnimatorTrigger("Lie");
        if (Input.GetKeyDown(KeyCode.Alpha4)) SetAnimatorTrigger("Cat");
        if (Input.GetKeyDown(KeyCode.Alpha5)) SetAnimatorTrigger("Guu");
        if (Input.GetKeyDown(KeyCode.Alpha6)) SetAnimatorTrigger("Choki");
        if (Input.GetKeyDown(KeyCode.Alpha7)) SetAnimatorTrigger("Paa");

    }

    private void SetAnimatorTrigger(string anim)
    {
        animator.SetTrigger(anim);
    }
}
