    //@Hellium
    
    public Camera Camera;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.Play("animation name");
            Shoot();
        }
    }
    
    public void Shoot()
    {

        Ray ray = Camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(1000); // You may need to change this value according to your needs
                                              // Create the bullet and give it a velocity according to the target point computed before
        var bullet = Instantiate(projectile, ProjectilePos.transform.position, ProjectilePos.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = (targetPoint - ProjectilePos.transform.position).normalized * 70; // 70 - shoot speed
    }
