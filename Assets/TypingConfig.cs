using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public static class TypingConfig
{
    public static List<TypingLine> GetTypingConfig(string scenario)
    {
        switch (scenario)
        {
            case "LevelOne":
                List<TypingLine>  LevelOneConfig = new List<TypingLine>();
                LevelOneConfig.Add(new TypingLine(entity: "Enemy", textToType: "You are coming in late again? This is the fifth time this week. We could have you fired for this."));
                LevelOneConfig.Add(new TypingLine(entity: "Player", textToType: "Fired?"));
                LevelOneConfig.Add(new TypingLine(entity: "Enemy", textToType: "Yes, fired. Gone, done, finished. Either shape up or leave!"));
                LevelOneConfig.Add(new TypingLine(entity: "Player", textToType: "Heh, well, I guess I can reveal my plan then. I've been late because I’ve been gathering evidence. This corporation is corrupt all the way up to the top. And now, I’m going to challenge you to a type-off to claim my place at its head."));
                LevelOneConfig.Add(new TypingLine(entity: "Enemy", textToType: "Wh-What!? A type-off? Are you insane? This isn't a joke! A type-off is a serious thing! Just get back to your desk and get to work and I won't take this infraction any further!"));
                LevelOneConfig.Add(new TypingLine(entity: "Player", textToType: "No"));
                LevelOneConfig.Add(new TypingLine(entity: "Enemy", textToType: "Ok then, a type-off it is. You're a terrible employee! I've kept you trapped in your position for years, hoping that one day you’d quit on your own so that I didn’t have to deal with you anymore! " +
                    "Now you've gone ahead and saved me the trouble of having to fire you by challenging me to this type-off. And once this challenge is over, you’re going to be banished to the typing dimension! Fool!"));
                LevelOneConfig.Add(new TypingLine(entity: "Player", textToType: "Your words are too simple to type. What is this, a third-grade reading level?"));
                LevelOneConfig.Add(new TypingLine(entity: "Enemy", textToType: "Guh! You can't be serious! You defeated that entire paragraph? Those were some of my strongest words... Fine, maybe I can't defeat you." +
                    "But this corporation isn't finished until you can take down the CEO. I'll give you the key, but know that if you go up that elevator, you'll never come back down."));
                return LevelOneConfig;

            case "LevelTwo":
                List<TypingLine> LevelTwoConfig = new List<TypingLine>();
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "What fool dares come before the Tribunal of Executives to challenge me to a type-off?", timeAllowed: 2.0));
                LevelTwoConfig.Add(new TypingLine(entity: "Player", textToType: "Me!"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "Tyler Perkins? Accounting's number one imbecile? The Hominidae incapable of refilling our caffeine apparatus? Is this a practical joke?", timeAllowed: 2.0));
                LevelTwoConfig.Add(new TypingLine(entity: "Player", textToType: "Me!"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "You're serious... Well then, just try to out-type this!", timeAllowed: 2.0));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "The Word Corporation is displeased to hear of your recent dissatisfaction within our company. " +
                    "Word Corporation is not liable for any mental, physical, or psychic Infractions against your person during your employment, you have agreed to sign away these rights in your onboarding contract when joining our company.", timeAllowed: 2.0));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "Should our employees find any pressing issues after the signing of this contract, then they may be entitled to trial by typing in order to have their grievances properly represented. However, those who fail said trial forfeit their right to type for all " +
                    "of eternity.", timeAllowed: 2.0));
                LevelTwoConfig.Add(new TypingLine(entity: "Player", textToType: "Uhm... I agree to these terms and conditions?"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "You can outype a full block, but so what? Lets see how you do against my barrage attack!", timeAllowed: 2.0));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "You're:", timeAllowed: 30.0, textGameTag: "PopoutWordPlaceholder1"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "cretinous", timeAllowed: 30.0, textGameTag: "PopoutWordPlaceholder2"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "lackluster", timeAllowed: 30.0, textGameTag: "PopoutWordPlaceholder3"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "malodorous", timeAllowed: 30.0, textGameTag: "PopoutWordPlaceholder4"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "insipid", timeAllowed: 30.0, textGameTag: "PopoutWordPlaceholder1"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "pusillanimous", timeAllowed: 30.0, textGameTag: "PopoutWordPlaceholder4"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "obstreperous", timeAllowed: 30.0, textGameTag: "PopoutWordPlaceholder2"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "elephantine", timeAllowed: 30.0, textGameTag: "PopoutWordPlaceholder3"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "reprehensible", timeAllowed: 30.0, textGameTag: "PopoutWordPlaceholder1"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "absolutely cretinous", timeAllowed: 30.0, textGameTag: "PopoutWordPlaceholder4"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "...", timeAllowed: 30.0, textGameTag: "PopoutWordPlaceholder4"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "A lil' bitch", timeAllowed: 30.0, textGameTag: "PopoutWordPlaceholder3"));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "Damn, Management warned me you were good. But you actually survived my legalese AND my barrage? Fine, but I still have one final trick up my sleeve...", timeAllowed: 30.0));
                return LevelTwoConfig;
            case "LevelThree":
                List<TypingLine> LevelThreeConfig = new List<TypingLine>();
                LevelThreeConfig.Add(new TypingLine(entity: "Enemy", textToType: "Can you withstand my strongest attack Ty? See if you can handle this! TRIVIA QUESTIONS!", timeAllowed: 2.0));
                LevelThreeConfig.Add(new TypingLine(entity: "Player", textToType: "Oh boy! Trivia!"));
                LevelThreeConfig.Add(new TypingLine(
                    entity: "Enemy", 
                    timeAllowed: 20.0,
                    triviaQuestion: "Where do you work?",
                    answerOptions: new List<string> { "Word Corp", "Typing Inc", "My Mom's House", "Writers HQ" },
                    correctAnswerIndex: 0
                ));
                LevelThreeConfig.Add(new TypingLine(
                    entity: "Enemy",
                    timeAllowed: 20.0,
                    triviaQuestion: "What is your name?",
                    answerOptions: new List<string> { "Titus Pilfer", "Tania Pisser", "Tyler Pyler", "Tyler Perkins" },
                    correctAnswerIndex: 3
                ));
                LevelThreeConfig.Add(new TypingLine(
                    entity: "Enemy",
                    timeAllowed: 20.0,
                    triviaQuestion: "What is your motive?",
                    answerOptions: new List<string> { "Become the Executive", "Lead the Council", "Become the CEO", "Destroy all corproations with a nuclear blast" },
                    correctAnswerIndex: 3
                ));
                LevelThreeConfig.Add(new TypingLine(entity: "Enemy", textToType: "Heh! That was just the warmup, too bad for you that I'm a genius with excellent memory", timeAllowed: 20.0));
                LevelThreeConfig.Add(new TypingLine(
                    entity: "Enemy",
                    timeAllowed: 20.0,
                    triviaQuestion: "Which animal has the highest blood pressure?",
                    answerOptions: new List<string> { "Elephants", "Rats", "Giraffes", "Human" },
                    correctAnswerIndex: 2
                ));
                LevelThreeConfig.Add(new TypingLine(
                    entity: "Enemy",
                    timeAllowed: 20.0,
                    triviaQuestion: "Which US state only borders one state?",
                    answerOptions: new List<string> { "Florida", "Maine", "Canada", "Wyoming" },
                    correctAnswerIndex: 1
                ));
                LevelThreeConfig.Add(new TypingLine(
                    entity: "Enemy",
                    timeAllowed: 20.0,
                    triviaQuestion: "Adult humans have how many teeth?",
                    answerOptions: new List<string> { "32", "34", "26", "35" },
                    correctAnswerIndex: 0
                ));
                LevelThreeConfig.Add(new TypingLine(entity: "Enemy", textToType: "Heh. I can see you sweating. You can't hold out like this for much longer! But neither can I..."));
                LevelThreeConfig.Add(new TypingLine(
                    entity: "Enemy",
                    timeAllowed: 20.0,
                    triviaQuestion: "Who did Michael Jackson want to be the actor for?",
                    answerOptions: new List<string> { "The Hulk", "Shazam", "Black Widow", "The Amazing Spiderman" },
                    correctAnswerIndex: 3
                ));
                LevelThreeConfig.Add(new TypingLine(
                    entity: "Enemy",
                    timeAllowed: 20.0,
                    triviaQuestion: "What is the coolest way to write code?",
                    answerOptions: new List<string> { "VSCode", "Vim", "In tears", "Classic pen and paper" },
                    correctAnswerIndex: 1
                ));
                LevelThreeConfig.Add(new TypingLine(entity: "Enemy", textToType: "Noooo! I am defeated! Damn you Tyler Perkins!", timeAllowed: 2.0));
                return LevelThreeConfig;
            default:
                return new List<TypingLine>();
        }
    }
}
