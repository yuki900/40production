using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace K_Librarys
{
    public static class Preference
    {
        /// <summary>
        /// セーブデータのクラス
        /// </summary>
        /// <typeparam name="T">保存するデータの型</typeparam>
        [System.Serializable]
        private class SaveData<T>
        {
            public SaveData(T _data)
            {
                Data = _data;
            }

            public T Data;
        }

        // 保存先のフォルダ(ディレクトリ)のパス
        private static readonly string DIRECTRY_PATH = Application.persistentDataPath + "/.Preference";

        // エディタ
        private const string EDITOR_DIRECTRY_NAME = "Editor";
        // ビルド
        private const string BUILD_DIRECTRY_NAME = "Build";

        /// <summary>
        /// セーブデータを書き込む関数
        /// </summary>
        /// <typeparam name="T">保存するデータの型 値型のみ</typeparam>
        /// <param name="_saveData">保存するデータ</param>
        /// <param name="_key">キー</param>
        public static void Save<T>(T _saveData, string _key) where T : struct
        {
            SaveInternal(_saveData, _key);
        }

        /// <summary>
        /// セーブデータを書き込む関数(string型)
        /// </summary>
        /// <param name="_saveData">保存するデータ</param>
        /// <param name="_key">キー</param>
        public static void Save(string _saveData, string _key)
        {
            SaveInternal(_saveData, _key);
        }

        /// <summary>
        /// セーブデータを書き込む関数(配列)
        /// </summary>
        /// <typeparam name="T">保存するデータの要素の型 値型のみ</typeparam>
        /// <param name="_saveData">保存するデータ</param>
        /// <param name="_key">キー</param>
        public static void SaveArray<T>(T[] _saveData, string _key) where T : struct
        {
            SaveInternal(_saveData, _key);
        }

        /// <summary>
        /// セーブデータを書き込む関数(string型配列)
        /// </summary>
        /// <typeparam name="T">保存するデータの要素の型 値型のみ</typeparam>
        /// <param name="_saveData">保存するデータ</param>
        /// <param name="_key">キー</param>
        public static void SaveArray(string[] _saveData, string _key)
        {
            SaveInternal(_saveData, _key);
        }

        /// <summary>
        /// セーブ処理
        /// </summary>
        /// <typeparam name="T">保存するデータの型</typeparam>
        /// <param name="_saveData">保存するデータ</param>
        /// <param name="_key">キー</param>
        private static void SaveInternal<T>(T _saveData, string _key)
        {
            //if(!typeof(T).IsSerializable)
            //{
            //    Debug.LogError("型\"" + typeof(T).Name + "\"はシリアル化できません。セーブに失敗しました。");
            //    return;
            //}

            // キーが無効な場合エラーログを出してreturnする
            if (!IsValidKey(_key))
            {
                Debug.LogError("キー\"" + _key + "\"は無効です。セーブに失敗しました。");
                return;
            }

            // 保存先のフォルダを確保
            SecureDirectry();

            // キーからパスを生成
            string path = KeyToPath(_key);

            // パスからライターを生成
            StreamWriter streamWriter = new(path, false);

            // セーブデータを作成
            SaveData<T> saveDataClass = new(_saveData);

            // jsonデータを生成
            string jsonData = JsonUtility.ToJson(saveDataClass, true);

            // ライターに書き込む
            streamWriter.Write(jsonData);
            // streamに流す
            streamWriter.Flush();
            // ライターを閉じる
            streamWriter.Close();
        }

        /// <summary>
        /// セーブデータを読み込む関数
        /// </summary>
        /// <typeparam name="T">読み込むデータの型 値型のみ</typeparam>
        /// <param name="_key">キー</param>
        /// <param name="_defaultValue">デフォルト値</param>
        /// <returns>読み込んだデータを返す キーが存在しない場合はデフォルト値を返す</returns>
        public static T Load<T>(string _key, T _defaultValue = default) where T : struct
        {
            return LoadInternal(_key, _defaultValue);
        }

        /// <summary>
        /// セーブデータを読み込む関数(string型)
        /// </summary>
        /// <param name="_key">キー</param>
        /// <param name="_defaultValue">デフォルト値</param>
        /// <returns>読み込んだデータを返す キーが存在しない場合はデフォルト値を返す</returns>
        public static string Load(string _key, string _defaultValue = default)
        {
            return LoadInternal(_key, _defaultValue);
        }

        /// <summary>
        /// セーブデータを読み込む関数(配列)
        /// </summary>
        /// <typeparam name="T">読み込むデータの要素の型 値型のみ</typeparam>
        /// <param name="_key">キー</param>
        /// <param name="_defaultValue">デフォルト値</param>
        /// <returns>読み込んだデータを返す キーが存在しない場合はデフォルト値を返す</returns>
        public static T[] LoadArray<T>(string _key, T[] _defaultValue = default) where T : struct
        {
            return LoadInternal(_key, _defaultValue);
        }

        /// <summary>
        /// セーブデータを読み込む関数(string型配列)
        /// </summary>
        /// <typeparam name="T">読み込むデータの要素の型 値型のみ</typeparam>
        /// <param name="_key">キー</param>
        /// <param name="_defaultValue">デフォルト値</param>
        /// <returns>読み込んだデータを返す キーが存在しない場合はデフォルト値を返す</returns>
        public static string[] LoadArray(string _key, string[] _defaultValue = default)
        {
            return LoadInternal(_key, _defaultValue);
        }

        /// <summary>
        /// ロード処理
        /// </summary>
        /// <typeparam name="T">読み込むデータの型</typeparam>
        /// <param name="_key">キー</param>
        /// <param name="_defaultValue">デフォルト値</param>
        /// <returns>読み込んだデータを返す キーが存在しない場合はデフォルト値を返す</returns>
        private static T LoadInternal<T>(string _key, T _defaultValue = default)
        {
            // キーに対応したデータが存在しなければ
            if (!HasKey(_key))
            {
                // 警告ログを表示
                Debug.LogWarning("キー\"" + _key + "\"に対応したセーブデータは存在しません。ロードに失敗しました。デフォルト値を返します。");

                // デフォルト値を返す
                return _defaultValue;
            }

            // キーからパスを生成
            string path = KeyToPath(_key);

            // パスからリーダーを生成
            StreamReader streamReader = new(path);

            // jsonデータを読み込む
            string jsonData = streamReader.ReadToEnd();

            // リーダーを閉じる
            streamReader.Close();

            // jsonからセーブデータに変換
            SaveData<T> ret = JsonUtility.FromJson<SaveData<T>>(jsonData);

            // 読み込んだ値を返す
            return ret.Data;
        }

        /// <summary>
        /// 保存先のフォルダ(ディレクトリ)を確保する関数
        /// </summary>
        private static void SecureDirectry()
        {
            // 保存先のフォルダを作成する
            Directory.CreateDirectory(DIRECTRY_PATH);
            Directory.CreateDirectory(DIRECTRY_PATH + "/" + EDITOR_DIRECTRY_NAME);
            Directory.CreateDirectory(DIRECTRY_PATH + "/" + BUILD_DIRECTRY_NAME);
        }

        /// <summary>
        /// キーから保存先のパスを生成して返す関数
        /// </summary>
        /// <param name="_key">キー</param>
        /// <returns></returns>
        private static string KeyToPath(string _key)
        {
            string path = DIRECTRY_PATH;

            bool isEditor = false;
#if UNITY_EDITOR
            isEditor = true;
#endif
            path += "/" + (isEditor ? EDITOR_DIRECTRY_NAME : BUILD_DIRECTRY_NAME);
            

            // 保存先フォルダの中にjson型のファイルとして保存する
            return path + "/" + _key + ".json";
        }

        /// <summary>
        /// キーに対応するセーブデータが存在するか返す関数
        /// </summary>
        /// <param name="_key">キー</param>
        /// <returns></returns>
        public static bool HasKey(string _key)
        {
            return File.Exists(KeyToPath(_key));
        }


        /// <summary>
        /// キーの文字列が有効か検証して返す関数
        /// </summary>
        /// <param name="_key">検証するキー</param>
        /// <returns></returns>
        public static bool IsValidKey(string _key)
        {
            // ファイル名に使用できない文字を取得
            char[] invalidChars = Path.GetInvalidFileNameChars();

            // キーに含まれていなければtrueを返す
            return (_key.IndexOfAny(invalidChars) < 0);
        }

        /// <summary>
        /// キーに対応したセーブデータを削除する関数
        /// </summary>
        /// <param name="_key">キー</param>
        public static void DeleteByKey(string _key)
        {
            // キーが無効な場合returnする
            if (!IsValidKey(_key))
            {
                return;
            }

            // キーからパスを生成
            string path = KeyToPath(_key);

            // ファイルが存在しなければreturnする
            if (!File.Exists(path))
            {
                return;
            }

            // パスを元にファイルを削除する
            File.Delete(path);
        }

        /// <summary>
        /// 全てのセーブデータを削除する関数 使用する際は要注意
        /// </summary>
        public static void DeleteAll()
        {
            // パスからフォルダ情報を生成
            DirectoryInfo directoryInfo = new(DIRECTRY_PATH);

            // 中身のファイルを全て削除する
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