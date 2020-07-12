using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    public Transform target;
    public float speed = 5.0f;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        if (dist < 3)
        {
            anim.Play("idle 0");
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            anim.Play("walk 0");
        }

    }
}
