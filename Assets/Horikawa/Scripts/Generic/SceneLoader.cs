using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
	//�@�񓯊�����Ŏg�p����AsyncOperation
	private AsyncOperation loadAsync;

	// �ǂݍ��ރV�[����
	[SerializeField]
	private string LoadSceneName;

	//�@�ǂݍ��ݗ���\������X���C�_�[
	[SerializeField]
	private Gauge loadGauge;

	public void Start()
	{
		//�@�R���[�`�����J�n
		StartCoroutine(LoadData());
	}

	IEnumerator LoadData()
	{
		// �V�[���̓ǂݍ��݂�����
		loadAsync = SceneManager.LoadSceneAsync(LoadSceneName);

		//�@�ǂݍ��݂��I���܂Ői���󋵂��X���C�_�[�̒l�ɔ��f������
		while (!loadAsync.isDone)
		{
			// �i�s�x���X���C�_�[�ɔ��f
			float progressVal = Mathf.Clamp01(loadAsync.progress / 0.9f);
			loadGauge.Value = progressVal;
			yield return null;
		}
	}
}
