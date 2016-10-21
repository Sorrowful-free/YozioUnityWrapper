public interface IYozioAdapter
{
#if UNITY_ANDROID
    void Initialize();
#else
    void Initialize(string appKey, string secretKey);
#endif
    void TrackSignUp();
    void TrackCustomEvent(string eventName, double eventValue);
    void TrackPayment(double payValue);
}
