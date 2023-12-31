using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdvancedMonoBehaviour : MonoBehaviour
{
    /// <summary>
    /// 遅延実行(引数なし)
    /// </summary>
    /// <param name="_action">実行する処理</param>
    /// <param name="_waitTime">遅延時間(秒)</param>
    protected void Invoke(Action _action, float _waitTime)
    {
        StartCoroutine(DoInvoke(_action, _waitTime));
    }

    private IEnumerator DoInvoke(Action _action, float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);

        _action();
    }

    /// <summary>
    /// 遅延実行(引数1つ)
    /// </summary>
    /// <typeparam name="T">引数の型</typeparam>
    /// <param name="_action">実行する処理</param>
    /// <param name="_param">引数</param>
    /// <param name="_waitTime">遅延時間(秒)</param>
    protected void Invoke<T>(Action<T> _action, T _param, float _waitTime)
    {
        StartCoroutine(DoInvoke(_action, _param, _waitTime));
    }

    private IEnumerator DoInvoke<T>(Action<T> _action, T _param, float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);

        _action(_param);
    }

    /// <summary>
    /// 遅延実行(引数2つ)
    /// </summary>
    /// <typeparam name="T1">引数1の型</typeparam>
    /// <typeparam name="T2">引数2の型</typeparam>
    /// <param name="_action">実行する処理</param>
    /// <param name="_param">引数</param>
    /// <param name="_waitTime">遅延時間(秒)</param>
    protected void Invoke<T1, T2>(Action<T1, T2> _action, Tuple<T1, T2> _param, float _waitTime)
    {
        StartCoroutine(DoInvoke(_action, _param, _waitTime));
    }

    private IEnumerator DoInvoke<T1, T2>(Action<T1, T2> _action, Tuple<T1, T2> _param, float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);

        _action(_param.Item1, _param.Item2);
    }

    /// <summary>
    /// 遅延実行(引数3つ)
    /// </summary>
    /// <typeparam name="T1">引数1の型</typeparam>
    /// <typeparam name="T2">引数2の型</typeparam>
    /// <typeparam name="T3">引数3の型</typeparam>
    /// <param name="_action">実行する処理</param>
    /// <param name="_param">引数</param>
    /// <param name="_waitTime">遅延時間(秒)</param>
    protected void Invoke<T1, T2, T3>(Action<T1, T2, T3> _action, Tuple<T1, T2, T3> _param, float _waitTime)
    {
        StartCoroutine(DoInvoke(_action, _param, _waitTime));
    }

    private IEnumerator DoInvoke<T1, T2, T3>(Action<T1, T2, T3> _action, Tuple<T1, T2, T3> _param, float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);

        _action(_param.Item1, _param.Item2, _param.Item3);
    }
}
