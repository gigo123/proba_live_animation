using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girl_start : MonoBehaviour {
    //IEnumerator Example()
   //

    	void Start () {
        //   sr= gameObject.AddComponent<girl_start>;
        this.transform.position = new Vector3(26, -10, 2);
        //ExecuteAfterTime(5);
          //  this.transform.position = new Vector3(26, 0, 0);

        }

        // Update is called once per frame
        void Update () {
        bool isTriger = false;
        if (Time.timeSinceLevelLoad > 5.2f){
            if (isTriger == false)
            {
                this.transform.position = new Vector3(26, 0.8f, 2);
                isTriger = true;
            }
        }
    }

      
        
}
