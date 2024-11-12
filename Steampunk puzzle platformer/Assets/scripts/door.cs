using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEditor.Experimental;
using UnityEngine;

public class door : MonoBehaviour
{
       public Transform doorsecondposition;
       public float Speed = 6f;
       bool moving = false;
       public LayerMask whatisdoorstop;
       Animator m_Animator;
       Rigidbody2D rb;
       public float waitime;
       private BoxCollider2D boxCollider2D;
      
       public Transform originaldoorposition;
    // Start is called before the first frame update
    void Start()
    {
       m_Animator = GetComponent<Animator> ();
       rb = GetComponent<Rigidbody2D>();
       Vector2 Velocity = rb.velocity;
       boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider2D.IsTouchingLayers(whatisdoorstop))
        {
            moving = false;
        }
        m_Animator.SetBool ("moving", moving);
        
    }
    public void movedoor()
    {
        transform.position = Vector2.MoveTowards(transform.position, doorsecondposition.position, Speed * Time.deltaTime);
        moving = true;
    }
    public void movedorrback()
    {
        transform.position = Vector2.MoveTowards(transform.position, originaldoorposition.position, Speed * Time.deltaTime);
        moving = true;
    }
   
        
    
}
