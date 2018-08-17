using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace UniRxHandsOn.Lesson_03
{
	public class UIPresenter : MonoBehaviour
	{
		[SerializeField] private Button m_StartTimer = null;
		[SerializeField] private Button m_StopTimer = null;

		[SerializeField] private Slider m_Slider = null;
		[SerializeField] private Text m_SliderText = null;

		[SerializeField] private Dropdown m_DropDown = null;
		[SerializeField] private Image m_Image = null;

		private Timer m_Timer = new Timer();

		private void Start()
		{
			// TODO: Timerスタート( m_Timer.StartTimer()を使用すること )
			// TIPS: Button押下イベントはm_StartTimer.onClickで取得可能


			// TODO: Timerストップ( m_Timer.StopTimer()を使用すること )
			// TIPS: Button押下イベントはm_StopTimer.onClickで取得可能


			// TODO: m_Sliderの値をm_SliderTextに表示する
			// TIPS: Sliderの値変化イベントはm_Slider.onValueChangedで取得可能


			// TODO: m_DropDownの文字列によって、m_ImageのColorを変更する( Convert2Color()を使用すること )
			// TIPS: m_DropDownの文字列取得方法 → m_DropDown.options[index].text
			// TIPS: m_ImageのColor変更方法 → m_Image.color = Convert2Color( m_DropDown.options[index].text )


		}

		private Color Convert2Color( string color )
		{
			switch( color )
			{
				case "Red":
					return Color.red;
				case "Green":
					return Color.green;
				case "Blue":
					return Color.blue;
				default:
					return Color.white;
			}
		}
	}
}
