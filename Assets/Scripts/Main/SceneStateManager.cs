using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour
{
    public static SceneStateManager instance;

    public enum SceneType
    {
        Main,
        Battle,

        //TODO �V�����V�[�����쐬������A�񋓎q�ɂ��V�[������o�^����
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// �����Ŏw�肵���V�[���փV�[���J��
    /// </summary>
    /// <param name="nextSceneType"></param>


    public void NextScene(SceneType nextSceneType)
    {
        // �V�[�������w�肷������ɂ́Aenum �ł��� SceneType �̗񋓎q���A ToString ���\�b�h���g���� string �^�փL���X�g���ė��p
        SceneManager.LoadScene(nextSceneType.ToString());
    }

}
