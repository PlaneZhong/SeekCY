using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmControl : MonoBehaviour {

    public GameObject player;
    public GameObject cm;
    Vector3 vs = new Vector3(0, 0, -10);
    Vector3 lpos = new Vector3(0, 0, -10);
    Vector3 rpos = new Vector3(7, 0, -10);
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (cm.transform.position != player.transform.position)
        {
            if (Vector3.Distance(cm.transform.position,lpos)>0.1&&Vector3.Distance(cm.transform.position,rpos)>0.1)
            {
                cm.transform.position = Vector3.Lerp(cm.transform.position + vs, player.transform.position + vs, 5f);
            }
           
        }
	}

    
}
