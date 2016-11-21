using UnityEngine;
using System.Collections;

public class ModelControl : MonoBehaviour {

    private void init()
    {
        movingFlag = new bool[6];
        for (int i = 0; i < 6; ++i)
            movingFlag[i] = false;
        startPoint = new Vector3[6];
        targetPoint = new Vector3[6];
    }
	// Use this for initialization
	void Start () {
        init();
	}

    public Vector3 offset;
    private bool[] movingFlag = { false, false, false, false, false, false };
    private const int movingFrames = 50;
    private int tick;
    private Vector3[] startPoint;
    private Vector3[] zeroPoint = { new Vector3(0, 0, 0), new Vector3(-24.07f, 3f, -3.46f), new Vector3(-30.78f, 6f, -12.01f), new Vector3(-49.33f, 9f, -16.5f), new Vector3(-49.34f, 12f, -16f), new Vector3(-49.86f, 15f, -16.2f) };
    private Vector3[] splitPoint = { new Vector3(0, 0, 0), new Vector3(-24.07f, 3f+5, -3.46f), new Vector3(-30.78f, 6f+5*2, -12.01f), new Vector3(-49.33f, 9f+5*3, -16.5f), new Vector3(-49.34f, 12f+5*4, -16f), new Vector3(-49.86f, 15f+5*5, -16.2f) };
    private Vector3[] targetPoint;
	// Update is called once per frame
	void FixedUpdate () {
        tick++;
        if (tick == movingFrames)
        {
            for (int i = 0; i < 6; ++i)
            {
                if (movingFlag[i])
                {
                    GameObject.Find("root").transform.Find((i + 1).ToString()).position = targetPoint[i];
                    movingFlag[i] = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < 6; ++i)
            {
                if (movingFlag[i])
                {
                    GameObject.Find("root").transform.Find((i + 1).ToString()).position += (targetPoint[i] - startPoint[i]) / movingFrames;
                }
            }
        }
	}
    public void split()
    {
        for (int i = 0; i < 6; ++i)
        {
            movingFlag[i] = true;
            tick = 0;
            startPoint[i] = GameObject.Find("root").transform.Find((i + 1).ToString()).position;
        }
        targetPoint = splitPoint;
    }
    public void merge()
    {
        for (int i = 0; i < 6; ++i)
        {
            movingFlag[i] = true;
            tick = 0;
            startPoint[i] = GameObject.Find("root").transform.Find((i + 1).ToString()).position;
        }
        targetPoint = zeroPoint;
    }
    public void choose(int a)
    {
        for (int i = 0; i < 6; ++i)
        {
            if (i+1 != a)
            {
                GameObject.Find("root").transform.Find((i + 1).ToString()).gameObject.SetActive(false);
            }
        }
    }
    public void showAll()
    {
        for (int i = 0; i < 6; ++i)
        {
            GameObject.Find("root").transform.Find((i + 1).ToString()).gameObject.SetActive(true);
        }
    }
}
