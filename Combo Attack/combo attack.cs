using UnityEngine;

public class combo : MonoBehaviour
{
    Animator anim;
    int noOfClicks; //Determines Which Animation Will Play
    bool canClick; //Locks ability to click during Animation event
    public string attack1, attack2, attack3;


    void Start()
    {
        //Initialize appropriate components
        anim = GetComponent<Animator>();

        noOfClicks = 0;
        canClick = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            ComboStarter(); 
        }
        //Debug.Log(noOfClicks);
    }

    void ComboStarter()
    {
        if (canClick)
        {
            noOfClicks++;
        }

        if (noOfClicks == 1)
        {
            anim.SetInteger("ComboState", 1);
        }
    }

    public void ComboCheck() //"ComboCheck()" need to added in animation event of every attack. Event may added at the end of animation or as it necessary
    {
        canClick = false;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(attack1) && noOfClicks == 1)
        {
            anim.SetInteger("ComboState", 4);
            canClick = true;
            noOfClicks = 0;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName(attack1) && noOfClicks >= 2)
        {
            anim.SetInteger("ComboState", 2);
            canClick = true;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName(attack2) && noOfClicks == 2)
        {
            anim.SetInteger("ComboState", 4);
            canClick = true;
            noOfClicks = 0;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName(attack2) && noOfClicks >= 3)
        {
            anim.SetInteger("ComboState", 3);
            canClick = true;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName(attack3))
        {
            anim.SetInteger("ComboState", 4);
            canClick = true;
            noOfClicks = 0;
        }
    }
    
}
