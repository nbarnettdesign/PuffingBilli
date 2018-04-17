using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Size
{
    SIZE_1,
    SIZE_2,
    SIZE_3,
    SIZE_4
}
public class Fish : MonoBehaviour
{
    [SerializeField] Size fishSize;
    [SerializeField] float leftwardSpeed = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * leftwardSpeed * Time.deltaTime);
    }

    public Size GetSize()
    {
        return fishSize;
    }
}
