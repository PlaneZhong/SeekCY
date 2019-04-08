using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosControl : MonoBehaviour {

    public Animator am;
	// Use this for initialization
	void Start () {

        //GameObject person = Instantiate((GameObject)Resources.Load("yueya"));
        //person.transform.position = new Vector3(0, 0, 0);
        //Debug.Log("2");
        //GameObject ps= Instantiate((GameObject)Resources.Load("yueya"));
        //ps.transform.position = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void Setpos1()
    {
        am.SetBool("walk", false);
        am.SetBool("hand", false);
        am.SetBool("idle", true);
    }
    public void Setpos2()
    {
        am.SetBool("idle", false);
        am.SetBool("walk", false);
        am.SetBool("hand", true);
    }
    public void Setpos3()
    {
        am.SetBool("hand", false);
        am.SetBool("idle", false);
        am.SetBool("walk", true);
    }

}
