using UnityEngine;
using UnityEngine.UI;

namespace Code.Event
{
    public class LinkToBrowser : MonoBehaviour
    {
        public const string LinkDiscord= "https://discord.gg/w2ujkDQDFA";
        public const string linkElledia = "https://vk.com/elledia_games";


        [field: SerializeField] private Button DiscordButton { get; set; }
        [field: SerializeField] private Button EllediaButton { get; set; }

        [field: SerializeField] private Button EllediaButtonToAvtorsPanel { get; set; } //TODO 1: ДОбавить

        [field: SerializeField] private Button TelegramG { get; set; }
        [field: SerializeField] private Button TelegramM { get; set; }
        [field: SerializeField] private Button TelegramA { get; set; }
        [field: SerializeField] private Button TelegramDANIYAR_LATYSHEV { get; set; }
        [field: SerializeField] private Button TelegramDANIIAR_ZORIN { get; set; }


        private void Awake()
        {
            DiscordButton.onClick.AddListener(() => Application.OpenURL(LinkDiscord));
            EllediaButtonToAvtorsPanel.onClick.AddListener(()=> Application.OpenURL(linkElledia));


            EllediaButton.onClick.AddListener(() => Application.OpenURL(linkElledia));

            TelegramG.onClick.AddListener(() => Application.OpenURL(TelegramLink.GEORGIY_LUZYANIN));
            TelegramM.onClick.AddListener(() => Application.OpenURL(TelegramLink.MAXIM_ZHBANOV));
            TelegramA.onClick.AddListener(() => Application.OpenURL(TelegramLink.ALINA_SHIPILOVA));
            TelegramDANIYAR_LATYSHEV.onClick.AddListener(() => Application.OpenURL(TelegramLink.DANIYAR_LATYSHEV));
            TelegramDANIIAR_ZORIN.onClick.AddListener(() => Application.OpenURL(TelegramLink.DANIIAR_ZORIN));
        }

        private void OnDestroy()
        {
            DiscordButton.onClick.RemoveAllListeners();
            EllediaButton.onClick.RemoveAllListeners();

            EllediaButtonToAvtorsPanel.onClick.RemoveAllListeners();

            TelegramG.onClick.RemoveAllListeners();
            TelegramM.onClick.RemoveAllListeners();
            TelegramA.onClick.RemoveAllListeners();
            TelegramDANIYAR_LATYSHEV.onClick.RemoveAllListeners();
            TelegramDANIIAR_ZORIN.onClick.RemoveAllListeners();

       
        }
    }
    public static class TelegramLink
    {
        public const string GEORGIY_LUZYANIN = "https://t.me/D0GMAR";
        public const string MAXIM_ZHBANOV = "https://t.me/Hisagiru";
        public const string ALINA_SHIPILOVA = "https://t.me/LazerOlen";
        public const string DANIYAR_LATYSHEV = "https://t.me/Akari_steam";
        public const string DANIIAR_ZORIN = "https://t.me/lessmoon_off";
    }
}