#region 模块信息
// **********************************************************************
// Copyright (C) 2017 The company name
//
// 文件名(File Name):             MakeGhost.cs
// 作者(Author):                  #757end#
// 创建时间(CreateTime):           #17.6.7#
// 修改者列表(modifier):
// 模块描述(Module description):
// **********************************************************************
#endregion
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGhost : MonoBehaviour {
    public int ghostNumber;       //数量
    public float ghostDistance;   //距离
    public GameObject ghost;       //残影
	// Use this for initialization
	void Start () {
        //主角最上层
        transform.GetComponent<SpriteRenderer>().sortingOrder = 1;
	}
	
	// Update is called once per frame
	void Update () {
        //移动了就生成残影
        if (PlayerMove.isMove)
        {
            for (int i = 0;i< ghostNumber;i++)
            {
                if (ghostNumber >transform.childCount)
                {
                    GameObject go = Instantiate(ghost);
                    go.transform.SetParent(transform, false);
                    //设置残影位置
                    transform.GetChild(i).position = new Vector3(transform.position.x - ghostDistance * (i + 1), transform.position.y, transform.position.z);
                }
                //移动显示残影
                transform.GetChild(i).gameObject.SetActive(true);
                //改图
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = transform.GetComponent<SpriteRenderer>().sprite;
                //改透明度
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (1 - (i + 1) * 0.2f));//1- ( 0.2/0.4/0.6/0.8...)jizhiruwo
               // print((1 - (i + 1) * 0.2f));
            }
        }
        else
        {
            //停止就不显示
            for (int i = 0;i< transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
