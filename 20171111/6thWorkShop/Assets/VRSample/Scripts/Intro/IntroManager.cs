using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Intro
{
    // The intro scene takes users through the basics
    // of interacting through VR in the other scenes.
    // This manager controls the steps of the intro
    // scene.
    public class IntroManager : MonoBehaviour
    {
        [SerializeField] private Reticle m_Reticle;                         // The scene only uses SelectionSliders so the reticle should be shown.
        [SerializeField] private SelectionRadial m_Radial;                  // Likewise, since only SelectionSliders are used, the radial should be hidden.
        [SerializeField] private UIFader m_HowToUseFader;                   // This fader controls the UI showing how to use SelectionSliders.
        [SerializeField] private SelectionSlider m_HowToUseSlider;          // This is the slider that is used to demonstrate how to use them.
        [SerializeField] private UIFader m_HowToUseConfirmFader;            // Afterwards users are asked to confirm how to use sliders in this UI.
        [SerializeField] private SelectionSlider m_HowToUseConfirmSlider;   // They demonstrate this using this slider.
        [SerializeField] private UIFader m_ReturnFader;                     // The final instructions are controlled using this fader.
        [SerializeField] private ReturnToMainMenu m_mainMenu;                     // The final instructions are controlled using this fader.



        private IEnumerator Start ()
        {
            m_Reticle.Show ();
            
            m_Radial.Hide ();

          
            yield return StartCoroutine (m_HowToUseSlider.WaitForBarToFill ());

            yield return StartCoroutine(m_mainMenu.FadeToMenu());
        }
    }
}