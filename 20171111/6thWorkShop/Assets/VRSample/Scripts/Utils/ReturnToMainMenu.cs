using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace VRStandardAssets.Utils
{
    
    public class ReturnToMainMenu : MonoBehaviour
    {
        [SerializeField] private string m_MenuSceneName = "MainMenu";   
        [SerializeField] private VRInput m_VRInput;                     
        [SerializeField] private VRCameraFade m_VRCameraFade;


        private void OnEnable ()
        {
            m_VRInput.OnCancel += HandleCancel;
        }


        private void OnDisable ()
        {
            m_VRInput.OnCancel -= HandleCancel;
        }


        private void HandleCancel ()
        {
            StartCoroutine (FadeToMenu ());
        }


        public IEnumerator FadeToMenu ()
        {
            yield return StartCoroutine (m_VRCameraFade.BeginFadeOut (true));

            SceneManager.LoadScene(m_MenuSceneName, LoadSceneMode.Single);
        }
    }
}