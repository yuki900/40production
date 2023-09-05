using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
	//　非同期動作で使用するAsyncOperation
	private AsyncOperation loadAsync;

	// 読み込むシーン名
	[SerializeField]
	private string LoadSceneName;

	//　読み込み率を表示するスライダー
	[SerializeField]
	private Gauge loadGauge;

	public void Start()
	{
		//　コルーチンを開始
		StartCoroutine(LoadData());
	}

	IEnumerator LoadData()
	{
		// シーンの読み込みをする
		loadAsync = SceneManager.LoadSceneAsync(LoadSceneName);

		//　読み込みが終わるまで進捗状況をスライダーの値に反映させる
		while (!loadAsync.isDone)
		{
			// 進行度をスライダーに反映
			float progressVal = Mathf.Clamp01(loadAsync.progress / 0.9f);
			loadGauge.Value = progressVal;
			yield return null;
		}
	}
}
