#if ! UNITY_ANDROID
using Debug = UnityEngine.Debug;

namespace Assets.Plugins.YozioUnity.YozioAdapters
{
    public class YozioDummy : IYozioAdapter
    {
        public void Initialize(string appKey, string secretKey)
        {
            Debug.Log("yozio init with appKey:"+appKey+" and secretKey:"+secretKey);
        }

        public void TrackSignUp()
        {
            Debug.Log("yozio try sign up"); 
        }

        public void TrackCustomEvent(string eventName, double eventValue)
        {
            Debug.Log("yozio custom event eventName:"+eventName+" eventValue:"+eventValue);
        }

        public void TrackPayment(double payValue)
        {
            Debug.Log("yozio payment payValue:"+payValue);
        }
    }
}
#endif