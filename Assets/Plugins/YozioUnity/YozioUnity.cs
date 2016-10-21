using Assets.Plugins.YozioUnity.YozioAdapters;

namespace Assets.Plugins.YozioUnity
{
    public static class YozioUnity
    {
        private static IYozioAdapter _yozioAdapter;
        
        public static void Initialize(
#if !UNITY_ANDROID
            string appKey, string secretKey
#endif
            )
        {
#if UNITY_ANDROID
            _yozioAdapter = new YozioAndroid();
#elif UNITY_IPHONE || UNITY_IOS
            _yozioAdapter = new YozioIOS();
#else
            _yozioAdapter = new YozioDummy();
#endif
#if UNITY_ANDROID
            _yozioAdapter.Initialize();
#else
            _yozioAdapter.Initialize(appKey,secretKey);
#endif
        }

        public static void TrackSignUp()
        {
            _yozioAdapter.TrackSignUp();
        }

        public static void TrackCustomEvent(string eventName, double eventValue)
        {
            _yozioAdapter.TrackCustomEvent(eventName,eventValue);
        }

        public static void TrackPayment(double payValue)
        {
            _yozioAdapter.TrackPayment(payValue);
        }
    }
}
