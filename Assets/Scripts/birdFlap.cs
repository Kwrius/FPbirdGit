using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class birdFlap : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Animator animator;
    public GameManager gameManager;
    public Transform birdImg;
    private bool begin = false;
    public float rotationZScale = 5f;
    public float flapSpeed = 6f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() 
    {
        if (!gameManager.isGameStarted) return;
        else if(!rb2D.simulated) rb2D.simulated = true;
        if (Input.GetMouseButtonDown(0))
        {
            Flap();
        }

        birdImg.transform.DORotateQuaternion(Quaternion.Euler(0, 0, rb2D.velocity.y * rotationZScale), 0.05f);
        //birdImg.transform.rotation = Quaternion.Euler(0, 0, rb2D.velocity.y * rotationZScale);

        //if (!begin)
        //{
        //    begin = true;
        //    rb2D.velocity = new Vector2(0, 0);
        //}
    }

    public void Flap()
    {
        rb2D.velocity = new Vector2(0, flapSpeed);
    }

    public void ChangeState(bool isFly, bool isSim = false)
    {
        if (isFly)
        {
            animator.SetInteger("state", 1);
        }
        else
        {
            animator.SetInteger("state", 0);
        }
        rb2D.simulated = isSim;
    }
}
