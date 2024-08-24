using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HaloAnimation : MonoBehaviour
{
    private Vector3 startPosition;
    private GameObject[] taggedObjects;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        taggedObjects = GameObject.FindGameObjectsWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        HandleKeyPress();
        GameObject currentTarget = taggedObjects[currentIndex];

        float xPos = currentTarget.transform.position.x;
        float zPos = currentTarget.transform.position.z;

        float sinValue = Mathf.Sin(Time.frameCount * Mathf.PI / 180f) ;
        transform.position = new Vector3(xPos, startPosition.y + (sinValue / 3), zPos);

    }

    private void HandleKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DecreaseIndex();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IncreaseIndex();
        }
    }

    private void DecreaseIndex()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
        }
        else
        {
            currentIndex = taggedObjects.Length - 1;
        }
    }

    private void IncreaseIndex()
    {
        if (currentIndex < taggedObjects.Length - 1)
        {
            currentIndex++;
        }
        else
        {
            currentIndex = 0;
        }
    }



}
