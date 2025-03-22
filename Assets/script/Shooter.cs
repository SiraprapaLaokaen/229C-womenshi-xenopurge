using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform Bullet;
    public GameObject vfxFirePoint , vfxHitpoint;


    void Update()
    {
        Shooting();
    } // Update
 
    void Shooting()
    {
        Debug.DrawRay( Bullet.position , transform.forward * 30,Color.green );

        RaycastHit hit;
 
        if ( Physics.Raycast ( Bullet.position , transform.forward , out hit, 30f ) )
        {
            Debug.DrawRay( Bullet.position, transform.forward * 30, Color.red);

            if ( Input.GetMouseButtonDown(0) )
            {
                Instantiate( vfxFirePoint , Bullet.position , Quaternion.identity );
 
                Instantiate( vfxHitpoint , hit.point , Quaternion.identity );

                if ( hit.collider.name == "enemy")
                {
                    Enemy enemy = hit.collider.GetComponent< Enemy >();
 
                    if ( enemy != null )
                    {
                        enemy.TakeDamage(2);
                    }
 
                }
            }
        }
        
    }
}
