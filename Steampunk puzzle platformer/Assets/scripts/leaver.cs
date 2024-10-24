using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class leaver : MonoBehaviour
{
    public GameObject door;
    
    public bool doormoved = false;
    public LayerMask WhatIsplayer;
    public bool doorinoriginalspot = true;
    public Transform originaldoorposition;
    public Transform doorsecondposition;
    private CircleCollider2D _circlecollider;
    [SerializeField] private bool IsTouchingPlayer;
    // Start is called before the first frame update
    void Start()
    {
      _circlecollider = GetComponent<CircleCollider2D>();
        door.transform.position = originaldoorposition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      playercheck();
      movedoor();
    }
    void playercheck()
    {
        //check if player is in range
      if (_circlecollider.IsTouchingLayers(WhatIsplayer))
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
          door.transform.position = doorsecondposition.transform.position; 
        }
      if(Input.GetKeyUp(KeyCode.R)&& IsTouchingPlayer)
      {
        door.transform.position = originaldoorposition.transform.position;
      }
    }
    
}
