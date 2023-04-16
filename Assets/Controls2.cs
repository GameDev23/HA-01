using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls2 : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    int currentIndex = 0;
    Vector3 pos;

    void Awake()
    {
        foreach(GameObject elem in gameObjects)
        {
            elem.SetActive(false);
        }
        gameObjects[0].SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Movement
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            
            GameObject gameObject = gameObjects[currentIndex];

            //place  currentSprite to -14z
            pos = gameObject.transform.position;
            pos.z = -20;
            gameObject.transform.position = pos;

            //get new Object
            currentIndex = (currentIndex + 1) % gameObjects.Length;
            gameObject = gameObjects[currentIndex];

            //place new Sprite to 0z
            pos = gameObject.transform.position;
            pos.z = 0f;
            gameObject.transform.position = pos;
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            changeSprite(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            changeSprite(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            changeSprite(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            changeSprite(3);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            changeSprite(4);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            changeSprite(5);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            changeSprite(6);
        }





    }

    private void changeSprite(int index)
    {
        if (index >= gameObjects.Length)
        {
            return; // out of bounds
        }
        Vector3 pos;

        //hide current object
        GameObject gameObject = gameObjects[currentIndex];
        gameObject.SetActive(false);
        pos = gameObject.transform.position;


        //unhide new object
        currentIndex = index;
        gameObject = gameObjects[index];
        gameObject.SetActive(true);

        //put it to front
        gameObject.transform.position = pos;

    }
}
