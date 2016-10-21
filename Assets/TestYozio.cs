using Assets.Plugins.YozioUnity;
using UnityEngine;


namespace Assets
{
    public class TestYozio : MonoBehaviour
    {
        public void Init()
        {
            YozioUnity.Initialize(); 
            YozioUnity.TrackSignUp();  
        }
        public void TrackEvent()
        {
            YozioUnity.TrackCustomEvent("event",0.1231);
        }

        public void TrackPay()
        {
            YozioUnity.TrackPayment(120.995);
        }
    }
}
