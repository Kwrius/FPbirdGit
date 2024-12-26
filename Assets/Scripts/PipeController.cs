using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public Transform Pipes;
    public GameObject pipePrefab;
    public GameManager gameManager;
    public float spawnTime = 1.6f;
    public bool PipeIsMove = true;
    private List<GameObject> pipes = new List<GameObject>();

    public void Start()
    {
        StartCoroutine(SpawnPipeIE());
    }

    public void StartMove()
    {
        PipeIsMove = true;
        foreach (GameObject item in pipes)
        {
            item.GetComponent<PipeAction>().canMove = true;
        }
    }

    public void StopMove()
    {
        PipeIsMove = false;
        foreach (GameObject item in pipes)
        {
            item.GetComponent<PipeAction>().canMove = false;
        }
    }

    public void SpawnPipe()
    {
        GameObject pipe = GameObject.Instantiate(pipePrefab, Pipes);
        pipe.GetComponent<PipeAction>().RandomHeight();

        pipes.Add(pipe);

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StopMove();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            StartMove();
        }
    }

    IEnumerator SpawnPipeIE()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            if (!gameManager.isGameStarted) continue;
            if (!PipeIsMove) continue;
            SpawnPipe();
        }
    }
}
