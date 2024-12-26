using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgController : MonoBehaviour
{
    public float bg_speed = -0.013f;
    public float bg_end_position_x = -9.5f;
    public bool isMove = true;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMove) return;
        if(transform.position.x < bg_end_position_x)
        {
            transform.position =  startPos;
        }
        transform.Translate(bg_speed, 0, 0);
    }

    public void StopMove()
    {
        isMove = false;
    }
}
