using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool thrown = false;
    public bool hasspear = true;

    
    public  float moveSpeed = 30f;
    public Transform player;
    private BoxCollider2D boxCollider2D;
    void Start()
    {
        
        boxCollider2D = GetComponent<BoxCollider2D>();
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
        //ransform.position = player.transform.position;
        }
        else
        {
           transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }
     private void OnCollisionEnter2D(Collision2D other)
     {
        if (other.gameObject.CompareTag("wall"))
        {
            Debug.Log("hit wall");
        }
     }
}
