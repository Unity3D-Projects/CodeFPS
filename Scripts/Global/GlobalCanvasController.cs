﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalCanvasController : MonoBehaviour
{
    public static GlobalCanvasController Instance { get; private set; }
    
    private const string Display = "FPS:{0}";   //显示的文字
    private const float FpsMeasurePeriod = 0.5f;    //FPS测量间隔
    private int fpsAccumulator = 0;   //帧数累计的数量
    private float fpsNextPeriod = 0;  //FPS下一段的间隔
    private int currentFps;   //当前的帧率

    [Header("FPS Limit")]
    // The FPS limit of this game
    public int fps = 60;

    [Header("Stats UI Text")]
    //Stats info text area
    public Text statsText;
    
    void Awake()
    {
        Instance = this;
        Application.targetFrameRate = fps;
        fpsNextPeriod = Time.realtimeSinceStartup + FpsMeasurePeriod;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Start");
    }
    
    void Update()
    {
        fpsAccumulator++;
        if (Time.realtimeSinceStartup>fpsNextPeriod)
        {
            currentFps = (int)(fpsAccumulator / FpsMeasurePeriod);   //计算
            fpsAccumulator = 0;   //计数器归零
            fpsNextPeriod += FpsMeasurePeriod;    //在增加下一次的间隔
            statsText.text = string.Format(Display, currentFps); //处理一下文字显示
        }
    }

    public void SetApplicationFrameRate(int frameRate)
    {
        Application.targetFrameRate = frameRate;
    }
}
