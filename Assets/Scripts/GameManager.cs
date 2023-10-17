
using Manager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

   [SerializeField] private SceneLoader sceneLoader;

   public SceneLoader SceneLoader => Instance.sceneLoader;
   
   private void Awake()
   {
      if (Instance is null) Instance = this;
      else Destroy(gameObject);
      
      DontDestroyOnLoad(gameObject);
   }
}