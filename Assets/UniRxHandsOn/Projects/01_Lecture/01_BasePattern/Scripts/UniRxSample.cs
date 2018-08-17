using UnityEngine;
using UniRx;

namespace UniRxHandsOn.Base
{
	public class UniRxSample : MonoBehaviour
	{
		private Subject<int> m_Subject = new Subject<int>();

		private void Start()
		{
			m_Subject.Subscribe( x => Debug.Log( x ) );

			m_Subject.OnNext( 1 );
			m_Subject.OnNext( 2 );
			m_Subject.OnNext( 3 );
		}
	}
}



