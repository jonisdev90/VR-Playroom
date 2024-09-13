using Items.ScriptableObjects;

namespace System
{
    public class EventsServices
    {
        public static EventsServices Instance => _instance ?? (_instance = new EventsServices());
        private static EventsServices _instance;

        public Action<int> OnGetHealth;
        public Action<ItemData> OnAddItem;
        public Action<SoundType> OnPlaySound;
    }
}