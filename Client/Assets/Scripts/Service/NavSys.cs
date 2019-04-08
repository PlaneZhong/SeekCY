/****************************************************
	文件：NavSys.cs
	作者：Plane
	邮箱: 1785275942@qq.com
	日期：2019/04/08 12:46   	
	功能：角色导航系统
*****************************************************/

using System;
using UnityEngine;

public class NavSys : MonoBehaviour {
    public static NavSys Instance = null;
    public float MoveSpeed = 1.0f;

    private Transform trans;
    private Vector2 target;
    private Vector2 dir;
    private Action cb;

    public void InitSvc() {
        Instance = this;
    }

    public void NavToPos(Transform trans, Vector2 target, Action cb) {
        this.trans = trans;
        this.target = target;
        this.cb = cb;
        dir = (target - new Vector2(trans.position.x, trans.position.y)).normalized;
        isTween = true;
    }

    public void NavStop() {
        isTween = false;
    }


    private bool isTween = false;
    private void Update() {
        if (isTween) {
            if (!IsArrive()) {
                trans.position += Time.deltaTime * MoveSpeed * new Vector3(dir.x, dir.y, 0);
            }
            else {
                if (this.cb != null) {
                    cb();
                }
                isTween = false;
            }
        }
    }

    private bool IsArrive() {
        if (Vector2.Distance(trans.position, target) < 0.2f) {
            trans.position = new Vector3(target.x, target.y, trans.position.z);
            return true;
        }
        else {
            return false;
        }
    }
}
