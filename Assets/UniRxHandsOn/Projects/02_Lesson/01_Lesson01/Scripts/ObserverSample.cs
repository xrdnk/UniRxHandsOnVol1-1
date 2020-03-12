using UnityEngine;
using UniRx;
using System;

namespace UniRxHandsOn.Lesson_01
{
    public class ObserverSample : MonoBehaviour
    {
        [SerializeField] private SubjectSample m_SubjectSample = null;

        private void Awake()
        {
            // TODO: Subjectの購読及び、振る舞い定義
            m_SubjectSample.OnValueChanged.Subscribe(x => Debug.Log(x));
        }
    }
}
