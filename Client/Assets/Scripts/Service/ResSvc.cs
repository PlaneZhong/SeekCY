/****************************************************
    文件：ResSys.cs
    作者：Plane
    QQ ：1785275942
    日期：2018/09/23 08:33
    功能：资源服务
*****************************************************/

using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Xml;

public class ResSvc : MonoBehaviour {
    public static ResSvc Instance = null;

    public void InitSvc() {
        Instance = this;
    }


    #region ///=== Data Area        ===///
    private List<string> loadTipsLst = new List<string>();

    private Dictionary<string, GameObject> goDic = new Dictionary<string, GameObject>();
    private Dictionary<string, Sprite> spDic = new Dictionary<string, Sprite>();
    private Dictionary<string, AudioClip> adDic = new Dictionary<string, AudioClip>();

    #endregion

    #region ///=== Main Functions ===///
    private Action prgCB;
    public void AsyncLoadScene(string sceneName, Action loaded = null, bool prg = true) {
        if (prg) {
            //GameRoot.Instance.loadingWnd.SetWndState(true);
        }
        AsyncOperation sceneAsync = SceneManager.LoadSceneAsync(sceneName);
        prgCB = () => {
            float val = sceneAsync.progress;
            if (prg) {
                //GameRoot.Instance.loadingWnd.ShowProgress(val);
                if (val == 1f) {
                    if (loaded != null) {
                        loaded();
                    }
                    prgCB = null;
                    sceneAsync = null;
                    //GameRoot.Instance.loadingWnd.SetWndState(false);
                }
            }
            else {
                prgCB = null;
                sceneAsync = null;
            }
        };
    }

    private void Update() {
        if (prgCB != null) {
            prgCB();
        }
    }

    /// <summary>
    /// 加载路径对应的Prefab，并返回其实例
    /// </summary>
    public GameObject LoadPrefab(string path, bool cache = false) {
        GameObject prefab = null;
        if (!goDic.TryGetValue(path, out prefab)) {
            prefab = Resources.Load<GameObject>(path);
            if (cache) {
                goDic.Add(path, prefab);
            }
        }

        GameObject go = null;
        if (prefab != null) {
            go = Instantiate(prefab);
        }
        return go;
    }

    /// <summary>
    /// 加载路径对应的Sprite
    /// </summary>
    public Sprite LoadSprite(string path, bool cache = false) {
        Sprite sp = null;
        if (!spDic.TryGetValue(path, out sp)) {
            sp = Resources.Load<Sprite>(path);
            if (cache) {
                spDic.Add(path, sp);
            }
        }
        return sp;
    }

    /// <summary>
    /// 加载路径对应的音频文件
    /// </summary>
    public AudioClip LoadAudio(string path, bool cache = false) {
        AudioClip au = null;
        if (!adDic.TryGetValue(path, out au)) {
            au = Resources.Load<AudioClip>(path);
            if (cache) {
                adDic.Add(path, au);
            }
        }
        return au;
    }
    #endregion
}