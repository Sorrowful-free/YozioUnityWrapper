package com.milkygames.yozioandroidwrapper;

import android.app.Activity;
import android.content.Context;
import android.content.IntentFilter;
import android.os.Bundle;


import com.yozio.android.Yozio;
import com.yozio.android.YozioReferrerReceiver;

public class YozioAndroidWrapper {

    public static void Initialize(Activity unity3dActivity,String appKey,String secretKey)
    {
        Context currentContext = unity3dActivity.getApplicationContext();
        currentContext.registerReceiver(new YozioReferrerReceiver(),new IntentFilter("com.android.vending.INSTALL_REFERRER"));
        Bundle metaDatas = currentContext.getApplicationInfo().metaData;
        metaDatas.putString("YozioAppKey",appKey);
        metaDatas.putString("YozioSecretKey",secretKey);
        metaDatas.putString("YozioNewInstallMetaDataCallback","com.milkygames.yozioandroidwrapper.YozioAndroidWrapperCallback");
        currentContext.getApplicationInfo().metaData = metaDatas;
        Yozio.initialize(currentContext);
    }

    public static void TrackSignUp(Activity unity3dActivity)
    {
        Yozio.trackSignUp(unity3dActivity.getApplicationContext());
    }

    public static void TrackCustomEvent(Activity unity3dActivity,String eventName,double eventValue)
    {
        Yozio.trackCustomEvent(unity3dActivity.getApplicationContext(),eventName,eventValue);
    }

    public static void TrackPayment(Activity unity3dActivity,double payValue)
    {
        Yozio.trackPayment(unity3dActivity.getApplicationContext(),payValue);
    }

}
