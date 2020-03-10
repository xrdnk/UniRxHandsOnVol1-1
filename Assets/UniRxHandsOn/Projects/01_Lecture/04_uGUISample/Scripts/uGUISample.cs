using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace UniRxHandsOn.uGUIControl
{
    [RequireComponent(typeof(Button))]
    public class uGUISample : MonoBehaviour
    {
        private Button m_Button = null;

        private void Start()
        {
            m_Button = GetComponent<Button>();

            m_Button.onClick.AsObservable()
                .Subscribe((_) => Debug.Log("OnClick detected"));
        }
    }
}
