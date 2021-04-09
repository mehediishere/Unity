using UnityEngine;

public class wandering : MonoBehaviour
{
    public GameObject spawnItem;
    GameObject spawnPoint, go;
    Vector3 originPoint;
    [Range(5, 50)]
    public float radius = 5.0f;

    public string spawnPointTag;

    public void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag(spawnPointTag);
        spawnAndLocate();
    }

    public void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, originPoint, 2 * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "locate")
        {
            Destroy(go);
            spawnAndLocate();
        }
    }

    void spawnAndLocate()
    {
        float rotateObject = Random.Range(0f, 360f);

        originPoint = spawnPoint.transform.position;
        originPoint.x += Random.Range(-radius, radius);
        originPoint.z += Random.Range(-radius, radius);

        go = Instantiate(spawnItem, originPoint, Quaternion.identity) as GameObject;
        spawnItem.transform.position = originPoint;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(spawnPoint.transform.position, radius);
    }
}
