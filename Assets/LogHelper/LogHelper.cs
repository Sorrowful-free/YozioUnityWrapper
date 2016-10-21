using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Helpers.LogHelper
{
    public class LogHelper : MonoBehaviour
    {
        private bool _isEnable;
        private Vector2 _scrollPosition;
        private List<LogEntry> _logEntries;
        private float _scaleFactor;
        float deltaTime = 0.0f;
        private void Awake()
        {
            _logEntries = new List<LogEntry>();
            Application.logMessageReceivedThreaded += OnApplicationLog;
            _scaleFactor = (Screen.dpi/90);
           
            
        }

        private void OnApplicationLog(string condition, string stackTrace, LogType type)
        {
            _logEntries.Add(new LogEntry{LogMessage =  condition, LogStackTrace = stackTrace,LogType = type});
        }

        private void OnDestroy()
        {
            Application.logMessageReceivedThreaded -= OnApplicationLog;
        }

        

        void Update()
        {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        }

        private void OnGUI()
        {
            if (_isEnable && _logEntries.Count >0)
            {
                GUI.backgroundColor = Color.black;
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height),"");
                GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));
                _scrollPosition = GUILayout.BeginScrollView(_scrollPosition,false,true);
                GUILayout.Space(25);
                var enumerator = _logEntries.GetEnumerator();
                var logEntry = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    logEntry = enumerator.Current;
                    logEntry.Draw();
                }
                GUILayout.EndScrollView();
                GUILayout.EndArea();
            }
            GUI.color = Color.white;
            float msec = deltaTime * 1000.0f;
		    float fps = 1.0f / deltaTime;
		    string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
            GUI.skin.button.fontSize = GUI.skin.toggle.fontSize = GUI.skin.label.fontSize = (int)(_scaleFactor * 16);
            _isEnable = GUI.Toggle(new Rect(Screen.width - 180 * _scaleFactor,0, 180 * _scaleFactor, 50 * _scaleFactor), _isEnable, "Log(" + text + ")");
            if (_logEntries.Count > 0 && _isEnable)
            {
                if (GUI.Button(new Rect(180 * _scaleFactor, 0, 150 * _scaleFactor, 25 * _scaleFactor), "ClearLog"))
                {
                    _logEntries.Clear();
                }
            }
            
        }
    }
}
