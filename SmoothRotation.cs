Vector3 rotate = Quaternion.LookRotation(target.position - transform.position).eulerAngles;
rotate.x = rotate.z = 0;
transform.rotation = Quaternion.Euler(rotate);

 // or
 
Vector3 newtarget = target.position;
newtarget.y = transform.position.y;
transform.LookAt(newtarget);

// or

Vector3 dir = target.position - transform.position;
dir.y = 0;
transform.rotation = Quaternion.LookRotation(dir);
