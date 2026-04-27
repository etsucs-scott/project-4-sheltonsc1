namespace sansfightfinal.Components.Services
{
    /// <summary>
    /// handles sans's dialogue during the fight
    /// </summary>
    public interface ITalkbox
    {
        /// <summary>
        /// gets the current dialogue line
        /// </summary>
        string CurrentDialogue { get; }

        /// <summary>
        /// advances to the next dialogue line
        /// </summary>
        /// <returns></returns>
        string NextDialogue();

        /// <summary>
        /// resets the dialogue to the beginning
        /// </summary>
        void Reset();

        /// <summary>
        /// checks for more dialogue lines
        /// </summary>
        bool HasMoreDialogue { get; }
    }
}
