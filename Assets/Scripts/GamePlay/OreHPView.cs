using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace.GamePlay.Ore
{
    public class OreHPView:MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _timeText;
        [SerializeField] private GameObject _canvas;
        [SerializeField] private Ore _ore;

        private void Start()
        {
            _ore.Break += OnBreak;
            _levelText.text = _ore.GetLevel().ToString();

        }

        private void Update()
        {
            _image.fillAmount = _ore.GetHpInPercent();
            if (_ore.HasMiners())
            {
                UpdateTimeText(_ore.CalculateTimeToBreak());
            }
            else
            {
                _timeText.text = " ";
            }
        }

        void UpdateTimeText(float time)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds((int)time);
            string timeText = "";
            if (timeSpan.Hours > 0)
            {
                timeText = ">1h";
            }
            if (timeSpan.Minutes > 0)
            {
                timeText = timeSpan.Minutes.ToString() + "m";
            }
            if (timeSpan.Seconds > 0)
            {
                timeText = timeSpan.Seconds.ToString() + " s";
            }
            _timeText.text = timeText;
            
        }

        private void OnBreak()
        {
            Destroy(_canvas);
        }
    }
}