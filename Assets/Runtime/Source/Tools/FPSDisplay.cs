using Pixeye.Actors;
using UnityEngine;

namespace Runtime.Source.Tools
{
    public class FPSDisplay : MonoCached
    {
        [SerializeField]
        TextAnchor textAnchor = TextAnchor.UpperRight;
        [SerializeField]
        private Color color = Color.green;
        private float deltaTime;
        [SerializeField, Range(1, 100)]
        private int fontSize = 2;
        [SerializeField]
        private float offsetX = 0;
        [SerializeField]
        private float offsetY = 0;

        void OnGUI()
        {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(offsetX * w, offsetY * h, w, h * fontSize / 100f);
            style.alignment = textAnchor;
            style.fontSize = h * fontSize / 100;
            style.normal.textColor = color;
            float msec = deltaTime * 1000.0f;
            float fps = 1.0f / deltaTime;
            string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
            GUI.Label(rect, text, style);
        }

        public void Update()
        {
            deltaTime += (Time.deltaTimeUnscaled - deltaTime) * 0.1f;
        }
    }
}
