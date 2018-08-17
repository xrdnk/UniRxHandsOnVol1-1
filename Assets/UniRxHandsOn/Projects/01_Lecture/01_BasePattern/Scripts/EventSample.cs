using System;
using UnityEngine;

namespace UniRxHandsOn.Base
{
	public class EventSample : MonoBehaviour
	{
		private Action<int> m_Action;

		private void Start()
		{
			m_Action += ( x ) => Debug.Log( x );

			m_Action( 1 );
			m_Action( 2 );
			m_Action( 3 );
		}
	}
}


