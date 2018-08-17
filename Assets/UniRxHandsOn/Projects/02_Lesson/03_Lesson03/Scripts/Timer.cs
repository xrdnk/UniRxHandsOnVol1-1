using UnityEngine;
using UniRx;
using System;

namespace UniRxHandsOn.Lesson_03
{
	public class Timer
	{
		private IDisposable m_Timer = null;

		public void StartTimer()
		{
			if( m_Timer != null ) return;

			m_Timer = Observable.Interval( TimeSpan.FromSeconds( 1 ) )
				.Subscribe( ( _ ) => Debug.Log( Time.realtimeSinceStartup ) );
		}

		public void StopTimer()
		{
			if( m_Timer == null ) return;

			m_Timer.Dispose();
			m_Timer = null;
		}
	}
}
