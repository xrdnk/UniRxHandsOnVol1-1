using UnityEngine;
using UniRx;

namespace UniRxHandsOn.Lesson_04
{
	public class ColorChanger : MonoBehaviour
	{
		private TriggerNotifier m_Notifier = null;
		private Renderer m_Renderer = null;

		private void Awake()
		{
			m_Notifier = GetComponent<TriggerNotifier>();
			m_Renderer = GetComponent<Renderer>();
		}

		private void Start()
		{
			m_Notifier.OnEnter
				.Subscribe( _ => m_Renderer.material.color = Color.red );

			m_Notifier.OnExit
				.Subscribe( _ => m_Renderer.material.color = Color.blue );
		}
	}
}
