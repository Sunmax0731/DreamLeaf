using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] private Transform Root;
    [SerializeField] private Animator animator;

    void Start()
    {
        if (Root == null) Root = this.transform;
        animator = Root.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Jump
            SetAnimatorTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Down
            SetAnimatorTrigger("Down");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Damage
            SetAnimatorTrigger("Damage");
        }
    }
    private void SetAnimatorTrigger(string anim)
    {
        animator.SetTrigger(anim);
    }
}
