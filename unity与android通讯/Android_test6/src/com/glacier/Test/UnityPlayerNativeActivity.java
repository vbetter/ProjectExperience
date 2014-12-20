package com.glacier.Test;

import org.json.JSONObject;

import mail139.umcsdk.auth.AuthnHelper;
import mail139.umcsdk.auth.TokenListener;
import com.glacier.Test.R;


import com.unity3d.player.*;

import android.app.NativeActivity;
import android.content.Context;
import android.content.res.Configuration;
import android.graphics.PixelFormat;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.TextView;
import android.app.Activity;

public class UnityPlayerNativeActivity extends NativeActivity
{
	protected UnityPlayer mUnityPlayer;		// don't change the name of this variable; referenced from native code
//
	private static final int RESULT = 0x111;
	private AuthnHelper mHelper;
	private Context mContext;
	public static String uid1;
	public static String passid1;
	String uuid1;
	String artifact1;
	String resultStr;
	private String accountName, smsCode, pwd, loginType;
	private TextView result;
	
	private TokenListener mListener;
	
	// Setup activity layout
	@Override protected void onCreate (Bundle savedInstanceState)
	{
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		super.onCreate(savedInstanceState);

		getWindow().takeSurface(null);
		setTheme(android.R.style.Theme_NoTitleBar_Fullscreen);
		getWindow().setFormat(PixelFormat.RGB_565);

		mUnityPlayer = new UnityPlayer(this);
		if (mUnityPlayer.getSettings ().getBoolean ("hide_status_bar", true))
			getWindow ().setFlags (WindowManager.LayoutParams.FLAG_FULLSCREEN,
			                       WindowManager.LayoutParams.FLAG_FULLSCREEN);

		setContentView(mUnityPlayer);
		mUnityPlayer.requestFocus();
		
		//if(this.getParent()!=null){
		Log.d("init ","mhelper");
			mContext = (Activity)this;
			mHelper = AuthnHelper.init(mContext);
			init();
		//}
	}

	private void init() {

		mListener = new TokenListener() {

			@Override
			public void onGetTokenComplete(JSONObject jObj) {
				resultStr = jObj.toString();
				Log.e("收到sdk消息:", resultStr);
				mHandler.sendEmptyMessage(RESULT);

			}
		};
	}
	
	Handler mHandler = new Handler() {

		@Override
		public void handleMessage(Message msg) {
			super.handleMessage(msg);
			switch (msg.what) {
			case RESULT:
				result.setText(resultStr);
				break;
			default:
				break;
			}
		}
	};
	
	public void HelloWorld(String str1,String str2){
		Log.d("msg:", str1);
		layout("123");
	}
	
	public void layout(String str) {

		mHandler.post(new Runnable() {
			
			@Override
			public void run() {
				// TODO Auto-generated method stub
				mHelper.getAccessTokenOnDisplay(Constant.APP_ID, Constant.APP_KEY,mListener);
			}
		});
	}
	
	// Quit Unity
	@Override protected void onDestroy ()
	{
		mUnityPlayer.quit();
		super.onDestroy();
	}

	// Pause Unity
	@Override protected void onPause()
	{
		super.onPause();
		mUnityPlayer.pause();
	}

	// Resume Unity
	@Override protected void onResume()
	{
		super.onResume();
		mUnityPlayer.resume();
	}

	// This ensures the layout will be correct.
	@Override public void onConfigurationChanged(Configuration newConfig)
	{
		super.onConfigurationChanged(newConfig);
		mUnityPlayer.configurationChanged(newConfig);
	}

	// Notify Unity of the focus change.
	@Override public void onWindowFocusChanged(boolean hasFocus)
	{
		super.onWindowFocusChanged(hasFocus);
		mUnityPlayer.windowFocusChanged(hasFocus);
	}

	// For some reason the multiple keyevent type is not supported by the ndk.
	// Force event injection by overriding dispatchKeyEvent().
	@Override public boolean dispatchKeyEvent(KeyEvent event)
	{
		if (event.getAction() == KeyEvent.ACTION_MULTIPLE)
			return mUnityPlayer.injectEvent(event);
		return super.dispatchKeyEvent(event);
	}

	// Pass any events not handled by (unfocused) views straight to UnityPlayer
	@Override public boolean onKeyUp(int keyCode, KeyEvent event)     { return mUnityPlayer.injectEvent(event); }
	@Override public boolean onKeyDown(int keyCode, KeyEvent event)   { return mUnityPlayer.injectEvent(event); }
	@Override public boolean onTouchEvent(MotionEvent event)          { return mUnityPlayer.injectEvent(event); }
	/*API12*/ public boolean onGenericMotionEvent(MotionEvent event)  { return mUnityPlayer.injectEvent(event); }
}
