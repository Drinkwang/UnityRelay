/*
 * 文本对话系统，一个背景，一个头像位，一个人物名称位，一个人物对话位，一个提示空格加载下一条对话
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ineer_Dialog_System : MonoBehaviour
{
    // UI组件
    public Image face; // 头像
    public Text textName; // 人物名称
    public Text textLabel; // 人物对话
    // 从文件中读取的文本
    public TextAsset textFile_0; // 0号文本，对应Dialog_0,以下类推
    public TextAsset textFile_1;
    public TextAsset textFile_2;
    public TextAsset textFile_4;
    public TextAsset textFile_5;

    // 行数
    public int index;
    // 头像载入
    public Sprite facePlayer; // 主角精灵 - 亚恒大大
    public Sprite faceNPC_1; // 神秘人精灵
    public Sprite faceNPC_2; // 时间老人精灵

    List<string> textList = new List<string>(); // 存储读取的整个txt文件内容

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    private void OnEnable()
    {
        // 当对话框通过SetActive显示时执行，根据iFlag的值加载相应的文本
        index = 0;
        // Debug.Log("获取文本内容" + FUNCTION.GetFlag());
        switch (Ineer_Global.GetFlag())
        {
            case 0:
                // Debug.Log("0");
                GetTextFromFile(textFile_0);
                break;
            case 1:
                // Debug.Log("1");
                GetTextFromFile(textFile_1);
                break;
            case 2:
                // Debug.Log("2");
                GetTextFromFile(textFile_2);
                break;
            case 3:
                GetTextFromFile(textFile_4);
                break;
        }
        SetText();
        SetFace();
        // 对话开始时不允许旋转镜头和移动
        Ineer_Global.SetbMoved(false);
        Ineer_Global.SetbRotated(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 读取到最后一行，按下空格关闭对话框
        if (Input.GetKeyDown(KeyCode.Space) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            Ineer_Global.SetFlag(2);
            // 对话结束允许旋转镜头和移动
            Ineer_Global.SetbMoved(false);
            Ineer_Global.SetbRotated(true);
        }
        // 打印对话文字，设置对话人物名称，显示对话人物头像
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 这里注意需要先打印文字再设置相应的头像，头像是根据人物名称来改变的
            SetText();
            SetFace();
        }
    }
    // TextAsset获取txt文件内容
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var texts = file.text.Split('\n');
        foreach (var text in texts)
        {
            textList.Add(text);
        }
    }
    // 改变对话框文字和人物名称
    void SetText()
    {
        var texts = textList[index].Split('>');
        textName.text = texts[0];
        textLabel.text = texts[1];
        index++;
    }
    // 改变对话框人物头像
    void SetFace()
    {
        switch(textName.text)
        {
            case "亚恒":
                face.sprite = facePlayer;
                break;
            case "神秘人":
                face.sprite = faceNPC_1;
                break;
            case "时间老人":
                face.sprite = faceNPC_2;
                break;
        }
    }
}
