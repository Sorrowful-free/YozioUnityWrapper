#if UNITY_IPHONE || UNITY_IOS
using System.Runtime.InteropServices;
#endif

namespace Assets.Plugins.YozioUnity.YozioAdapters
{
#if UNITY_IPHONE || UNITY_IOS
    public class YozioIOS : IYozioAdapter
    {
        
        public void Initialize(string appKey, string secretKey)
        {
            YozioStaticIOS.Initialize(appKey,secretKey);
        }
        

        public void TrackSignUp()
        {
            YozioStaticIOS.TrackSignUp();
        }

        public void TrackCustomEvent(string eventName, double eventValue)
        {
            YozioStaticIOS.TrackCustomEvent(eventName,eventValue);
        }

        public void TrackPayment(double payValue)
        {
            YozioStaticIOS.TrackPayment(payValue);
        }
    }

    class YozioStaticIOS
    {
         [DllImport("__Internal")]
         public static extern void Initialize(string appKey, string secretKey);

         [DllImport("__Internal")]
         public static extern void TrackSignUp();

         [DllImport("__Internal")]
         public static extern void TrackCustomEvent(string eventName, double eventValue);

         [DllImport("__Internal")]
         public static extern void TrackPayment(double payValue);
    }
#endif
}
