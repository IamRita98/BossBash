using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public static class TypingConfig
{
    public static List<TypingLine> GetTypingConfig(string scenario)
    {
        switch (scenario)
        {
            case "LevelOne":
                List<TypingLine>  LevelOneConfig = new List<TypingLine>();
                LevelOneConfig.Add(new TypingLine(entity: "Enemy", textToType: "You are coming in late again? This is the fifth time this week. We could have you fired for this.", timeLimitSeconds: -1));
                LevelOneConfig.Add(new TypingLine(entity: "Player", textToType: "Fired?", timeLimitSeconds: -1));
                LevelOneConfig.Add(new TypingLine(entity: "Enemy", textToType: "Yes, fired. Gone, done, finished. Either shape up or leave!", timeLimitSeconds: -1));
                LevelOneConfig.Add(new TypingLine(entity: "Player", textToType: "Heh, well, I guess I can reveal my plan then. I've been late because I’ve been gathering evidence. This corporation is corrupt all the way up to the top. And now, I’m going to challenge you to a type-off to claim my place at its head.", timeLimitSeconds: -1));
                LevelOneConfig.Add(new TypingLine(entity: "Enemy", textToType: "Wh-What!? A type-off? Are you insane? This isn't a joke! A type-off is a serious thing! Just get back to your desk and get to work and I won't take this infraction any further!", timeLimitSeconds: -1));
                LevelOneConfig.Add(new TypingLine(entity: "Player", textToType: "No", timeLimitSeconds: -1));
                LevelOneConfig.Add(new TypingLine(entity: "Enemy", textToType: "Ok then, a type-off it is. You're a terrible employee! I've kept you trapped in your position for years, hoping that one day you’d quit on your own so that I didn’t have to deal with you anymore! " +
                    "Now you've gone ahead and saved me the trouble of having to fire you by challenging me to this type-off. And once this challenge is over, you’re going to be banished to the typing dimension! Fool!", timeLimitSeconds: -1));
                LevelOneConfig.Add(new TypingLine(entity: "Player", textToType: "Your words are too simple to type. What is this, a third-grade reading level?", timeLimitSeconds: -1));
                LevelOneConfig.Add(new TypingLine(entity: "Enemy", textToType: "Guh! You can’t be serious! You defeated that entire paragraph? Those were some of my strongest words… Fine, maybe I can't defeat you." +
                    "But this corporation isn't finished until you can take down the CEO. I'll give you the key, but know that if you go up that elevator, you'll never come back down.", timeLimitSeconds: -1));
                return LevelOneConfig;
            case "LevelTwo":
                List<TypingLine> LevelTwoConfig = new List<TypingLine>();
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "What fool dares come before the Tribunal of Executives to challenge me to a type-off?", timeLimitSeconds: -1));
                LevelTwoConfig.Add(new TypingLine(entity: "Player", textToType: "Me!", timeLimitSeconds: -1));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "Tyler Perkins? Accounting's number one imbecile? The Hominidae incapable of refilling our caffeine apparatus? Is this a practical joke?", timeLimitSeconds: -1));
                LevelTwoConfig.Add(new TypingLine(entity: "Player", textToType: "Me!", timeLimitSeconds: -1));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "You're serious... Well then, just try to out-type this!", timeLimitSeconds: -1));
                LevelTwoConfig.Add(new TypingLine(entity: "Enemy", textToType: "The Word Corporation is displeased to hear of your recent dissatisfaction within our company. " +
                    "Word Corporation is not liable for any mental, physical, or psychic Infractions against your person during your employment, you have agreed to sign away these rights in your onboarding contract when joining our company.", timeLimitSeconds: -1));
                return LevelTwoConfig;
            case "LevelThree":
                List<TypingLine> LevelThreeConfig = new List<TypingLine>();
                LevelThreeConfig.Add(new TypingLine(entity: "Enemy", textToType: "You are coming in late again? This is the fifth time this week. We could have you fired for this.", timeLimitSeconds: -1));
                return LevelThreeConfig;
            default:
                return new List<TypingLine>();
        }
    }
}
