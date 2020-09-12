    // Note: At projectile prefab it's necessary to have a collider & a rigidbody.
    
    public GameObject projectile,ProjectilePos;
    GameObject shot;
    [Range(1,10)]
    public float shootForce = 1.0f;
    
    public void activate()
    {
        shot = GameObject.Instantiate(projectile, ProjectilePos.transform.position, ProjectilePos.transform.rotation);
        //shot.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce * 1000);
        //OR Next two line
        Rigidbody rb = shot.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 40;
    }
