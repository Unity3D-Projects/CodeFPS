﻿using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public abstract class GuideManagerBase : MonoBehaviour
{
    protected abstract string StagePrefix { get; }
    protected abstract List<string> ChatTexts { get; }
    protected abstract List<string> GuideTips { get; }

    protected virtual int CurrentStage { get; set; } = 0;
    protected virtual int FinalStage { get; } = 20;//为什么不用长度：有可能跳过中间步骤，实际number有可能大于长度
    private int runningStage = -1;

    [Header("StageObject")]
    //StageObject
    public GameObject stageObject;

    private readonly Dictionary<string, GuideStageBase> guideStageBases
        = new Dictionary<string, GuideStageBase>();

    [Header("GuideTips")]
    //Guide Tips
    public GameObject guideTips;

    private Text guideText;

    /**
     * Start初始化
     */
    protected virtual void StartInit()
    {
    }

    /**
     * 流程结束
     */
    protected virtual void GuideOver()
    {
    }

    // Start is called before the first frame update
    private void Start()
    {
        guideTips.GetComponent<CanvasGroup>().DOFade(0, 0);
        guideText = guideTips.transform.Find("GuideText").GetComponent<Text>();
        SetGuideStageScript();
        StartInit();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckStage();
    }

    /**
     * 检测流程阶段
     */
    private void CheckStage()
    {
        if (CurrentStage <= FinalStage && CurrentStage != runningStage)
        {
            runningStage = CurrentStage;
            //阶段参考《流程规划-训练场流程规划》
            GuideStageBase tsb;
            guideStageBases.TryGetValue(StagePrefix + CurrentStage, out tsb);
            if (tsb != null)
            {
                Debug.Log("Run " + StagePrefix + CurrentStage);
                tsb.Run();
            }
            else
            {
                Debug.Log(StagePrefix + CurrentStage + " script can't found.");
                CurrentStage++;
            }

            if (CurrentStage > FinalStage)
            {
                GuideOver();
            }
        }
    }

    /**
     * 调用此方法进入下一阶段
     */
    protected void NextStage()
    {
        CurrentStage++;
        HideGuideTips();
    }

    /**
     * 阶段脚本调用
     */
    protected void ShowGuideTips(int index)
    {
        guideText.text = GuideTips[index];
        guideTips.GetComponent<CanvasGroup>().DOFade(1, 1);
    }

    protected void HideGuideTips()
    {
        guideTips.GetComponent<CanvasGroup>().DOFade(0, 1);
    }

    /**
     * Stage call this function.
     */
    protected void PublishChatText(int index)
    {
        ChatPanelController.Instance.PublishText(ChatTexts[index]);
    }

    /**
     * 获取所有阶段脚本
     */
    private void SetGuideStageScript()
    {
        GuideStageBase[] tsb = stageObject.GetComponents<GuideStageBase>();
        if (tsb != null)
        {
            foreach (GuideStageBase trainingStageBase in tsb)
            {
                guideStageBases.Add(trainingStageBase.GetType().Name, trainingStageBase);
            }
        }
    }
}