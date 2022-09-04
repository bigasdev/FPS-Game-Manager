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
        public bool isWorking = true;
        float deltaTime;
        void Update () {
            if(!isWorking)return;
            CheckFps();
        }
        void CheckFps(){
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;
            var f = Mathf.Clamp(fps, 0, maxFps);
            fpsText.text = $"FPS - {Mathf.Ceil (f).ToString ()}";
        }
    }
}
