package com.glacier.Test;

import org.json.JSONObject;

import mail139.umcsdk.auth.AuthnHelper;
import mail139.umcsdk.auth.TokenListener;

import com.unity3d.player.*;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.widget.TextView;

/**
 * @deprecated Use UnityPlayerNativeActivity instead.
 */
public class UnityPlayerProxyActivity extends Activity
{
	
//	private static final int RESULT = 0x111;
//	private AuthnHelper mHelper;
//	private Context mContext;
//	public static String uid1;
//	public static String passid1;
//	String uuid1;
//	String artifact1;
//	String resultStr;
//	private String accountName, smsCode, pwd, loginType;
//	private TextView result;
//	
//	private TokenListener mListener;
	
	protected void onCreate (Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);

		Intent intent = new Intent(this, com.glacier.Test.UnityPlayerNativeActivity.class);
		intent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
		Bundle extras = getIntent().getExtras();
		if (extras != null)
			intent.putExtras(extras);
		startActivity(intent);
		
		
//		mContext = this;
//		mHelper = AuthnHelper.init(mContext);
//		init();
	}
	
//	private void init() {
//
//		mListener = new TokenListener() {
//
//			@Override
//			public void onGetTokenComplete(JSONObject jObj) {
//				resultStr = jObj.toString();
//				Log.e("收到sdk消息:", resultStr);
//				mHandler.sendEmptyMessage(RESULT);
//
//			}
//		};
//	}
//	
//	Handler mHandler = new Handler() {
//
//		@Override
//		public void handleMessage(Message msg) {
//			super.handleMessage(msg);
//			switch (msg.what) {
//			case RESULT:
//				result.setText(resultStr);
//				break;
//			default:
//				break;
//			}
//		}
//	};
//	
//	public void HelloWorld(String str1,String str2){
//		
//		Log.d("msg:", str1);
//		layout("123");
//	}
//	
//	public void layout(String str) {
////		loginType = AuthnHelper.LOGIN_TYPE_SMS;
////		doLoginByType();
//		mHelper.getAccessTokenOnDisplay(Constant.APP_ID, Constant.APP_KEY,mListener);
//	}
}
