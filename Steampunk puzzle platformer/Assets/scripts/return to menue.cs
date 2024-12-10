using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class returntomenue : MonoBehaviour
{
     public LayerMask WhatIsplayer;
     private BoxCollider2D _boxcollider;
    // Start is called before the first frame update
    void Start()
    {
        _boxcollider = GetComponent<BoxCollider2D>();
    }
    public int menue;

    // Update is called once per frame
    void Update()
    {
        if (_boxcollider.IsTouchingLayers(WhatIsplayer))
        {
            SceneManager.LoadScene(menue);
        }
    }
}
