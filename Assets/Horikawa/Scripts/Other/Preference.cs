using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace K_Librarys
{
    public static class Preference
    {
        /// <summary>
        /// �Z�[�u�f�[�^�̃N���X
        /// </summary>
        /// <typeparam name="T">�ۑ�����f�[�^�̌^</typeparam>
        [System.Serializable]
        private class SaveData<T>
        {
            public SaveData(T _data)
            {
                Data = _data;
            }

            public T Data;
        }

        // �ۑ���̃t�H���_(�f�B���N�g��)�̃p�X
        private static readonly string DIRECTRY_PATH = Application.persistentDataPath + "/.Preference";

        // �G�f�B�^
        private const string EDITOR_DIRECTRY_NAME = "Editor";
        // �r���h
        private const string BUILD_DIRECTRY_NAME = "Build";

        /// <summary>
        /// �Z�[�u�f�[�^���������ފ֐�
        /// </summary>
        /// <typeparam name="T">�ۑ�����f�[�^�̌^ �l�^�̂�</typeparam>
        /// <param name="_saveData">�ۑ�����f�[�^</param>
        /// <param name="_key">�L�[</param>
        public static void Save<T>(T _saveData, string _key) where T : struct
        {
            SaveInternal(_saveData, _key);
        }

        /// <summary>
        /// �Z�[�u�f�[�^���������ފ֐�(string�^)
        /// </summary>
        /// <param name="_saveData">�ۑ�����f�[�^</param>
        /// <param name="_key">�L�[</param>
        public static void Save(string _saveData, string _key)
        {
            SaveInternal(_saveData, _key);
        }

        /// <summary>
        /// �Z�[�u�f�[�^���������ފ֐�(�z��)
        /// </summary>
        /// <typeparam name="T">�ۑ�����f�[�^�̗v�f�̌^ �l�^�̂�</typeparam>
        /// <param name="_saveData">�ۑ�����f�[�^</param>
        /// <param name="_key">�L�[</param>
        public static void SaveArray<T>(T[] _saveData, string _key) where T : struct
        {
            SaveInternal(_saveData, _key);
        }

        /// <summary>
        /// �Z�[�u�f�[�^���������ފ֐�(string�^�z��)
        /// </summary>
        /// <typeparam name="T">�ۑ�����f�[�^�̗v�f�̌^ �l�^�̂�</typeparam>
        /// <param name="_saveData">�ۑ�����f�[�^</param>
        /// <param name="_key">�L�[</param>
        public static void SaveArray(string[] _saveData, string _key)
        {
            SaveInternal(_saveData, _key);
        }

        /// <summary>
        /// �Z�[�u����
        /// </summary>
        /// <typeparam name="T">�ۑ�����f�[�^�̌^</typeparam>
        /// <param name="_saveData">�ۑ�����f�[�^</param>
        /// <param name="_key">�L�[</param>
        private static void SaveInternal<T>(T _saveData, string _key)
        {
            //if(!typeof(T).IsSerializable)
            //{
            //    Debug.LogError("�^\"" + typeof(T).Name + "\"�̓V���A�����ł��܂���B�Z�[�u�Ɏ��s���܂����B");
            //    return;
            //}

            // �L�[�������ȏꍇ�G���[���O���o����return����
            if (!IsValidKey(_key))
            {
                Debug.LogError("�L�[\"" + _key + "\"�͖����ł��B�Z�[�u�Ɏ��s���܂����B");
                return;
            }

            // �ۑ���̃t�H���_���m��
            SecureDirectry();

            // �L�[����p�X�𐶐�
            string path = KeyToPath(_key);

            // �p�X���烉�C�^�[�𐶐�
            StreamWriter streamWriter = new(path, false);

            // �Z�[�u�f�[�^���쐬
            SaveData<T> saveDataClass = new(_saveData);

            // json�f�[�^�𐶐�
            string jsonData = JsonUtility.ToJson(saveDataClass, true);

            // ���C�^�[�ɏ�������
            streamWriter.Write(jsonData);
            // stream�ɗ���
            streamWriter.Flush();
            // ���C�^�[�����
            streamWriter.Close();
        }

        /// <summary>
        /// �Z�[�u�f�[�^��ǂݍ��ފ֐�
        /// </summary>
        /// <typeparam name="T">�ǂݍ��ރf�[�^�̌^ �l�^�̂�</typeparam>
        /// <param name="_key">�L�[</param>
        /// <param name="_defaultValue">�f�t�H���g�l</param>
        /// <returns>�ǂݍ��񂾃f�[�^��Ԃ� �L�[�����݂��Ȃ��ꍇ�̓f�t�H���g�l��Ԃ�</returns>
        public static T Load<T>(string _key, T _defaultValue = default) where T : struct
        {
            return LoadInternal(_key, _defaultValue);
        }

        /// <summary>
        /// �Z�[�u�f�[�^��ǂݍ��ފ֐�(string�^)
        /// </summary>
        /// <param name="_key">�L�[</param>
        /// <param name="_defaultValue">�f�t�H���g�l</param>
        /// <returns>�ǂݍ��񂾃f�[�^��Ԃ� �L�[�����݂��Ȃ��ꍇ�̓f�t�H���g�l��Ԃ�</returns>
        public static string Load(string _key, string _defaultValue = default)
        {
            return LoadInternal(_key, _defaultValue);
        }

        /// <summary>
        /// �Z�[�u�f�[�^��ǂݍ��ފ֐�(�z��)
        /// </summary>
        /// <typeparam name="T">�ǂݍ��ރf�[�^�̗v�f�̌^ �l�^�̂�</typeparam>
        /// <param name="_key">�L�[</param>
        /// <param name="_defaultValue">�f�t�H���g�l</param>
        /// <returns>�ǂݍ��񂾃f�[�^��Ԃ� �L�[�����݂��Ȃ��ꍇ�̓f�t�H���g�l��Ԃ�</returns>
        public static T[] LoadArray<T>(string _key, T[] _defaultValue = default) where T : struct
        {
            return LoadInternal(_key, _defaultValue);
        }

        /// <summary>
        /// �Z�[�u�f�[�^��ǂݍ��ފ֐�(string�^�z��)
        /// </summary>
        /// <typeparam name="T">�ǂݍ��ރf�[�^�̗v�f�̌^ �l�^�̂�</typeparam>
        /// <param name="_key">�L�[</param>
        /// <param name="_defaultValue">�f�t�H���g�l</param>
        /// <returns>�ǂݍ��񂾃f�[�^��Ԃ� �L�[�����݂��Ȃ��ꍇ�̓f�t�H���g�l��Ԃ�</returns>
        public static string[] LoadArray(string _key, string[] _defaultValue = default)
        {
            return LoadInternal(_key, _defaultValue);
        }

        /// <summary>
        /// ���[�h����
        /// </summary>
        /// <typeparam name="T">�ǂݍ��ރf�[�^�̌^</typeparam>
        /// <param name="_key">�L�[</param>
        /// <param name="_defaultValue">�f�t�H���g�l</param>
        /// <returns>�ǂݍ��񂾃f�[�^��Ԃ� �L�[�����݂��Ȃ��ꍇ�̓f�t�H���g�l��Ԃ�</returns>
        private static T LoadInternal<T>(string _key, T _defaultValue = default)
        {
            // �L�[�ɑΉ������f�[�^�����݂��Ȃ����
            if (!HasKey(_key))
            {
                // �x�����O��\��
                Debug.LogWarning("�L�[\"" + _key + "\"�ɑΉ������Z�[�u�f�[�^�͑��݂��܂���B���[�h�Ɏ��s���܂����B�f�t�H���g�l��Ԃ��܂��B");

                // �f�t�H���g�l��Ԃ�
                return _defaultValue;
            }

            // �L�[����p�X�𐶐�
            string path = KeyToPath(_key);

            // �p�X���烊�[�_�[�𐶐�
            StreamReader streamReader = new(path);

            // json�f�[�^��ǂݍ���
            string jsonData = streamReader.ReadToEnd();

            // ���[�_�[�����
            streamReader.Close();

            // json����Z�[�u�f�[�^�ɕϊ�
            SaveData<T> ret = JsonUtility.FromJson<SaveData<T>>(jsonData);

            // �ǂݍ��񂾒l��Ԃ�
            return ret.Data;
        }

        /// <summary>
        /// �ۑ���̃t�H���_(�f�B���N�g��)���m�ۂ���֐�
        /// </summary>
        private static void SecureDirectry()
        {
            // �ۑ���̃t�H���_���쐬����
            Directory.CreateDirectory(DIRECTRY_PATH);
            Directory.CreateDirectory(DIRECTRY_PATH + "/" + EDITOR_DIRECTRY_NAME);
            Directory.CreateDirectory(DIRECTRY_PATH + "/" + BUILD_DIRECTRY_NAME);
        }

        /// <summary>
        /// �L�[����ۑ���̃p�X�𐶐����ĕԂ��֐�
        /// </summary>
        /// <param name="_key">�L�[</param>
        /// <returns></returns>
        private static string KeyToPath(string _key)
        {
            string path = DIRECTRY_PATH;

            bool isEditor = false;
#if UNITY_EDITOR
            isEditor = true;
#endif
            path += "/" + (isEditor ? EDITOR_DIRECTRY_NAME : BUILD_DIRECTRY_NAME);
            

            // �ۑ���t�H���_�̒���json�^�̃t�@�C���Ƃ��ĕۑ�����
            return path + "/" + _key + ".json";
        }

        /// <summary>
        /// �L�[�ɑΉ�����Z�[�u�f�[�^�����݂��邩�Ԃ��֐�
        /// </summary>
        /// <param name="_key">�L�[</param>
        /// <returns></returns>
        public static bool HasKey(string _key)
        {
            return File.Exists(KeyToPath(_key));
        }


        /// <summary>
        /// �L�[�̕����񂪗L�������؂��ĕԂ��֐�
        /// </summary>
        /// <param name="_key">���؂���L�[</param>
        /// <returns></returns>
        public static bool IsValidKey(string _key)
        {
            // �t�@�C�����Ɏg�p�ł��Ȃ��������擾
            char[] invalidChars = Path.GetInvalidFileNameChars();

            // �L�[�Ɋ܂܂�Ă��Ȃ����true��Ԃ�
            return (_key.IndexOfAny(invalidChars) < 0);
        }

        /// <summary>
        /// �L�[�ɑΉ������Z�[�u�f�[�^���폜����֐�
        /// </summary>
        /// <param name="_key">�L�[</param>
        public static void DeleteByKey(string _key)
        {
            // �L�[�������ȏꍇreturn����
            if (!IsValidKey(_key))
            {
                return;
            }

            // �L�[����p�X�𐶐�
            string path = KeyToPath(_key);

            // �t�@�C�������݂��Ȃ����return����
            if (!File.Exists(path))
            {
                return;
            }

            // �p�X�����Ƀt�@�C�����폜����
            File.Delete(path);
        }

        /// <summary>
        /// �S�ẴZ�[�u�f�[�^���폜����֐� �g�p����ۂ͗v����
        /// </summary>
        public static void DeleteAll()
        {
            // �p�X����t�H���_���𐶐�
            DirectoryInfo directoryInfo = new(DIRECTRY_PATH);

            // ���g�̃t�@�C����S�č폜����
            //foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            //{
            //    fileInfoDelete();
            //}
            foreach (DirectoryInfo directryInfo in directoryInfo.GetDirectories())
            {
                directryInfo.Delete();
            }
        }
    }
}