using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeAction : MonoBehaviour
{
    public float pipeSpeed = 0.1f;
    public bool canMove = true;

    public void FixedUpdate()
    {
        if (!canMove) return;
        transform.Translate(-pipeSpeed, 0, 0);
    }

    public void RandomHeight()
    {
        float r = Random.Range(-1.58f, 2.07f);
        transform.SetPositionAndRotation(new Vector3(transform.position.x, r, transform.position.z), transform.rotation);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
    }

    //public void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.J))
    //    {
    //        RandomHeight();
    //    }
    //}
}
