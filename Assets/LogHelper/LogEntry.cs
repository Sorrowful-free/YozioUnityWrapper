using UnityEngine;

namespace Assets.Scripts.Helpers.LogHelper
{
    public class LogEntry
    {
        private bool _expand;
        public string LogMessage;
        public string LogStackTrace;
        public LogType LogType;

        public void Draw()
        {
            
            switch (LogType)
            {
                case LogType.Log:
                    GUI.color = Color.white;
                    break;
                case LogType.Assert:
                    GUI.color = Color.green;
                    break;
                case LogType.Warning:
                    GUI.color = Color.blue;
                    break;
                default:
                    GUI.color = Color.red;
                    break;
                    
            }
            GUILayout.BeginHorizontal();
            GUILayout.Label(LogMessage);
            _expand = GUILayout.Toggle(_expand, "+");
            GUILayout.EndHorizontal();
            if (_expand)
            {
                GUILayout.Label(LogStackTrace);
            }

        }
    }

}
