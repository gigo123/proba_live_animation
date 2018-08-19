using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girl_start : MonoBehaviour {
    //IEnumerator Example()
    //
    public GameObject start_portal;
    Material portal_material;
    float opaciry_val = 0;
    float fade = 0;
    float moveOfsetx = 0;
    void Start () {
        //   sr= gameObject.AddComponent<girl_start>;
        this.transform.position = new Vector3(26, -10, 2);
        //ExecuteAfterTime(5);
          //  this.transform.position = new Vector3(26, 0, 0);

        }

    // Update is called once per frame
    void Update()
    {

        bool isTriger = false;
        bool portal_destroy = false;
        if (start_portal)
        { 
            portal_material = start_portal.GetComponent<Renderer>().sharedMaterial;
            portal_material.SetFloat("_fade", fade);
        }
        if (Time.timeSinceLevelLoad > 5.2f)
        {
            if (isTriger == false)
            {
                this.transform.position = new Vector3(26, 0.8f, 2);
                isTriger = true;
                
            }

        }
        else
        {
            fade += 0.005f;
        }
        if (Time.timeSinceLevelLoad > 6.2f)
        {
        
            if (start_portal)
            {
                portal_material.SetFloat("_opacity", opaciry_val);
                opaciry_val += 0.004f;
                fade -= 0.005f;
            }
        }

        if (Time.timeSinceLevelLoad > 12.2f)
        {
            if (portal_destroy == false)
            {
                    Destroy(start_portal);
                    portal_destroy = true;
             }
        }
        if (Time.timeSinceLevelLoad > 18.5f)
        {
            transform.position = new Vector3(26 + moveOfsetx, 0.8f, 2+ moveOfsetx);
             moveOfsetx += 0.1f;
        }

    }
        
}
