using System.Collections;
// using Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZCard
{
    public class PlayerHandUtils : MonoBehaviour
    {
        public static bool CARD_MODE = true;
        public static int CARD_ACTION = -1;
        public static int CARD_ACT_DUR = 0;
        //--------------------------------t------------------------------------------------------------------------------

        #region Fields

        int Count { get; set; }

        [SerializeField]
        GameObject cardPrefabCs;
        [SerializeField]
        Transform deckPosition;
        [SerializeField]
        Transform gameView;

        IPlayerHand PlayerHand { get; set; }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Unitycallbacks

        void Awake() => PlayerHand = transform.parent.GetComponentInChildren<IPlayerHand>();

        RNGUtil rngUtil;
        IEnumerator Start()
        {
            rngUtil = new RNGUtil((uint)Time.realtimeSinceStartup);
            //starting cards
            for (var i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(0.2f);
                DrawCard();
            }
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        [Button]
        public void DrawCard()
        {
            var cardGo = Instantiate(cardPrefabCs, gameView);
            cardGo.name = "Card_" + Count;
            var card = cardGo.GetComponent<ICard>();
            card.transform.position = deckPosition.position;
            Count++;
            card.id = (int)rngUtil.RollRandomIntLessThan(3);
            card.transform.GetChild(card.id).gameObject.SetActive(true);
            PlayerHand.AddCard(card);
        }

        [Button]
        public void PlayCard()
        {
            if (PlayerHand.Cards.Count > 0)
            {
                PlayerHand.PlayCard(PlayerHand.Cards[0]);
            }
        }

        void Update()
        {
            if (CARD_ACT_DUR > 0)
            {
                CARD_ACT_DUR-=1;
            }
            if (CARD_ACT_DUR <= 0)
            {
                CARD_ACT_DUR = 0;
                CARD_ACTION = -1;
            }
        }

        public void Restart() => SceneManager.LoadScene(0);

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}