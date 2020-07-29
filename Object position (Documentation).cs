//Move toward an object
float speed = 5.0f; 
public Transform targer;
transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
