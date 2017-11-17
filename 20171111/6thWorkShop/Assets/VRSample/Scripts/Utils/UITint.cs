using UnityEngine;
using UnityEngine.UI;

namespace VRStandardAssets.Utils
{
    //VRInteractiveItemがBar上に視線が乗っかったのを検知したら
    //Barの色を変える単純なスクリプトになります。
    public class UITint : MonoBehaviour
    {
        [SerializeField] private Color m_Tint;                                  
        [Range (0f, 1f)] [SerializeField] private float m_TintPercent = 0.5f;   
        [SerializeField] private Image[] m_ImagesToTint;                        
        [SerializeField] private VRInteractiveItem m_InteractiveItem;          


        private void OnEnable ()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
        }


        private void OnDisable ()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
        }


        private void HandleOver ()
        {
            for (int i = 0; i < m_ImagesToTint.Length; i++)
            {
                m_ImagesToTint[i].color += m_Tint * m_TintPercent;
            }
        }


        private void HandleOut ()
        {
            for (int i = 0; i < m_ImagesToTint.Length; i++)
            {
                m_ImagesToTint[i].color -= m_Tint * m_TintPercent;
            }
        }
    }
}