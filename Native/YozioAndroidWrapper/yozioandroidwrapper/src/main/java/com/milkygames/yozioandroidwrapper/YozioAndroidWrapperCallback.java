package com.milkygames.yozioandroidwrapper;

import android.content.Context;
import android.util.Log;

import com.yozio.android.interfaces.YozioMetaDataCallbackable;

import java.util.HashMap;

/**
 * Created by user on 11.04.2016.
 */
public class YozioAndroidWrapperCallback implements YozioMetaDataCallbackable {
    @Override
    public void onCallback(Context context, String s, HashMap<String, Object> hashMap) {
        Log.i("yozio",s);
    }
}
