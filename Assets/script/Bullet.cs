using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Enemy {

    
    void DoStart()
    {
        
    }

    void Update()
    {
        //    target = GameObject.Find("player");
        // orientation = target.transform.position;
        if((transform.position.x>=4 || transform.position.x <= -4) 
            || (transform.position.y >=5.5 || transform.position.y <= -5.5)){

            Destroy(this.gameObject);
        }
    }

}
