using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetBool("IsGround", player.GetComponent<BallController>().isGrounded);
        animator.SetBool("IsJumping", player.GetComponent<BallController>().isJumping);

    }
}
