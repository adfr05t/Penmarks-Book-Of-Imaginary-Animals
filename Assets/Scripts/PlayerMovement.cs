using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Animator anim;
  //  private SpriteRenderer rend;

    void Start()
    {
        anim = GetComponent<Animator>();
       // rend = GetComponent<SpriteRenderer>();

    }


    void Update()
    {
        float yInput = Input.GetAxisRaw("Vertical");
        float xInput = Input.GetAxisRaw("Horizontal");

        yInput = yInput * speed * Time.deltaTime;
        xInput = xInput * speed * Time.deltaTime;

        transform.Translate(xInput, yInput, transform.position.z);

        transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);

        if (xInput == 0 && yInput == 0)
        {
            anim.SetBool("isWalking", false);

        }
        else
        {
            anim.SetBool("isWalking", true);
        }

        if (xInput > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (xInput < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
    }
}
