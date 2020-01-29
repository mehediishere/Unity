using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform head;
    Animator anim;
    //bool pursuing = false;
    //public Slider EnemyHealthbar;
    //public Slider PlayerHealthbar;


    //public GameObject sphereOnEnemy;

    [SerializeField] double EnemyNoticePlayer = 10;
    [SerializeField] double EnemySeeingAngle = 360;
    [SerializeField] double EnemyAttackRange = 2;

    string state = "patrol";
    public GameObject[] waypoints;
    int currentWP = 0, countAttack = 0;
    public float rotationSpeed = 0.2f;
    public float speed = 1.5f;
    public float accuracyWP = 5.0f;

    float currentTime = 0f;
    public float counterTime = 5f;
    float var1 = 1;

    float xPos;
    float zPos;
    public float minXpos = 328.88f;
    public float maxXpos = 358.39f;
    public float minZpos = 513.53f;
    public float maxZpos = 564.9f;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentTime = counterTime;
    }

    // Update is called once per frame
    void Update()
    {
        //if (EnemyHealthbar.value <= 0)
        //return;

        Vector3 direction = player.position - this.transform.position;
        direction.y = 0;
        float angle = Vector3.Angle(direction, head.up);

        if (state == "patrol" && waypoints.Length > 0)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWaiting", false);
            anim.SetBool("isWalking", true);
            if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
            {
                    //for random waypoint(next 3 line will be in comment section) -> //currentWP = Random.Range(0, waypoints.Length);
                    currentWP++;
                    print("currentWP : " + currentWP);
                    print("waypoints.Length: " + waypoints.Length);
                    if (currentWP >= waypoints.Length)
                    {
                        currentWP = 0;
                    }
                    //currentWP = Random.Range(0, waypoints.Length);
                        waypoints[currentWP].transform.position = new Vector3(xPos, 104.297f, zPos);
                

            }
            //rotate towards waypoint
            direction = waypoints[currentWP].transform.position - transform.position;
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            this.transform.Translate(0, 0, Time.deltaTime * speed);
            positionvalue();
        }


        if (Vector3.Distance(player.position, this.transform.position) < EnemyNoticePlayer && (angle < EnemySeeingAngle || state == "pursuing"))  //10 -> at which distance enemy will notice
                                                                                                                                                  //60 -> from which angle enemy will get to see player 
        {
            //Vector3 direction = player.position - this.transform.position;
            //direction.y = 0;
            state = "pursuing";
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            //anim.SetBool("isIdle", false);
            if (direction.magnitude > EnemyAttackRange)  //1.5 -> at which distance enemy stop & attack
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWaiting", false);
                //sphereOnEnemy.SetActive(false);

            }
            else
            {
                anim.SetBool("isWalking", false);
                if (var1 == 1)
                {
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isAttacking", true);
                    anim.SetBool("isWaiting", false);
                    //sphereOnEnemy.SetActive(true);
                    okey();
                }
                else if (var1 == 2)
                {
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isAttacking", false);
                    anim.SetBool("isWaiting", true);
                    okey();
                }
                else
                {
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isAttacking", true);
                    //sphereOnEnemy.SetActive(true);
                }
            }

        }
        else
        {
            //anim.SetBool("isIdle", true);
            //sphereOnEnemy.SetActive(false);
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWaiting", false);
            state = "patrol";
        }

    }
    public void okey()
    {
        currentTime -= 1 * Time.deltaTime;
        //print(currentTime);
        if (currentTime <= 0 && var1 == 1)
        {
            var1 = 2;
            currentTime = counterTime+1;
        }
        else if (currentTime <= 0 && var1 == 2)
        {
            var1 = 1;
            currentTime = counterTime;
        }
    }
    public void positionvalue()
    {
        xPos = Random.Range(minXpos, maxXpos);
        zPos = Random.Range(minZpos, maxZpos);
    }

}
