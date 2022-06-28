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

        private void Awake()
        {
            DiscordButton.onClick.AddListener(() => Application.OpenURL(LinkDiscord));
            EllediaButton.onClick.AddListener(()=> Application.OpenURL(linkElledia));
        }

        private void OnDestroy()
        {
            DiscordButton.onClick.RemoveAllListeners();
            EllediaButton.onClick.RemoveAllListeners();
        }
    }
}