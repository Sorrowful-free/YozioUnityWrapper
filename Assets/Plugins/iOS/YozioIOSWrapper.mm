//
//  YozioIOSWrapper.m
//  YozioIOSWrapper
//
//  Created by admin on 11.04.16.
//  Copyright © 2016 admin. All rights reserved.
//

#import "Yozio.h"

extern "C"
{
    NSString * ParseiOSString(const char * cString)
    {
        return [[NSString alloc] initWithUTF8String:cString];
    }
    
    void Initialize(const char * appKey, const char * secretKey)
    {
        [Yozio initializeWithAppKey:ParseiOSString(appKey) secretKey:ParseiOSString(secretKey) newInstallMetaDataCallback:^(NSDictionary *metaData){}];
    }
    
    void TrackSignUp()
    {
        [Yozio trackSignup];
    }
    
    void TrackCustomEvent(const char * eventName, double eventValue)
    {
        [Yozio trackCustomEventWithName:ParseiOSString(eventName) andValue:eventValue];
    }
    
    void TrackPayment(double payValue)
    {
        [Yozio trackPayment:payValue];
    }
}
