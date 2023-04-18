using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float movementSpeed = 10f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() 
    {
        float hMovement = Input.GetAxis("Horizontal") * movementSpeed / 2;
        float vMovement = Input.GetAxis("Vertical") * movementSpeed;

        transform.Translate(new Vector3(hMovement, 0, vMovement) * Time.deltaTime);

        // Actualizar el valor del parámetro "isRunning" en el Animator
        if (vMovement > 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("runningBackward", false);
        }
        else if (vMovement < 0)
        {
            anim.SetBool("runningBackward", true);
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("runningBackward", false);
        }


        if (hMovement > 0)
        {
            anim.SetBool("rightRun", true);
            anim.SetBool("leftRun", false);
        }

        else if (hMovement < 0)
        {
            anim.SetBool("leftRun", true);
            anim.SetBool("rightRun", false);
        }
        else
        {
            anim.SetBool("rightRun", false);
            anim.SetBool("leftRun", false);
        }



    }
}

