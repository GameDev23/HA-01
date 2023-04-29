using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls2 : MonoBehaviour
{
    [SerializeField] List<GameObject> sprites = new List<GameObject>();
    GameObject gameObject;
    List<Color> colors = new List<Color>();
    List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

    int currentIndex = 0;
    Vector3 pos;

    void Awake()
    {
        // set each sprite to inactive
        foreach (GameObject sprite in sprites)
        {
            sprite.SetActive(false);
        }

        // put sprite 0 to front
        pos = transform.position;
        pos.z = 0;
        gameObject = sprites[currentIndex];
        gameObject.transform.position = pos;
        gameObject.SetActive(true);

        foreach(SpriteRenderer sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(sr);
            Debug.Log(sr.name);
        }

        Debug.Log(spriteRenderers.Count);
        
        for (int i = 0; i < spriteRenderers.Count; i++)
        {
                colors.Add(spriteRenderers[i].color);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move gameobject according to camera
        gameObject = sprites[currentIndex];
        pos = transform.position;
        if (gameObject != null)
        {
            pos.z = 0;
            gameObject.transform.position = pos;
        }

        //Movement
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            
            gameObject = sprites[currentIndex];

            //place  currentSprite to -14z
            pos = gameObject.transform.position;
            pos.z = -20;
            gameObject.transform.position = pos;
            gameObject.SetActive(false);

            //get new Object
            currentIndex = (currentIndex + 1) % sprites.Count;
            gameObject = sprites[currentIndex];
            gameObject.SetActive(true);

            //place new Sprite to 0z
            pos = transform.position;
            pos.z = 0;
            gameObject.transform.position = pos;
            Debug.Log(gameObject.name + "  " + currentIndex);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeSprite(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeSprite(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            changeSprite(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            changeSprite(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            changeSprite(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            changeSprite(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            changeSprite(6);
        }

        // change sprite color
        if (Input.GetKeyDown(KeyCode.F))
        {
            applyRandomColor();
        }







    }

    private void changeSprite(int index)
    {
        
        if (index >= sprites.Count)
        {
            return; // out of bounds
        }


        
        //hide current object
        GameObject gameObject = sprites[currentIndex];
        gameObject.SetActive(false);


        //unhide new object
        currentIndex = index;
        gameObject = sprites[index];
        gameObject.SetActive(true);

        //put it to front
        gameObject.transform.position = transform.position;
        

    }

    private void applyRandomColor()
    {
        spriteRenderers = new List<SpriteRenderer>();
        colors = new List<Color>();

        foreach (SpriteRenderer sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(sr);
            Debug.Log(sr.name);
        }

        Debug.Log(spriteRenderers.Count);

        for (int i = 0; i < spriteRenderers.Count; i++)
        {
            colors.Add(spriteRenderers[i].color);
        }

        for (int i = 0; i < spriteRenderers.Count; i++)
        {
            spriteRenderers[i].color = UnityEngine.Random.ColorHSV();
        }
    }


}
