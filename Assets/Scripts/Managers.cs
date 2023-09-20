using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;             //매니저는 싱글톤으로 관리
    public static Managers Instance { get { return s_instance; } }

    private static bool isInitialized = false;
    public void Awake()                     //인스턴스를 찾아서 manager 전달
    {
        Init();
    }
    public static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go); 
            s_instance = go.GetComponent<Managers>();           //인스턴스를 찾아서 manager 전달
            isInitialized = true; // 초기화 완료
        }
    }
    public bool IsInitialized()
    {
        return isInitialized;
    }

    SGProjectileManager _projectileManager = new SGProjectileManager();     //manager 하위에 projectiManager
    SGShotManager _shotManager = new SGShotManager();                       //manager 하위에 shotManager
    
    public static SGShotManager ShotManager { get { return Instance?._shotManager; } }
    public static SGProjectileManager projectileManager { get { return Instance?._projectileManager; } }
   

}