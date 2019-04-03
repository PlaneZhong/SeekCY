using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour {

    public Animator am;
    public GameObject player;
    public float speed;
    Vector3 lpos = new Vector3(-6.6f, 0, 0);
    Vector3 rpos = new Vector3(6.7f, 0, 0);
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.A))
        {
            player.transform.localEulerAngles = Vector3.up*180;
            if (Vector3.Distance(player.transform.position, lpos) > 0.1)
            {
                player.transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
            }
           
            am.SetBool("run", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            am.SetBool("run", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.localEulerAngles = Vector3.up * 1;
            if (Vector3.Distance(player.transform.position, rpos) > 0.1)
            {
                player.transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
            }
            am.SetBool("run", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            am.SetBool("run", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            am.SetTrigger("jump1");
        }
        
	}
   

}
