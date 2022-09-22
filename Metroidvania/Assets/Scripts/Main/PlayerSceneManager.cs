using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSceneManager : Manager
{
    public Player player;
    public Transform tempGroundTransform;
    public static float fadeAlpha = 1.0f;

    public static event Action OnCompleteFadeIn;
    public static event Action OnCompleteFadeOut;
    private static bool s_mb_fadingIn = false;
    private static bool s_mb_fadingOut = false;

    protected override void Start()
    {
        if(OnCompleteFadeIn == null)
            OnCompleteFadeIn += () => s_mb_fadingIn = false;
        if(OnCompleteFadeOut == null)
            OnCompleteFadeOut += () => s_mb_fadingOut = false;

        Action<AsyncOperation> onOpen = (AsyncOperation op) =>
        {
            PlayerSceneManager plscManager = ManagerHub.GetPlayerSceneManager();
            MapManager mManager = ManagerHub.GetMapManager();
            Player pl = plscManager.player;
            Transform it = mManager.initTransform;

            PlayerSceneManager.FadeOut();
            Vector3 pos = new Vector3(it.position.x, it.position.y, pl.transform.position.z);

            pl.transform.position = pos;
        };

        MapManager.Open(2, true, onOpen);
    }

    protected override void SetManager()
    {
        ManagerHub.SetPlayerSceneManager(this);
    }

    protected override void ResetManager()
    {
        ManagerHub.SetPlayerSceneManager(null);
    }

    public static void FadeIn()
    {
        if(s_mb_fadingIn)
            return;

        s_mb_fadingIn = true;

        Action<object> inAction = (object obj) =>
        {
            while(fadeAlpha < 1.0f)
            {
                fadeAlpha += 0.046f;
                Thread.Sleep(16);
            }

            fadeAlpha = 1.0f;
            OnCompleteFadeIn();
        };

        Task inTask = new Task(inAction, "in");
        inTask.Start();
    }

    public static void FadeOut()
    {
        if(s_mb_fadingOut)
            return;

        s_mb_fadingOut = true;

        Action<object> outAction = (object obj) =>
        {
            while(fadeAlpha > 0.0f)
            {
                fadeAlpha -= 0.046f;
                Thread.Sleep(16);
            }

            fadeAlpha = 0.0f;
            OnCompleteFadeOut();
        };

        Task outTask = new Task(outAction, "out");
        outTask.Start();
    }
}