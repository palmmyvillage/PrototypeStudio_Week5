using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D pos;
    
    private float posX;
    private float posY;

    private Animator anim;

    public Rigidbody2D spring;

    public AudioHigh normal, low, high, clap;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Rigidbody2D>();
        posX = pos.position.x;
        posY = pos.position.y;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        posX = Input.GetAxis("Horizontal") * 0.1f;
        pos.position += new Vector2(posX, 0);

        if (pos.position.x <= -6)
        {
            pos.position = new Vector2(-6,posY);
        }

        if (pos.position.x >= 6)
        {
            pos.position = new Vector2(6,posY);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            if (anim.GetBool("isRunning") == false)
            {
                anim.SetBool("isRunning",true);
            }
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            if (anim.GetBool("isRunning") == true)
            {
                anim.SetBool("isRunning", false);
            }
        }
        
        spring.position += new Vector2(Input.GetAxis("Vertical"), 0);
        
        //audio
        if (Input.GetAxis("Horizontal") > 0)
        {
            high.playSound();
            clap.playSound();
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            low.playSound();
            clap.playSound();
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            normal.playSound();
            clap.playSound();
        }
            
    }
}
