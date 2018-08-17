using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace UniRxHandsOn.Lesson_03_Answer
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
			m_StartTimer.onClick.AsObservable()
				.Subscribe( _ => m_Timer.StartTimer() );

			m_StopTimer.onClick.AsObservable()
				.Subscribe( _ => m_Timer.StopTimer() );

			m_Slider.onValueChanged.AsObservable()
				.Subscribe( x => m_SliderText.text = x.ToString() );

			m_DropDown.onValueChanged.AsObservable()
				.Subscribe( index => m_Image.color = Convert2Color( m_DropDown.options[index].text ) );
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
