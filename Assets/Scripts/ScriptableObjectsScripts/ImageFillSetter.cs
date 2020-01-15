using Kryz.CharacterStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.TestScript.Variables
{
    /// <summary>
    /// Sets an Image component's fill amount to represent how far Variable is
    /// between Min and Max.
    /// </summary>
    public class ImageFillSetter : MonoBehaviour
    {
        [Tooltip("Value to use as the current ")]
        public CharacterStat Variable;

        [Tooltip("Min value that Variable to have no fill on Image.")]
        public float Min;

        [Tooltip("Max value that Variable can be to fill Image.")]
        public CharacterStat Max;

        [Tooltip("Image to set the fill amount on.")]
        public Image Image;

        [Tooltip("Text To Display")]
        public TextMeshProUGUI TextToDisplay;


        private void Update()
        {
            Image.fillAmount = Mathf.Clamp01(
                Mathf.InverseLerp(Min, Max.Value, Variable.Value));
           TextToDisplay.text = Variable.Value.ToString();
        }
    }
}
