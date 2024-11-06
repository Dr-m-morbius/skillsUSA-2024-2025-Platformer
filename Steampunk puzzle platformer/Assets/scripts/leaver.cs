using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class leaver : MonoBehaviour
{
    public GameObject door;
    public LayerMask WhatIsplayer;
    Animator animator;
    //public Transform[] positions;
    public float Speed = 1f;
    
    private door _door;
    public bool forward = false;
    public bool back = false;
 
    private BoxCollider2D _boxcollider;
    [SerializeField] private bool IsTouchingPlayer;
    // Start is called before the first frame update
    void Start()
    {
      _boxcollider = GetComponent<BoxCollider2D>();
       _door = GetComponent<door>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      playercheck();
      movedoor();
      animator.SetBool ("forward", forward);
      animator.SetBool ("back", back);
    }
    void playercheck()
    {
        //check if player is in range
      if (_boxcollider.IsTouchingLayers(WhatIsplayer))
      {
        IsTouchingPlayer = true;
      }
      else
      {
        IsTouchingPlayer = false;
      }
    }
    void movedoor()
    {
//move door forward and back
        if(Input.GetKeyUp(KeyCode.E) && IsTouchingPlayer)
        {
          //door.transform.position = doorsecondposition.transform.position; 
          back = false;
          forward = true;
          _door.movedoor();
        }
      if(Input.GetKeyUp(KeyCode.R)&& IsTouchingPlayer)
      {
        //door.transform.position = originaldoorposition.transform.position;
        forward = false;
        back = true;
        _door.movedorrback();
      }
}
}
