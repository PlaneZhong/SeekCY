/****************************************************
    文件：DynamicWnd.cs
	作者：Plane
    邮箱: 1785275942@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;

public class DynamicWnd : WindowRoot {
    #region ///=== UI    Define     ===///
    public Text txtTips;
    public Animation tipsAni;
    public Transform hpItemRoot;
    #endregion

    #region ///=== Data  Area       ===///
    private bool isTipsShow = false;
    private Queue<string> tipsQue = new Queue<string>();
    #endregion

    protected override void InitWnd() {
        base.InitWnd();

        SetActive(txtTips, false);
    }

    #region ///=== Main Functions ===///
    private void Update() {
        //tips
        if (tipsQue.Count > 0 && isTipsShow == false) {
            lock (tipsQue) {
                string tips = tipsQue.Dequeue();
                isTipsShow = true;
                SetTips(tips);
            }
        }
    }
    #endregion

    #region Tips相关
    public void AddTips(string tips) {
        lock (tipsQue) {
            tipsQue.Enqueue(tips);
        }
    }

    private void SetTips(string tips) {
        int len = tips.Length;
        SetText(txtTips, tips);
        SetActive(txtTips);
        AnimationClip clip = tipsAni.GetClip("TipsShowAni");
        tipsAni.Play();
        //延时回调 关闭激活状态
        StartCoroutine(AniPlayDone(clip.length, () => {
            SetActive(txtTips, false);
            isTipsShow = false;
        }));
    }

    IEnumerator AniPlayDone(float sec, Action cb) {
        yield return new WaitForSeconds(sec);
        if (cb != null) {
            cb();
        }
    }
    #endregion
}