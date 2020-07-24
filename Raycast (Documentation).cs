        
        RaycastHit hit;
        
        float detectAtDistance = 20.0f, unableToDetectAtDistance = 30.0f
        
        void Update()
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, detectAtDistance))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * detectAtDistance, Color.yellow);
                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * unableToDetectAtDistance, Color.white);
                Debug.Log("Did not Hit");
            }
                
            ///////////////////////////////////////////////
            
                if (Physics.Raycast(transform.position, transform.forward, out hit, 20) && hit.collider.gameObject.CompareTag("Object Tag Name Here"))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20.0f, Color.red);
                    Debug.Log("Did Hit");
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20.0f, Color.white);
                    Debug.Log("Did not Hit");
                }
        }
