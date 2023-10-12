using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void OnTriggerEnter(Collider other)
    {
        
        animator.SetTrigger("open");
    }
}
