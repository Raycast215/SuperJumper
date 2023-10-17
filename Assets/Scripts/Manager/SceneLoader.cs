
using System;
using System.Collections;
using Loading;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Common.EnumClass;

namespace Manager
{
    public class SceneLoader : MonoBehaviour
    {
        private Coroutine _sceneLoadRoutine;
        
        public void LoadScene<T>(SceneName sceneName, Action<T> onSceneLoaded = null)
        {
            
        }
        
        public void LoadScene(SceneName nextSceneName)
        {
           // DOTween.KillAll();
            
            Clear();
            _sceneLoadRoutine = StartCoroutine(OnLoadScene(nextSceneName));
        }

        private IEnumerator OnLoadScene(SceneName nextSceneName)
        {
            // Loading 씬 로드.
            SceneManager.LoadScene($"{SceneName.Loading}", LoadSceneMode.Additive);
     
            // Loading 씬 로드 까지 대기.
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name.Equals($"{SceneName.Loading}"));

            // FadeOut 재생.
            StartFade(true);
            
            // Loading 씬에게 제어권 넘김.
            SceneManager.SetActiveScene(SceneManager.GetSceneByName($"{SceneName.Loading}"));

            // 잠시 대기.
            yield return new WaitForSeconds(3.0f);
            
            StartFade(false);
            
            // 다음 씬 로드.
            SceneManager.LoadScene($"{nextSceneName}");
            
            // 다음 씬 로드 까지 대기.
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name.Equals($"{nextSceneName}"));
            
            // 다음 씬에게 제어권 넘김.
            SceneManager.SetActiveScene(SceneManager.GetSceneByName($"{nextSceneName}"));
        }

        private void StartFade(bool isFadeOut)
        {
            var sceneObject = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (var sObject in sceneObject)
            {
                var loading = sObject.GetComponent<LoadingScene>();

                if(loading is null) continue;
                
                loading.Fade(isFadeOut);
                
                break;
            }
        }

        private void Clear()
        {
            if(_sceneLoadRoutine is null) return;
            
            StopCoroutine(_sceneLoadRoutine);
            _sceneLoadRoutine = null;
        }
    }
}