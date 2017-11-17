using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;

namespace VRStandardAssets.Intro
{
	public class UIManager : MonoBehaviour
	{
		[SerializeField] private Reticle m_Reticle;            
		[SerializeField] private SelectionRadial m_Radial;                          
		[SerializeField] private SelectionSlider m_SelectionSlider;      
		[SerializeField] private VRCameraFade m_VRCameraFade;
		[SerializeField] private string sceneName;

		private IEnumerator Start ()
		{
			m_Reticle.Show ();
			m_Radial.Hide ();

			yield return StartCoroutine (m_SelectionSlider.WaitForBarToFill ());
			Debug.Log("Clear");
			yield return StartCoroutine (m_VRCameraFade.BeginFadeOut (true));
			if(sceneName != null)
				SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
		}
	}
}