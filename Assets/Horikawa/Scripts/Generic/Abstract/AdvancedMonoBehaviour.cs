using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdvancedMonoBehaviour : MonoBehaviour
{
    /// <summary>
    /// ’x‰„Às(ˆø”‚È‚µ)
    /// </summary>
    /// <param name="_action">Às‚·‚éˆ—</param>
    /// <param name="_waitTime">’x‰„ŠÔ(•b)</param>
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
    /// ’x‰„Às(ˆø”1‚Â)
    /// </summary>
    /// <typeparam name="T">ˆø”‚ÌŒ^</typeparam>
    /// <param name="_action">Às‚·‚éˆ—</param>
    /// <param name="_param">ˆø”</param>
    /// <param name="_waitTime">’x‰„ŠÔ(•b)</param>
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
    /// ’x‰„Às(ˆø”2‚Â)
    /// </summary>
    /// <typeparam name="T1">ˆø”1‚ÌŒ^</typeparam>
    /// <typeparam name="T2">ˆø”2‚ÌŒ^</typeparam>
    /// <param name="_action">Às‚·‚éˆ—</param>
    /// <param name="_param">ˆø”</param>
    /// <param name="_waitTime">’x‰„ŠÔ(•b)</param>
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
    /// ’x‰„Às(ˆø”3‚Â)
    /// </summary>
    /// <typeparam name="T1">ˆø”1‚ÌŒ^</typeparam>
    /// <typeparam name="T2">ˆø”2‚ÌŒ^</typeparam>
    /// <typeparam name="T3">ˆø”3‚ÌŒ^</typeparam>
    /// <param name="_action">Às‚·‚éˆ—</param>
    /// <param name="_param">ˆø”</param>
    /// <param name="_waitTime">’x‰„ŠÔ(•b)</param>
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
