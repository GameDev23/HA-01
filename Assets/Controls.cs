using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] int gameSpeed = 1;
    SpriteRenderer[] spriteRenderers;
    Color[] colors;


    private void Awake()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        colors = new Color[spriteRenderers.Length];
        
        for(int i = 0; i < spriteRenderers.Length; i++)
        {
            colors[i] = spriteRenderers[i].color;
        }
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

        // change sprite color
        if (Input.GetKeyDown(KeyCode.F))
        {
            applyRandomColor();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            resetColor();
        }

        //Movement

        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, yDirection, 0.0f);
        transform.position += moveDirection * gameSpeed * .01f;






    }

    private void applyRandomColor()
    {
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].color = Random.ColorHSV();
        }
    }

    private void resetColor()
    {
        for(int i = 0;i < spriteRenderers.Length; i++)
        {
            spriteRenderers[(i)].color = colors[i];
        }
    }
}
