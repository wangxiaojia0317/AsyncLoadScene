using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loaidng : MonoBehaviour
{
    public Text progress;
    //进度条的数值
    public float progressValue;
    //进度条
    public Slider slider;
    
    public string nextSceneName;
 
    private AsyncOperation async = null;
 
    private void Start() {
       
        StartCoroutine("LoadScene");
    }
 
    IEnumerator LoadScene() {
        async = SceneManager.LoadSceneAsync(nextSceneName);
        async.allowSceneActivation = false;
        while (!async.isDone) {
            if (async.progress < 0.9f)
                progressValue = async.progress;
            else
                progressValue = 1.0f;
 
            slider.value = progressValue;
            progress.text = (int)(slider.value * 100) + " %";
 
            if (progressValue >= 0.9) {
                    async.allowSceneActivation = true;
               
            }
 
            yield return null;
        }
 
    }

}
