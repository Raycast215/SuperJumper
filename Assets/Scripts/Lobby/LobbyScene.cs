
using System.Collections;
using DG.Tweening;
using UnityEngine;
using static Common.EnumClass;

namespace Lobby
{
    public class LobbyScene : MonoBehaviour
    {
        private IEnumerator Start()
        {
            DOTween.KillAll();

            yield return new WaitForSeconds(3.0f);
            
            GameManager.Instance.SceneLoader.LoadScene(SceneName.Title);
        }
    }
}