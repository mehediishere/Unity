//Every attack animation need event function according to steps shown

using UnityEngine;
 
public class combo : MonoBehaviour {
       
    Animator anim;
       
    int noOfClicks; //Determines Which Animation Will Play
    bool canClick; //Locks ability to click during animation event
     
    void Start()
    {     
        //Initialize appropriate components
        anim = GetComponent<Animator>();      
               
        noOfClicks = 0;
        canClick = true;
    }
         
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { ComboStarter(); }
    }
 
    void ComboStarter()
    {      
        if (canClick)           
        {           
            noOfClicks++;
        }
                
        if (noOfClicks == 1)
        {           
            anim.SetInteger("animation", 1);
        }          
    }
     
    //Note: "ComboCheck()" will be added in animation event
    public void ComboCheck() {     
        
        canClick = false;
        
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("1st attack name") && noOfClicks == 1 ) //If the first animation is still playing and only 1 click has happened, return to idle
        {
            anim.SetInteger("animation", 4);
            canClick = true;
            noOfClicks = 0;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("1st attack name") &&  noOfClicks >= 2) //If the first animation is still playing and at least 2 clicks have happened, continue the combo 
        {         
            anim.SetInteger("animation", 2);
            canClick = true;
        }
        else if(anim.GetCurrentAnimatorStateInfo(0).IsName("2nd attack name") && noOfClicks == 2)  //If the second animation is still playing and only 2 clicks have happened, return to idle 
        {        
            anim.SetInteger("animation", 4);
            canClick = true;
            noOfClicks = 0;
        }
       else if (anim.GetCurrentAnimatorStateInfo(0).IsName("2nd attack name") && noOfClicks >= 3) //If the second animation is still playing and at least 3 clicks have happened, continue the combo
        {           
            anim.SetInteger("animation", 3);
            canClick = true;           
        }
       else if (anim.GetCurrentAnimatorStateInfo(0).IsName("3rd attack name")) //Since this is the third and last animation, return to idle 
        {          
            anim.SetInteger("animation", 4);
            canClick = true;
            noOfClicks = 0;
        }      
    }
}
