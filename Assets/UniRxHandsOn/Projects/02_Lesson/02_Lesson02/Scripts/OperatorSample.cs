using UnityEngine;
using UniRx;

namespace UniRxHandsOn.Lesson_02
{
    public class OperatorSample : MonoBehaviour
    {
        [SerializeField] private ReactivePropertySample m_ReactiveProperty = null;

        private void Awake()
        {
            // TODO : 偶数のみ抽出し、抽出した数の二乗をログ出力する
            // m_ReactiveProperty.OnValueChanged
            //     .Where(x => x != 0 && x % 2 == 0)
            //     .Subscribe((x) => Debug.Log(x * x))
            //     .AddTo(this);

            m_ReactiveProperty.OnValueChanged
                .SkipLatestValueOnSubscribe()
                .Where(x => x % 2 == 0)
                .Select(x => x * x)
                .Subscribe(x => Debug.Log(x))
                .AddTo(this);
        }
    }
}
