using UnityEngine;
public class enemyAttack : MonoBehaviour
{
    Animator anim;
    Vector3 player;
    
    public float health = 100.0f;
    [Tooltip("From this range AI will attack player")]
    public float attackRange = 3.0f;
    [Tooltip("At this range AI will detect player and walk/run toward it")]
    public float detectRange = 30.0f;
    [Tooltip("Note: If player get or is outside of this range even once, then attach object will destroy even if player come back in non-destroy range. It's suggested to keep big range value")]
    public float distroyRange = 50.0f;
    public float runSpeed = 5.0f;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0)
        {
            anim.Play("die");
            Destroy(gameObject, 10.0f);
            return;
        }
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;

        Vector3 rot = Quaternion.LookRotation(player - transform.position).eulerAngles;
        rot.x = rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);

        float dist = Vector3.Distance(player, transform.position);
        if (dist < detectRange)
        {
            if (dist > attackRange)
            {
                anim.SetInteger("state", 5);
                transform.position = Vector3.MoveTowards(transform.position, player, runSpeed * Time.deltaTime);
            }
            else
            {
                anim.SetInteger("state", 2);
            }
        }
        else if (dist > distroyRange)
        {
            Destroy(gameObject, 10.0f);
        }
        else
        {
            anim.SetInteger("state", 0);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distroyRange);
    }
}
