using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace VRStandardAssets.Utils
{
    public class SelectionSlider : MonoBehaviour
    {
        public event Action OnBarFilled;
        // Barのゲージが満タンになったら呼ばれる処理


        [SerializeField] private float m_Duration = 2f;
        // Barが満タンになるまでの時間
        [SerializeField] private AudioSource m_Audio;
        [SerializeField] private AudioClip m_OnOverClip;
        // バーを見たときに再生される音
        [SerializeField] private AudioClip m_OnFilledClip;
        // バーが満タンになったときに再生する音
        [SerializeField] private Slider m_Slider;
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        // Barが満タンになったときに通知するためのクラス
        [SerializeField] private VRInput m_VRInput;
        // ボタンなどの入力を検知するためのクラス
        [SerializeField] private GameObject m_BarCanvas;
        [SerializeField] private UIFader m_UIFader;
        // Canvasグループの切り替えの際、画面がフェードアウトをするためのクラス
       

        private bool m_BarFilled;
        private bool m_GazeOver;
        private float m_Timer;
        private Coroutine m_FillBarRoutine;


        private const string k_SliderMaterialPropertyName = "_SliderValue";


        private void OnEnable ()
        {
            m_VRInput.OnDown += HandleDown;
            m_VRInput.OnUp += HandleUp;

            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
        }


        private void OnDisable ()
        {
            m_VRInput.OnDown -= HandleDown;
            m_VRInput.OnUp -= HandleUp;

            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
        }
        

        //IntroManager上で実行。UI遷移を管理
        public IEnumerator WaitForBarToFill ()
        {
            if (m_BarCanvas)
                m_BarCanvas.SetActive (true);

            // 初期化
            m_BarFilled = false;

            m_Timer = 0f;
            SetSliderValue (0f);

            // バーのゲージが満タンになるまでループさせる
            while (!m_BarFilled) {
                yield return null;
            }

            // ゲージが満タンになったら一度描画をオフにする
            //これをしないと次のBarの当たり判定が取得出来ない
            if (m_BarCanvas)
                m_BarCanvas.SetActive (false);
        }


        private IEnumerator FillBar ()
        {
            // タイマーのリセット
            m_Timer = 0f;

            float fillTime = m_Duration;

            // 満タンまでの設定した時間までループ処理
            while (m_Timer < fillTime) {
                // フレーム毎の時間を加算
                m_Timer += Time.deltaTime;

                // Barのゲージの値を入力
                SetSliderValue (m_Timer / fillTime);
                
                // 次のフレーム処理まで待つ.
                yield return null;

                // 次のフレーム時にまだ視線がBarと重なっていたらループを継続
                if (m_GazeOver)
                    continue;

                // 視線が途切れてしまったら下記内容を実行し値をリセット後、Break。
                m_Timer = 0f;
                SetSliderValue (0f);
                yield break;
            }

            // Barが満タンになったのでtrueをかえす
            m_BarFilled = true;

            // Barが満タンになったのでAction関数を実行
            if (OnBarFilled != null)
                OnBarFilled ();

            // 満タンになったことを知らせるサウンドを再生
            m_Audio.clip = m_OnFilledClip;
            m_Audio.Play ();


        }


        private void SetSliderValue (float sliderValue)
        {
            // If there is a slider component set it's value to the given slider value.
            if (m_Slider)
                m_Slider.value = sliderValue;

           
        }


        private void HandleDown ()
        {
            // If the user is looking at the bar start the FillBar coroutine and store a reference to it.
            if (m_GazeOver)
                m_FillBarRoutine = StartCoroutine (FillBar ());
        }


        private void HandleUp ()
        {
            // If the coroutine has been started (and thus we have a reference to it) stop it.
            if (m_FillBarRoutine != null)
                StopCoroutine (m_FillBarRoutine);

            // Reset the timer and bar values.
            m_Timer = 0f;
            SetSliderValue (0f);
        }


        //ユーザの視線がBarに重なっている間の処理
        private void HandleOver ()
        {
            m_GazeOver = true;

            m_Audio.clip = m_OnOverClip;
            m_Audio.Play ();
        }


        //視線がBarから外れてるときの処理
        private void HandleOut ()
        {
            m_GazeOver = false;

            if (m_FillBarRoutine != null)
                StopCoroutine (m_FillBarRoutine);

            m_Timer = 0f;
            SetSliderValue (0f);
        }
    }
}