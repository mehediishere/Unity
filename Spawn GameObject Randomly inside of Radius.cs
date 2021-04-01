using UnityEngine;

public class spawnItem : MonoBehaviour
{
    public GameObject spawnPoint, target;
    Vector3 originPoint;
    int item = 0;

    private void Start()
    {
        enemyspawn();
    }

    void enemyspawn()
    {
        while(item < 5)
        {
            float rotateObject = Random.Range(0f, 360f);

            float radius = 5f;
            originPoint = spawnPoint.gameObject.transform.position;
            originPoint.x += Random.Range(-radius, radius);
            originPoint.z += Random.Range(-radius, radius);

            Instantiate(target, originPoint, Quaternion.Euler(new Vector3(0f, rotateObject, 0f)));

            item++;
        }
    }
}
