using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator anim;
    public int noOfJs = 0;
    float lastJTime = 0;
    public float maxComboDelay = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        anim.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastJTime > maxComboDelay)
        {
            noOfJs = 0;
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            lastJTime = Time.time;
            noOfJs++;
            if(noOfJs == 1)
            {
                anim.SetBool("Attack1", true);
            }
            noOfJs = Mathf.Clamp(noOfJs, 0, 3);
        }
    }

    public void return1()
    {
        if (noOfJs >= 2)
        {
            anim.SetBool("Attack2", true);
            anim.SetBool("Attack1", false);
        }
        else
        {
            anim.SetBool("Attack1", false);
            noOfJs = 0;
        }
    }
    public void return2()
    {
        if (noOfJs >= 3)
        {
            anim.SetBool("Attack3", true);
        }
        else
        {
            anim.SetBool("Attack2", false);
            noOfJs = 0;
        }
    }
    public void return3()
    {
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("Attack3", false);
        noOfJs = 0;
    }
}
