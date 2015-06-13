/********************************************
-	    File Name: 
-	  Description: 批量修改音频ImportSettings面板的值,右键点击音频，Reimport
-	 	   Author: lijing,<979477187@qq.com>
-     Create Date: 2015.6.8  9:33
-Revision History: --
********************************************/
using UnityEngine;
using System.Collections;
using UnityEditor;

public class AudioSet : AssetPostprocessor {

	public void OnPreprocessAudio(){
		AudioImporter audioImport=assetImporter as AudioImporter;
		audioImport.format=AudioImporterFormat.Compressed;
		audioImport.threeD=false;
		audioImport.loadType=AudioImporterLoadType.CompressedInMemory;
		audioImport.compressionBitrate=64000;
		Debug.Log("audioImport:"+audioImport.compressionBitrate);
	}
}
