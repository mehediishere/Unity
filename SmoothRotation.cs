//Source : https://forum.unity.com/threads/locking-the-x-and-z-axis-while-using-transform-lookat.521817/

Vector3 rot = Quaternion.LookRotation(target.position - transform.position).eulerAngles;
rot.x = rot.z = 0;
transform.rotation = Quaternion.Euler(rot);

 // or
 
Vector3 newtarget = target.position;
newtarget.y = transform.position.y;
transform.LookAt(newtarget);

// or

Vector3 dir = target.position - transform.position;
dir.y = 0;
transform.rotation = Quaternion.LookRotation(dir);
