using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlayer : MonoBehaviour
{
    public bool isRewinding = false;

    List<Vector3> positions;
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartRewind2();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            StopRewind2();
        }
    }

    void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }
    void Rewind()
    {
        transform.position = positions[0];
       
    }
    void Record()
    {
        positions.Insert(0, transform.position);
    }
    public void StartRewind2()
    {
        isRewinding = true;
    }

    public void StopRewind2()
    {
        isRewinding = false;
    }
}
