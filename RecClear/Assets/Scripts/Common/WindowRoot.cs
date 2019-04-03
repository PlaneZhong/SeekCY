/****************************************************
	文件：WindowRoot.cs
	作者：Plane
	邮箱: 1785275942@qq.com
	日期：2019/03/25 13:39   	
	功能：UI窗口基类
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WindowRoot : MonoBehaviour {
    protected GameRoot root;
    protected ResSvc resSvc;
    protected TimerSvc timerSvc;
    protected AudioSvc audioSvc;
    #region ///=== Main Functions ===///
    public virtual void SetWndState(bool isActive = true) {
        if (gameObject.activeSelf != isActive) {
            SetActive(gameObject, isActive);
        }
        if (isActive) {
            InitWnd();
        }
        else {
            ClearWnd();
        }
    }
    protected virtual void InitWnd() {
        root = GameRoot.Instance;
        resSvc = ResSvc.Instance;
        timerSvc = TimerSvc.Instance;
        audioSvc = AudioSvc.Instance;
    }
    protected virtual void ClearWnd() {
        root = null;
        resSvc = null;
        timerSvc = null;
        audioSvc = null;
    }
    #endregion

    #region ///=== Tool  Functions ===///
    protected void SetActive(GameObject go, bool state = true) {
        go.SetActive(state);
    }
    protected void SetActive(Transform trans, bool state = true) {
        trans.gameObject.SetActive(state);
    }
    protected void SetActive(RectTransform rectTrans, bool state = true) {
        rectTrans.gameObject.SetActive(state);
    }
    protected void SetActive(Image img, bool state = true) {
        img.transform.gameObject.SetActive(state);
    }
    protected void SetActive(Text txt, bool state = true) {
        txt.transform.gameObject.SetActive(state);
    }

    protected void SetText(Transform trans, int num = 0) {
        SetText(trans.GetComponent<Text>(), num);
    }
    protected void SetText(Transform trans, string context = "") {
        SetText(trans.GetComponent<Text>(), context);
    }
    protected void SetText(Text txt, int num = 0) {
        SetText(txt, num.ToString());
    }
    protected void SetText(Text txt, string context = "") {
        txt.text = context;
    }

    protected void SetSprite(Image image, string path) {
        Sprite sp = ResSvc.Instance.LoadSprite(path, true);
        image.sprite = sp;
    }

    protected Transform GetTrans(Transform trans, string name) {
        if (trans != null) {
            return trans.Find(name);
        }
        else {
            return transform.Find(name);
        }
    }
    protected Image GetImage(Transform trans, string path) {
        if (trans != null) {
            return trans.Find(path).GetComponent<Image>();
        }
        else {
            return transform.Find(path).GetComponent<Image>();
        }
    }
    protected Image GetImage(Transform trans) {
        if (trans != null) {
            return trans.GetComponent<Image>();
        }
        else {
            return transform.GetComponent<Image>();
        }
    }

    protected Text GetText(Transform trans, string path) {
        if (trans != null) {
            return trans.Find(path).GetComponent<Text>();
        }
        else {
            return transform.Find(path).GetComponent<Text>();
        }
    }

    private T GetOrAddComponent<T>(GameObject go) where T : Component {
        T t = go.GetComponent<T>();
        if (t == null) {
            t = go.AddComponent<T>();
        }
        return t;
    }
    #endregion

    #region ///=== Click Events     ===///
    protected void OnClick(GameObject go, Action<GameObject> callback, object args = null) {
        PEListener listener = go.GetComponent<PEListener>();
        if (listener == null)
            listener = go.AddComponent<PEListener>();
        listener.onClick = callback;
        if (args != null) {
            listener.args = args;
        }
    }

    protected void OnClickDown(GameObject go, Action<PointerEventData> evt) {
        PEListener listener = GetOrAddComponent<PEListener>(go);
        listener.onClickDown = evt;
    }

    protected void OnClickUp(GameObject go, Action<PointerEventData> evt) {
        PEListener listener = GetOrAddComponent<PEListener>(go);
        listener.onClickUp = evt;
    }

    protected void OnDrag(GameObject go, Action<PointerEventData> evt) {
        PEListener listener = GetOrAddComponent<PEListener>(go);
        listener.onDrag = evt;
    }
    #endregion

    protected void PlayBGMusic(string bgName, bool isLoop = true) {
        audioSvc.PlayBGMusic(bgName, isLoop);
    }
    protected void PlayUIAudio(string uiAudio = Constants.UIClickBtn) {
        audioSvc.PlayUIAudio(uiAudio);
    }
}