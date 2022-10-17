using UnityEngine;
using UnityEngine.UI;


namespace TogglePanelManip
{
    public class ToggleGridPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject Canvas;

        private bool _isOn;

        [SerializeField]
        private Sprite _imageShow, _imageHide;

        [SerializeField]
        private Button _hideShowBtn;

        void Start()
        {
            _isOn = true;
        }

        public void ButtonToggle()
        {
            if (_isOn)
            {
                _isOn = !_isOn;
                ChangeImageFunction(_isOn, _imageShow);
            }
            else
            {
                _isOn = !_isOn;
                ChangeImageFunction(_isOn, _imageHide);
            }
        }

        private void ChangeImageFunction(bool on, Sprite sprite)
        {
            _hideShowBtn.GetComponent<Image>().sprite = sprite;
            Canvas.SetActive(on);
        }
    }
}
