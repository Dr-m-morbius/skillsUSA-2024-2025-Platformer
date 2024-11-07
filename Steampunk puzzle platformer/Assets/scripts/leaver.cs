using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class leaver : MonoBehaviour
{
    
    public LayerMask WhatIsplayer;
    Animator animator;
    
    public GameObject door;
    
    private door _doorscript;
    public bool forward = false;
    public bool back = false;
 
    private BoxCollider2D _boxcollider;
    [SerializeField] private bool IsTouchingPlayer;
    // Start is called before the first frame update
    void Start()
    {
      _boxcollider = GetComponent<BoxCollider2D>();
       _doorscript = door.GetComponent<door>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      if(forward)
      {
        _doorscript.movedoor();
      }
      else if (back)
      {
        _doorscript.movedorrback();
      }
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
          _doorscript.movedoor();
        }
      if(Input.GetKeyUp(KeyCode.R)&& IsTouchingPlayer)
      {
        //door.transform.position = originaldoorposition.transform.position;
        forward = false;
        back = true;
        _doorscript.movedorrback();
      }
}
}
