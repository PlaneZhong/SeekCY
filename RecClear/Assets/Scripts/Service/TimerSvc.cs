/****************************************************
    文件：TimeSys.cs
	作者：Weny
    QQ ：1785275942
    日期：2018/9/25 17:59:47
	功能：定时回调服务
*****************************************************/

using System;
using UnityEngine;

public class TimerSvc : MonoBehaviour {
    public static TimerSvc Instance;
    private PETimer pt;

    public void InitSvc() {
        Instance = this;
        pt = new PETimer();
        pt.SetLog((string info) => {
            Debug.Log(info);
        });
    }

    public void Update() {
        pt.Update();
    }

    public int AddTask(Action<int> callback, double delay, PETimeUnit timeUnit = PETimeUnit.Millisecond, int count = 1) {
        return pt.AddTimeTask(callback, delay, timeUnit, count);
    }

    public bool ReplaceTask(int tid, Action<int> callback, double delay, PETimeUnit timeUnit = PETimeUnit.Millisecond, int count = 1) {
        return pt.ReplaceTimeTask(tid, callback, delay, timeUnit, count);
    }

    public bool DelTask(int tid) {
        return pt.DeleteTimeTask(tid);
    }

}