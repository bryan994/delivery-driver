using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32(255, 251, 61, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Customer" && hasPackage)
        {
            Debug.Log("I recevied the package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Picked");
            Destroy(other.gameObject, destroyDelay);
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
        }
    }
}
