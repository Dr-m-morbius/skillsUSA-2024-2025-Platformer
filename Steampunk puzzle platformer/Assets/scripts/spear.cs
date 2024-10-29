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
    public bool facingright;
    public bool facingleft;
    void Start()
    {
         transform.position = playertransform.transform.position;
        
        playertransform = GameObject.Find("Player");
        hasspear = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            facingright = true;
            facingleft = false;
        }
         if (Input.GetKeyDown(KeyCode.A))
        {
            facingright = false;
            facingleft = true;
        }
        boxCollider2D = GetComponent<BoxCollider2D>();
        playertransform = GameObject.Find("Player");
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("spear thrown");
            thrown = true;
            hasspear = false;
        }
        if (hasspear)
        {
        transform.position = playertransform.transform.position;
        }
        else if (facingright)
        {
           transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else if (facingleft)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        if (boxCollider2D.IsTouchingLayers(WhatIswall) && thrown)
        {
            Instantiate(platform, spearposition.position, spearposition.rotation);
            Debug.Log("hit wall");
            Destroy(this.gameObject);
        }
    }
}
