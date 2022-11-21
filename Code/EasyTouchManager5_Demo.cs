using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;
/// <summary>
/// 五代EasyTouch特性 使用的是 单例 来 监听事件
/// </summary>
public class EasyTouchManager5_Demo : MonoBehaviour
{
    void Update()
    {
        Gesture currentGesture = EasyTouch.current;//获取当前手势
        //注意 当手机屏幕上没有任何操作的时候currentGesture是null的,要添加一个判断,防止空指针异常
        if (currentGesture == null) return;
        //以下是事件监听
        if (EasyTouch.EvtType.On_TouchStart == currentGesture.type)//按下
        {
            //OnTouchStart(currentGesture);

            //可以把方法写在里面
            print("OnTouchStart");
            print("StartPosition" + currentGesture.startPosition);//触摸位置
        }

        if (EasyTouch.EvtType.On_TouchUp == currentGesture.type)//抬起
        {
            OnTouchEnd(currentGesture);
        }

        if (EasyTouch.EvtType.On_Swipe == currentGesture.type)//滑动
        {
            OnSwipe(currentGesture);
        }
    }

    void OnTouchStart(Gesture gesture)
    {
        print("OnTouchStart");
        print("StartPosition" + gesture.startPosition);//触摸位置
    }
    void OnTouchEnd(Gesture gesture)
    {
        //print("OnTouchEnd");
        //print("OnTouchEnd" + gesture.actionTime);//触摸时间
    }

    void OnSwipe(Gesture gesture)
    {
        print("OnSwipe");
        print("Type" + gesture.type);//触摸类型
    }
}