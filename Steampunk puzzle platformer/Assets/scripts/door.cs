using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
       public Transform doorsecondposition;
       public float Speed = 6f;
       public float waitime;
      
       public Transform originaldoorposition;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
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
