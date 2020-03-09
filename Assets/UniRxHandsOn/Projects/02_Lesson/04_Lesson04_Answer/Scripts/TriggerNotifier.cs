using System;
using UniRx;
using UnityEngine;

namespace UniRxHandsOn.Lesson_04_Answer {
	public class TriggerNotifier : MonoBehaviour {
		private Subject<Unit> m_OnEnter = new Subject<Unit> ();
		public IObservable<Unit> OnEnter { get { return m_OnEnter; } }

		private Subject<Unit> m_OnExit = new Subject<Unit> ();
		public IObservable<Unit> OnExit { get { return m_OnExit; } }

		private void OnTriggerEnter (Collider other) {
			if (other.tag != "Player") return;

			m_OnEnter.OnNext (Unit.Default);
		}

		private void OnTriggerExit (Collider other) {
			if (other.tag != "Player") return;

			m_OnExit.OnNext (Unit.Default);
		}
	}
}