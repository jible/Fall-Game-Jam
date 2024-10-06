using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class knifeScript : MonoBehaviour
{
    public float bladeLength = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Ray ray = new Ray(transform.position, transform.forward); // this only works if the knife is facing the pumpkin
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, bladeLength))
        {
            GameObject pumpkin = hit.collider.gameObject;
            if (pumpkin.CompareTag("pumpkin")){

                int triangleIndex = hit.triangleIndex;
                pumpkin.GetComponent<PumpkinScript>().removeTri(triangleIndex);

            }
            

        }


    }


}
