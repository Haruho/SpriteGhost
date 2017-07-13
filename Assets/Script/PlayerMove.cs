using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed;
    public static bool isMove;
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            isMove = true;
            anim.SetBool("run",true);
            transform.Translate(speed * Time.deltaTime ,0,0);
        }
        else
        {
            isMove = false;
            anim.SetBool("run", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            isMove = true;
            transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(0,180,0);
            anim.SetBool("run", true);
        }
    }
}
