using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBehaviorScript : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("ShootPos", true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
