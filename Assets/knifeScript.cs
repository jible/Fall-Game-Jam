using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class knifeScript : MonoBehaviour
{
    public Transform pumRef;
    public float bladeLength = 5f;
    // Update is called once per frame
    private void Start()
    {
        pumRef = GameObject.FindWithTag("pumpkin").transform;
    }
    void FixedUpdate()
    {
        facePump();

        Ray ray = new Ray(transform.position, transform.forward); // this only works if the knife is facing the pumpkin
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * bladeLength, Color.red, 0.1f);

        if (Physics.Raycast(ray, out hit, bladeLength))
        {
            GameObject pumpkin = hit.collider.gameObject;
            if (pumpkin.CompareTag("pumpkin")){

                int triangleIndex = hit.triangleIndex;
                pumpkin.GetComponent<PumpkinScript>().removeTri(triangleIndex);
            }
        }
    }


    void facePump()
    {
        if (pumRef)
        {
            transform.LookAt(pumRef);
        }
    }

}
