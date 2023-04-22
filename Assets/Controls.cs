using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] int gameSpeed = 1;




    private void Awake()
    {


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   // change gamespeed to 1x, 2x or 4x
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            gameSpeed *= 2;
            if (gameSpeed > 4)
                gameSpeed = 1;

            Time.timeScale = gameSpeed;
        }

        //Movement

        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, yDirection, 0.0f);
        transform.position += moveDirection * gameSpeed * .01f;

    }


}
