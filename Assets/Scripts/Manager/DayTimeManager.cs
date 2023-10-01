using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayTimeManager : MonoBehaviour
{
   const float secondsInDay = 86400f;

   [SerializeField] Color nightLightColor;
   [SerializeField] AnimationCurve nightTimeCurve;
   [SerializeField] Color dayLightColor = Color.white;

   float time;
   int day;

   [SerializeField] float timeScale = 6000f;
   [SerializeField] Text text;
   [SerializeField] UnityEngine.Rendering.Universal.Light2D globalLight;

    float Hours
    {
        get{return time / 3600f;}
    }
    float Minutes
    {
        get{return time % 3600f / 60;}
    }

   private void Update()
   {
        
        time += Time.deltaTime * timeScale;
        int hh = (int)Hours;
        int mm = (int)Minutes;
        text.text = hh.ToString("00") + ":" + mm.ToString("00");

        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;

        if(time > secondsInDay)
        {
            NextDay();
        }

   }

   private void NextDay()
   {
        time = 0;
        day += 1;
   }
}
