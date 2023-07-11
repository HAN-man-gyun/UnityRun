using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.Rendering;

public static partial class Function
{
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {//Wrapping:  메서드를 사용할때 내가 편하기 위해 재정의하거나 추가하는것을 랩핑이라고함.
     //빌드에 로그를 포함시키지 않는법 -> 전처리기의 이름 (디파인 심볼)
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {//Wrapping:  메서드를 사용할때 내가 편하기 위해 재정의하거나 추가하는것을 랩핑이라고함.
     //빌드에 로그를 포함시키지 않는법 -> 전처리기의 이름 (디파인 심볼)
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! GameObject 받아서 Text 컴포넌트 찾아서 text필드값 수정하는 함수

    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if(textComponent ==null || textComponent == default) { return; }
        
        textComponent.text = text;
    }
    //LoadScene 함수를 래핑한다.
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
    //현재 씬의 이름을 리턴한다.
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    //두백터를 더한다.

    public static Vector2 AddVector(this Vector3 origin, Vector2 addvector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addvector;
        return result;
    }

    // 컴포넌트가 존재하는 지 여부를 확인하는 함수
    public static bool IsValid<T>(this T target ) where  T : Component
    {
        if(target == null || target == default)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //리스트가 유효한지 여부를 체크하는 함수
    public static bool IsValid<T>(this List<T> target) 
    {
        bool isInvalid = (target == null || target == default);
        isInvalid = isInvalid || target.Count == 0;


        if (isInvalid == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
