using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girl_start : MonoBehaviour {
   
    public GameObject start_portal;   //  оюек портала
    public float startDissolv = 0 ;  //  змынна початку зникнення
    Material portal_material; //  материал портала

    Renderer[] girl_render;
    public Material girl_material;  //  основний материал дівчинки
    public Material girl_hair_material; //   волосся  дівчинки
    float opaciry_val = 0.1f; //  сначене прозначности портала
    float fade = 0;//  затухание протала
    float moveOfsetx = 0;//  модификатор движения 
    bool isTriger = false;

    float girl_fade = 0f;

    void Start () {     
       this.transform.position = new Vector3(27, -10, -7);   //  стартова позицыя 
        portal_material = start_portal.GetComponent<Renderer>().sharedMaterial;
        portal_material.SetFloat("_fade", fade);
        portal_material.SetFloat("_opacity", opaciry_val);

        girl_material.SetFloat("_efectActiv", startDissolv);
        girl_hair_material.SetFloat("_efectActiv", startDissolv);

        girl_material.SetFloat("_DissolveAmount", girl_fade);
        girl_hair_material.SetFloat("_DissolveAmount", girl_fade);



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

        if(startDissolv >0  && startDissolv < 1)  //   якщо активацыя   ефекту сщезння
        {
           // girl_render = this.GetComponentsInChildren<Renderer>();
           // foreach (Renderer render_child in girl_render)
            //{
               // render_child.material = girl_material;
               //  girl_material = render_child.sharedMaterial;

                //  girl_material.SetTexture("_Albedo", m_MainTexture);

                girl_material.SetFloat("_efectActiv", startDissolv);
            girl_hair_material.SetFloat("_efectActiv", startDissolv);


            // }
        }
        if (startDissolv >0.98)
        {
            //girl_render = this.GetComponentsInChildren<Renderer>();
            //foreach (Renderer render_child in girl_render)
            //{
            // render_child.material = girl_material;
            //   girl_material = render_child.sharedMaterial;

            //  girl_material.SetTexture("_Albedo", m_MainTexture);
            girl_fade += 0.012f;
                girl_material.SetFloat("_DissolveAmount", girl_fade);
            girl_hair_material.SetFloat("_DissolveAmount", girl_fade);


            // }
        }
   

    }      
}
