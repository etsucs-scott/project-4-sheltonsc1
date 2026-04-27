using sansfightfinal.Components.Services;

namespace sansfightfinal.Components
{
    /// <summary>
    /// implements ITalkbox
    /// </summary>
    public class SansTalkBox : ITalkbox
    {
        /// <summary>
        /// list of of all available lines for sans to use
        /// </summary>
        private readonly List<string> _dialogue = new()
        {
            "it's a beautiful day outside.\r\n" +                   //dialogue lines taken from https://undertale.fandom.com/wiki/Sans/In_Battle#Quotes
            "birds are singing, flowers are blooming...\r\n" +
            "on days like these, kids like you...\r\n" +
            "S h o u l d  b e  b u r n i n g  i n  h e l l .",
            "you're gonna have a bad time.",
            "what? you think i'm just gonna stand there and take it?",
            "our reports showed a massive anomaly in the timespace continuum.\r\n" +
            "timelines jumping left and right, stopping and starting...",
            "you can't understand how this feels.",
            "knowing that one day, without any warning...\r\n" +
            "it's all going to be reset.",
            "Look. i gave up trying to go back a long time ago.",
            "And getting to the surface doesn't really appeal anymore, either.",
            "cause even if we do...\r\n" +
            "we'll just end up right back here, without any memory of it, right?",
            "to be blunt...\r\n" +
            "it makes it kind of hard to give it my all.",
            "... or is that just a poor excuse for being lazy...?\r\n" +
            "hell if i know.",
            "all i know is... seeing what comes next...\r\n" +
            "i can't afford not to care anymore.",
            "sounds strange, but before all this i was secretly hoping we could be friends.\r\n" +
            "i always thought the anomaly was doing this cause they were unhappy.\r\n" +
            "and when they got what they wanted, they would stop all this.",
            "and maybe all they needed was... i dunno.\r\n" +
            "some good food, some bad laughs, some nice friends.",
            "but that's ridiculous, right?\r\n" +
            "yeah, you're the type of person who won't EVER be happy.",
            "you'll keep consuming timelines over and over, until...\r\n" +
            "well.\r\nhey.\r\n" +
            "take it from me, kid.\r\n" +
            "someday...\r\n" +
            "you gotta learn when to QUIT.",
            "cause... y'see..\r\n" +
            "all this fighting is really tiring me out.",
            "and if you keep pushing me...\r\n" +
            "then i'll be forced to use my special attack.",
            "yeah, my special attack. sound familiar?\r\n" +
            "well, get ready. cause after the next move, i'm going to use it.\r\n" +
            "so, if you don't wanna see it, now would be a good time to die.",
            "well, here goes nothing...\r\n" +
            "are you ready?\r\n" +
            "survive THIS, and i'll show you my special attack!",
            "huff... puff...\r\n" +
            "all right. that's it.\r\n" +
            "it's time for my special attack.\r\n" +
            "are you ready?\r\n" +
            "here goes nothing.\r\n" +
            "yep.\r\n" +
            "that's right.\r\n" +
            "it's literally nothing.\r\n" +
            "and it's not gonna be anything, either.\r\n" +
            "heh heh heh... ya get it?\r\n" +
            "i know i can't beat you.\r\n" +
            "one of your turns...\r\n" +
            "you're just gonna kill me.\r\n" +
            "so, uh.\r\n" +
            "i've decided...\r\n" +
            "it's not gonna BE your turn. ever.\r\n" +
            "i'm just gonna keep having MY turn until you give up.\r\n" +
            "even if it means we have to stand here until the end of time.\r\n" +
            "capiche?\r\n" +
            "you'll get bored here.\r\n" +
            "if you haven't gotten bored already, i mean.\r\n" +
            "and then, you'll finally quit.\r\n" +
            "i know your type.\r\n" +
            "you're, uh, very determined, aren't you?\r\n" +
            "you'll never give up, even if there's, uh...\r\n" +
            "absolutely NO benefit to persevering whatsoever.\r\n" +
            "if i can make that clear.\r\n" +
            "no matter what, you'll just keep going.\r\n" +
            "not out of any desire for good or evil...\r\n" +
            "but just because you think you can.\r\n" +
            "and because you \"can\"...\r\n" +
            "... you \"have to.\"\r\n" +
            "but now, you've reached the end.\r\n" +
            "there is nothing left for you now.\r\n" +
            "so, uh, in my personal opinion...\r\n" +
            "the most \"determined\" thing you can do here?\r\n" +
            "is to, uh, completely give up.\r\n" +
            "and... (yawn) do literally anything else.",
            "Heh, didja really think you would be able to-",
            "...\r\n" +
            "...\r\n" +
            "...\r\n" +
            "so...\r\n" +
            "guess that's it, huh?\r\n" +
            "...\r\n" +
            "just...\r\n" +
            "don't say i didn't warn you.\r\n" +
            "welp.\r\n" +
            "i'm going to grillby's.\r\n" +
            "papyrus, do you want anything?"
        };

        private int _index = 0;

        /// <summary>
        /// 
        /// </summary>
        public string CurrentDialogue => _index < _dialogue.Count ? _dialogue[_index] : string.Empty;

        /// <summary>
        /// checks for more dialogue lines
        /// </summary>
        public bool HasMoreDialogue => _index < _dialogue.Count - 1;

        /// <summary>
        /// gets the next dialogue line
        /// </summary>
        /// <returns></returns>
        public string NextDialogue()
        {
            if (HasMoreDialogue)
            {
                _index++;
                return _dialogue[_index];
            }
            return string.Empty;
        }

        /// <summary>
        /// resets sans's dialogue to the beginning
        /// </summary>
        public void Reset()
        {
            _index = 0;
        }
    }
}
