using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZCard;


public class GameCtrl : MonoBehaviour
{
    //用于整合整个游戏流程

    //暂定游戏流程：(可随意修改)
    //游戏开始时候可以正常移动，但玩家会遇到一些NPC，这些NPC的对话会让整个游戏的规则和逻辑变化
    //让所有NPC都释怀是游戏的目的

    //NPC1：利用卡牌。卡牌怪人：“不会知道我的感受的，我不玩牌甚至寸步难行！”
    //玩家只能够用卡牌前进一小段距离。

    //NPC2：怕黑的男孩。“这里好黑，能够帮我点亮后面的灯吗？”
    //点灯“谢谢”

    //NPC3：一个不断转动的3维立方体。“你能够理解我和这个世界的格格不入吗？”
    //被传送到3维房间中
    //“谢谢你尝试了解我。”

    //NPC4：跟风怪，利用旋风。旋风从游戏开始就一直在玩家的前面一点，玩家一直在跟风。
    //最后和跟风怪对话：“人不跟风就活不下了吧，我明白的。”
    //玩家回头走，不再跟风：“或许我错了”

    //NPC5：莉莉丝是终点，主角走到莉莉丝处就消失，回归母体

    //把其他人的心结解开，也是把自己心结解开的过程，最终回归母体。 → 我也不知道我在说什么(￣▽￣)

    public GameObject NPC1_1;
    public GameObject NPC1_2;

    private void Start()
    {
        StartCoroutine(mainHandle());
    }

    IEnumerator mainHandle()
    {
        //关闭卡牌模式，正常AD走路
        PlayerHandUtils.CARD_MODE = false;

        //NPC1 Handle
        yield return StartCoroutine(NPCHandle_1());
        //NPC2 Handle
        //TODO

        //NPC3 Handle
        //TODO

        //NPC4 Handle
        //TODO

        //NPC5 Handle
        //TODO

        yield return null;
    }

    //卡牌人
    IEnumerator NPCHandle_1()
    {
        //TODO:对话系统有问题
        //等待玩家与NPC1对话完毕
        yield return StartCoroutine(WaitForNpcTalkDone(NPC1_1));

        //开始卡牌模式
        //PlayerHandUtils.CARD_MODE = true; // 此处注释by清梦微风

        //等待玩家与NPC2对话完毕
        yield return StartCoroutine(WaitForNpcTalkDone(NPC1_2));

        //结束卡牌模式
        //PlayerHandUtils.CARD_MODE = true; // 此处注释by清梦微风
    }

    IEnumerator WaitForNpcTalkDone(GameObject npc)
    {
        while (true)
        {
            if (npc.GetComponent<ReadText>().IsTalkEnd())
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

}
