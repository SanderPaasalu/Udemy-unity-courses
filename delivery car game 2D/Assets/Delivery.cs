using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor;
    [SerializeField] Color32 noPackageColor;

    bool hasPackage;
    [SerializeField] float disappearanceDelay;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    // What happens on collision
    void OnCollisionEnter2D(Collision2D collsion)
    {

    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        // check if triggered package
        if (trigger.tag == "Package" && !hasPackage){
            spriteRenderer.color= hasPackageColor;
            Debug.Log("Package has been picked up");
            hasPackage = true;
            // destroy package once has been picked up
            Destroy(trigger.gameObject, disappearanceDelay);
            
        }

        // check if triggered customer
        if(trigger.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package has been delivered");
            hasPackage = false;
            spriteRenderer.color= noPackageColor;
        }
        else
        {
            Debug.Log("Where's the package you cunt?");
        }

    }
}
