using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdvancedMonoBehaviour : MonoBehaviour
{
    /// <summary>
    /// �x�����s(�����Ȃ�)
    /// </summary>
    /// <param name="_action">���s���鏈��</param>
    /// <param name="_waitTime">�x������(�b)</param>
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
    /// �x�����s(����1��)
    /// </summary>
    /// <typeparam name="T">�����̌^</typeparam>
    /// <param name="_action">���s���鏈��</param>
    /// <param name="_param">����</param>
    /// <param name="_waitTime">�x������(�b)</param>
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
    /// �x�����s(����2��)
    /// </summary>
    /// <typeparam name="T1">����1�̌^</typeparam>
    /// <typeparam name="T2">����2�̌^</typeparam>
    /// <param name="_action">���s���鏈��</param>
    /// <param name="_param">����</param>
    /// <param name="_waitTime">�x������(�b)</param>
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
    /// �x�����s(����3��)
    /// </summary>
    /// <typeparam name="T1">����1�̌^</typeparam>
    /// <typeparam name="T2">����2�̌^</typeparam>
    /// <typeparam name="T3">����3�̌^</typeparam>
    /// <param name="_action">���s���鏈��</param>
    /// <param name="_param">����</param>
    /// <param name="_waitTime">�x������(�b)</param>
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
