using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool thrown = false;
    public bool hasspear = true;
    public Transform spearposition;
    public GameObject platform;
    public LayerMask WhatIswall;
    public  float moveSpeed = 30f; 
    public GameObject playertransform;
    private BoxCollider2D boxCollider2D;
    void Start()
    {
         transform.position = playertransform.transform.position;
        boxCollider2D = GetComponent<BoxCollider2D>();
        playertransform = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Debug.Log("spear thrown");
            thrown = true;
            hasspear = false;
        }
        if (hasspear)
        {
        transform.position = playertransform.transform.position;
        }
        else
        {
           transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        if (boxCollider2D.IsTouchingLayers(WhatIswall))
        {
            Instantiate(platform, spearposition.position, spearposition.rotation);
            Debug.Log("hit wall");
            Destroy(this.gameObject);
        }
    }
     private void OnCollisionEnter2D(Collision2D other)
     {
        
     }
}
