using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearpickup : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    public LayerMask WhatIsplayer;
    
    public GameObject spear;
    public Transform player;
    [SerializeField] private bool IsTouchingPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      boxCollider2D = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player").transform;
         playercheck();
         if (Input.GetKeyDown(KeyCode.F) && IsTouchingPlayer)
         {
        Instantiate(spear, player.position, player.rotation);
        Destroy(this.gameObject);
         }
    }

    void playercheck()
    {
        //check if player is in range
      if (boxCollider2D.IsTouchingLayers(WhatIsplayer))
      {
        IsTouchingPlayer = true;
      }
      else
      {
        IsTouchingPlayer = false;
      }
    }
}
