using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBoyBehevior : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sprite;
    public float speed;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        animator.SetBool("isWalk", Mathf.Abs(move) > 0);
        //animator.SetFloat("isWalkf", Mathf.Abs(move));
        if (Mathf.Abs(move) > 0)
            sprite.flipX = !(move > 0);
        transform.Translate(move, 0f, 0f);
    }
}
