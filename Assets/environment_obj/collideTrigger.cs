﻿using UnityEngine;
using System.Collections;
    [RequireComponent(typeof(Collider))]
public class collideTrigger : MonoBehaviour {
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>();
	}

    // Update is called once per frame
    void Update () {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "sonic3")
        {
            animator.SetInteger("trigger", 1);
        }

    }
    void OnCollisionExit(Collision collision)
    {
        animator.SetInteger("trigger", 0);
    }
}
