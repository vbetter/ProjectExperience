package com.yidong.ydsdk;

import org.json.JSONObject;

import com.yidong.ydsdk.Constant;
import com.yidong.ydsdk.SharePersist;
import com.yidong.ydsdk.R;





//import cn.richinfo.umcsdk.open.demo.R;
//import cn.richinfo.umcsdk.open.demo.util.SharePersist;
import mail139.umcsdk.auth.AuthnHelper;
import mail139.umcsdk.auth.TokenListener;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.ActionBar;
import android.support.v4.app.Fragment;
import android.content.Context;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.os.Build;

public class MainActivity extends ActionBarActivity {
	private AuthnHelper mHelper;
	private Context mContext;
	String resultStr;
	private TextView result;
	String uuid1;
	String artifact1;
	public static String uid1;
	private TokenListener mListener;
	private static final int RESULT = 0x111;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		//setContentView(R.layout.activity_main);
		mContext = this;
		mHelper = AuthnHelper.init(mContext);
		
		init();
		
		layoutLogin(Constant.APP_ID,Constant.APP_KEY);
	}
	
	private void init() {

		result = (TextView) findViewById(R.id.text_result);
		
		mListener = new TokenListener() {

			@Override
			public void onGetTokenComplete(JSONObject jObj) {
				resultStr = jObj.toString();
				Log.e("收到sdk消息:", resultStr);
				mHandler.sendEmptyMessage(RESULT);
			}
		};
	}
	
	private void layoutLogin(String appID,String appKey){
		mHelper.getAccessTokenOnDisplay(appID,appKey,mListener);
	}
	
	Handler mHandler = new Handler() {

		@Override
		public void handleMessage(Message msg) {
			super.handleMessage(msg);
			switch (msg.what) {
			case RESULT:
				//result.setText(resultStr);
				Log.d("callBack", resultStr);
				break;
			default:
				break;
			}
		}
	};
}
