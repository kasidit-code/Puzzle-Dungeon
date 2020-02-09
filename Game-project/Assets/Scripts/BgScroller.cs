using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour
{
    public float speed;
    private Vector3 startPOS;
    // Start is called before the first frame update
    void Start()
    {
        startPOS = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((new Vector3(-1, 0, 0)) * speed * Time.deltaTime); // to move background

        if (transform.position.x < -19.63) // to reset bg position
        {
            transform.position = startPOS;
        }
    }
}
