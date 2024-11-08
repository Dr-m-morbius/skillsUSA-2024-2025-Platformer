using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEngine;

public class door : MonoBehaviour
{
       public Transform doorsecondposition;
       public float Speed = 6f;
       bool moving = false;
       Animator m_Animator;
       Rigidbody2D rb;
       public float waitime;
      
       public Transform originaldoorposition;
    // Start is called before the first frame update
    void Start()
    {
       m_Animator = GetComponent<Animator> ();
       rb = GetComponent<Rigidbody2D>();
       Vector2 Velocity = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y >= .1)
        {
            moving = true;
        }
        else if (rb.velocity.x >= .1)
        {
            //moving = true;
        }
        else
        {
            //moving = false;
        }

        m_Animator.SetBool ("moving", moving);
        
    }
    public void movedoor()
    {
        transform.position = Vector2.MoveTowards(transform.position, doorsecondposition.position, Speed * Time.deltaTime);
    }
    public void movedorrback()
    {
        transform.position = Vector2.MoveTowards(transform.position, originaldoorposition.position, Speed * Time.deltaTime);
    }
    
}
