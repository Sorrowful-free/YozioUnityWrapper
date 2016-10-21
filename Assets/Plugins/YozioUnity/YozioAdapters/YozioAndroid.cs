#if UNITY_ANDROID
using UnityEngine;
#endif
namespace Assets.Plugins.YozioUnity.YozioAdapters
{
#if UNITY_ANDROID
    public class YozioAndroid: IYozioAdapter
    {

        private AndroidJavaObject _currentActivity;
        private AndroidJavaObject CurrentActivity
        {
            get
            {
                if (_currentActivity == null)
                {
                    AndroidJavaClass javaClassUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                    _currentActivity = javaClassUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                }
                return _currentActivity;
            }

        }

        private AndroidJavaClass _yozioAndroidWrapper;

        private AndroidJavaClass YozioAndroidWrapper
        {
            get
            {
                if (_yozioAndroidWrapper == null)
                {
                    _yozioAndroidWrapper = new AndroidJavaClass("com.milkygames.yozioandroidwrapper.YozioAndroidWrapper");
                }
                return _yozioAndroidWrapper;
            }
        }

        public void Initialize()
        {
            YozioAndroidWrapper.CallStatic("Initialize", CurrentActivity);
        }

        public void TrackSignUp()
        {
            YozioAndroidWrapper.CallStatic("TrackSignUp", CurrentActivity);
        }

        public void TrackCustomEvent(string eventName, double eventValue)
        {
            YozioAndroidWrapper.CallStatic("TrackCustomEvent", CurrentActivity, eventName,eventValue);
        }

        public void TrackPayment(double payValue)
        {
            YozioAndroidWrapper.CallStatic("TrackPayment", CurrentActivity, payValue);
        }
    }
#endif
}
