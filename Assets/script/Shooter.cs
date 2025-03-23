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

                if ( hit.collider.name == "alien" || hit.collider.name == "alien1" || hit.collider.name == "alien2" || hit.collider.name == "alien3" 
                || hit.collider.name == "alien4" || hit.collider.name == "alien5" || hit.collider.name == "alien6" || hit.collider.name == "alien7" 
                || hit.collider.name == "alien8" || hit.collider.name == "alien9" || hit.collider.name == "alien10" || hit.collider.name == "alien11" || hit.collider.name == "alienboss" )
                {
                    Enemy alien = hit.collider.GetComponent< Enemy >();
 
                    if ( alien != null )
                    {
                        alien.TakeDamage(2);
                    }
 
                }

                
            }
        }
        
    }
}
