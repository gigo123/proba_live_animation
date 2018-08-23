using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girl_start : MonoBehaviour {
   
    public GameObject start_portal;   //  оюек портала
    public Texture m_MainTexture, m_Normal, m_Metal;
    public float startDissolv = 0 ;  //  змынна початку зникнення
    Material portal_material; //  материал портала

    Renderer[] girl_render;
    public Material girl_material;
    float opaciry_val = 0.1f; //  сначене прозначности портала
    float fade = 0;//  затухание протала
    float moveOfsetx = 0;//  модификатор движения 
    bool isTriger = false;
    bool isDissolve = false;
    void Start () {     
       this.transform.position = new Vector3(27, -10, -7);   //  стартова позицыя 
        portal_material = start_portal.GetComponent<Renderer>().sharedMaterial;
        portal_material.SetFloat("_fade", fade);
        portal_material.SetFloat("_opacity", opaciry_val);

      

    }
    // Update is called once per frame
    void Update()
    {
        bool portal_destroy = false;
        if (start_portal)  // якщо портал ще ынуэ
        { 
            portal_material.SetFloat("_fade", fade);
        }
        if (Time.timeSinceLevelLoad > 5.2f)
        {
            if (isTriger == false)
            {
                this.transform.position = new Vector3(27, 0, -7);
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

        if(startDissolv ==1)  //   якщо активацыя   ефекту сщезння
        {
            girl_render = this.GetComponentsInChildren<Renderer>();
            foreach (Renderer render_child in girl_render)
            {
               // render_child.material = girl_material;
                 girl_material = render_child.sharedMaterial;

                //  girl_material.SetTexture("_Albedo", m_MainTexture);

                girl_material.SetFloat("_efectActiv", 1);

              
            }
        }
        else
        {
            girl_render = this.GetComponentsInChildren<Renderer>();
            foreach (Renderer render_child in girl_render)
            {
                // render_child.material = girl_material;
                girl_material = render_child.sharedMaterial;

                //  girl_material.SetTexture("_Albedo", m_MainTexture);

                girl_material.SetFloat("_efectActiv", 0);


            }
        }
   

    }      
}
