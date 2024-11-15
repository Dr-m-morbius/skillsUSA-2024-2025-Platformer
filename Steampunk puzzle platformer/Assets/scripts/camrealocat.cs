using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camrealocat : MonoBehaviour
{
    public Transform player;
   private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + _offset;

    }
}
