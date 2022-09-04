using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Performance{
    public class PerformanceManager : MonoBehaviour
    {   
        [Header("FPS")]
        [SerializeField] int maxFps = 60;
        [SerializeField] Text fpsText;
        float deltaTime;

        [Header("GC")]
        [SerializeField] Text gcText;

        [Header("Variables")]
        public bool isWorking = true;
        public float tickTimer = .125f;
        float tick = 0;
        void Update () {
            if(!isWorking)return;
            CheckFps();
            TickTimer();
        }
        void TickTimer(){
            tick += Time.deltaTime;
            while(tick >= tickTimer){
                tick -= tickTimer;
                CheckGC();
            }
        }
        void CheckFps(){
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;
            var f = Mathf.Clamp(fps, 0, maxFps);
            fpsText.text = $"FPS - {Mathf.Ceil (f).ToString ()}";
        }
        void CheckGC(){
            gcText.text = $"GC - {string.Format("{0:0.##}", System.GC.GetTotalMemory(false)/1024)}";
        }
    }
}
