using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Backgrounds
{
    public class Background
    {
        public HashSet<string> SkillProficiencies { get; set; } = new HashSet<string>();
        public HashSet<string> ToolProficiencies { get; set; } = new HashSet<string>();
        public HashSet<string> Languages { get; set; } = new HashSet<string>();
        public List<string> Equipment { get; set; } = new List<string>();
        public int GP { get; set; }
        public string Feature { get; set; }
        public string[] PersonalityTrait { get; set; } = new string[8];
        public string[] Ideal { get; set; } = new string[6];
        public string[] Bond { get; set; } = new string[6];
        public string[] Flaw { get; set; } = new string[6];
        public string[] FavoriteScam { get; set; } = new string[6];
        public string[] Specialty { get; protected set; } = new string[8];
        public string[] Routine { get; protected set; } = new string[10];
        public string[] DefiningEvent { get; protected set; } = new string[10];
        public string[] GuildBusiness { get; protected set; } = new string[20];
        public string[] LifeOfSeclusion { get; protected set; } = new string[8];
        public string[] Origin { get; protected set; } = new string[10];
        public static Background NewBackground(string backgroundString)
        {
            var result = new Background();

            switch (backgroundString)
            {
                case "Acolyte":
                    result = Acolyte();
                    break;
                case "Charltan":
                    result = Charltan();
                    break;
                case "Criminal":
                    result = Criminal();
                    break;
                case "Entertainer":
                    result = Entertainer();
                    break;
                case "Folk Hero":
                    result = FolkHero();
                    break;
                case "Guild Artisan":
                    result = GuildArtisan();
                    break;
                case "Hermit":
                    result = Hermit();
                    break;
                case "Noble":
                    result = Noble();
                    break;
                case "Outlander":
                    result = Outlander();
                    break;
                case "Sage":
                    result = Sage();
                    break;
                case "Sailor":
                    result = Sailor();
                    break;
                case "Soldier":
                    result = Soldier();
                    break;
                case "Urchin":
                    result = Urchin();
                    break;
            }

            return result;
        }
        public static Background Acolyte()
        {
            Background result = new Background();

            result.SkillProficiencies.Add("Insight");
            result.SkillProficiencies.Add("Religion");
            result.Languages.Add("Choice");
            result.Languages.Add("Choice2");
            result.Equipment.Add("Prayer robes");
            result.Equipment.Add("Holy symbol");
            result.Equipment.Add("Prayer book or Prayer wheel");
            result.Equipment.Add("5 sticks of incense");
            result.Equipment.Add("Vestments");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 15;
            result.Feature = "Shelter of the Faithful: you can perform religious ceremonies of your deity, you and your party can expect to " +
                "\nreceive free healing and care at a temple, shrine or other established presence, but you must provide the spell" +
                "\ncomponents. You (and only you) will be supported for a modest lifestyle. You have a residence at your home temple," +
                "\nand the priests there will provide you assistance as long as it isn't hazardous.";
            result.PersonalityTrait[0] = "I idolize a particular hero of my faith, and constantly refer to that person’s deeds and example.";
            result.PersonalityTrait[1] = "I can find common ground between the fiercest enemies, empathizing with them and always working toward peace.";
            result.PersonalityTrait[2] = "I see omens in every event and action. The gods try to speak to us, we just need to listen.";
            result.PersonalityTrait[3] = "Nothing can shake my optimistic attitude.";
            result.PersonalityTrait[4] = "I quote(or misquote) sacred texts and proverbs in almost every situation.";
            result.PersonalityTrait[5] = "I am tolerant(or intolerant) of other faiths and respect (or condemn) the worship of other gods.";
            result.PersonalityTrait[6] = "I've enjoyed fine food, drink, and high society among my temple’s elite. Rough living grates on me.";
            result.PersonalityTrait[7] = "I’ve spent so long in the temple that I have little practical experience";
            result.Ideal[0] = "Tradition. The ancient traditions of worship and sacrifice must be preserved and upheld. (Lawful)";
            result.Ideal[1] = "Charity. I always try to help those in need, no matter what the personal cost. (Good)";
            result.Ideal[2] = "Change. We must help bring about the changes the gods are constantly working in the world. (Chaotic)";
            result.Ideal[3] = "Power. I hope to one day rise to the top of my faith’s religious hierarchy. (Lawful)";
            result.Ideal[4] = "Faith. I trust that my deity will guide me, I have faith that if I work hard, things will go well. (Lawful)";
            result.Ideal[5] = "Aspiration. I seek to prove myself worthy of my god’s favor by matching my actions to their teachings. (Any)";
            result.Bond[0] = "I would die to recover an ancient relic of my faith that was lost long ago.";
            result.Bond[1] = "I will someday get revenge on the corrupt temple hierarchy who branded me a heretic.";
            result.Bond[2] = "I owe my life to the priest who took me in when my parents died.";
            result.Bond[3] = "Everything I do is for the common people.";
            result.Bond[4] = "I will do anything to protect the temple where I served.";
            result.Bond[5] = "I seek to preserve a sacred text that my enemies consider heretical and seek to destroy.";
            result.Flaw[0] = "I judge others harshly, and myself even more severely.";
            result.Flaw[1] = "I put too much trust in those who wield power within my temple’s hierarchy.";
            result.Flaw[2] = "My piety sometimes leads me to blindly trust those that profess faith in my god.";
            result.Flaw[3] = "I am inflexible in my thinking.";
            result.Flaw[4] = "I am suspicious of strangers and expect the worst of them.";
            result.Flaw[5] = "Once I pick a goal, I become obsessed with it to the detriment of everything else in my life.";

            return result;
        }
        public static Background Charltan()
        {
            Background result = new Background();

            result.SkillProficiencies.Add("Deception");
            result.SkillProficiencies.Add("Sleight of Hand");
            result.ToolProficiencies.Add("Disguise Kit");
            result.ToolProficiencies.Add("Forgery Kit");
            result.Equipment.Add("Fine clothes");
            result.Equipment.Add("Disguise Kit");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 15;
            result.Feature = "False Identity: you have documentation, established acquaintances, and disguises for a second persona." +
                "\nYou can also forge documents as long as you've seen as example of that kind of document/handwriting.";
            result.FavoriteScam[0] = "I cheat at games of chance.";
            result.FavoriteScam[1] = "I shave coins or forge documents.";
            result.FavoriteScam[2] = "I insinuate myself into people’s lives to prey on their weakness and secure their fortunes.";
            result.FavoriteScam[3] = "I put on new identities like clothes.";
            result.FavoriteScam[4] = "I run sleight of hand cons on street corners.";
            result.FavoriteScam[5] = "I convince people that worthless junk is worth their hard-earned money.";
            result.PersonalityTrait[0] = "I fall in and out of love easily, and am always pursuing someone.";
            result.PersonalityTrait[1] = "I have a joke for every occasion, especially occasions where humor is inappropriate.";
            result.PersonalityTrait[2] = "Flattery is my preferred trick for getting what I want.";
            result.PersonalityTrait[3] = "I’m a born gambler who can't resist taking a risk for a potential payoff.";
            result.PersonalityTrait[4] = "I lie about almost everything, even when there’s no good reason to.";
            result.PersonalityTrait[5] = "Sarcasm and insults are my weapons of choice.";
            result.PersonalityTrait[6] = "I keep multiple holy symbols on me and invoke whatever deity might come in useful at any given moment.";
            result.PersonalityTrait[7] = "I pocket anything I see that might have some value.";
            result.Ideal[0] = "Independence. I am a free spirit - no one tells me what to do. (Chaotic)";
            result.Ideal[1] = "Fairness. I never target people who can’t afford to lose a few coins. (Lawful)";
            result.Ideal[2] = "Charity. I distribute the money I acquire to the people who really need it. (Good)";
            result.Ideal[3] = "Creativity. I never run the same con twice. (Chaotic)";
            result.Ideal[4] = "Friendship. Material goods come and go.Bonds of friendship last forever. (Good)";
            result.Ideal[5] = "Aspiration. I’m determined to make something of myself. (Any)";
            result.Bond[0] = "I fleeced the wrong person and must work to ensure that person never crosses paths with me or my loved ones.";
            result.Bond[1] = "I owe everything to my mentor - a horrible person who’s probably rotting in jail somewhere.";
            result.Bond[2] = "Somewhere out there, I have a child who doesn’t know me. I’m making the world better for him or her.";
            result.Bond[3] = "I come from a noble family, and one day I’ll reclaim my lands and title from those who stole them from me.";
            result.Bond[4] = "A powerful person killed someone I love.Some day soon, I’ll have my revenge.";
            result.Bond[5] = "I swindled/ruined someone who didn’t deserve it. I seek to atone for misdeeds, I might never forgive myself.";
            result.Flaw[0] = "I can’t resist a pretty face.";
            result.Flaw[1] = "I'm always in debt. I spend my ill-gotten gains on decadent luxuries faster than I bring them in...";
            result.Flaw[2] = "I’m convinced that no one could ever fool me the way I fool others.";
            result.Flaw[3] = "I’m too greedy for my own good.I can’t resist taking a risk if there’s money involved.";
            result.Flaw[4] = "I can’t resist swindling people who are more powerful than me.";
            result.Flaw[5] = "I hate to admit it/will hate myself for it, but I'll run to preserve my own hide if the going gets tough.";

            return result;
        }
        public static Background Criminal()
        {
            Background result = new Background();

            result.SkillProficiencies.Add("Deception");
            result.SkillProficiencies.Add("Stealth");
            result.ToolProficiencies.Add("Gaming set");
            result.ToolProficiencies.Add("Thieves' Tools");
            result.Equipment.Add("Dark common clothes with a hood");
            result.Equipment.Add("Crowbar");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 15;
            result.Feature = "Criminal Contact: you have a reliable contact who acts as your liason to a criminal network." +
                "\nYou can get them messages over long distances because you know local/corrupt individuals who can deliver the messages.";
            result.PersonalityTrait[0] = "I always have a plan for what to do when things go wrong.";
            result.Specialty[0] = "Blackmailer";
            result.Specialty[1] = "Burglar";
            result.Specialty[2] = "Enforcer";
            result.Specialty[3] = "Fence";
            result.Specialty[4] = "Highway robber";
            result.Specialty[5] = "Hired killer";
            result.Specialty[6] = "Pickpocket";
            result.Specialty[7] = "Smuggler";
            result.PersonalityTrait[0] = "I always have a plan for what to do when things go wrong.";
            result.PersonalityTrait[1] = "I am always calm, no matter what the situation. I never raise my voice or let my emotions control me.";
            result.PersonalityTrait[2] = "The first thing I do in a new place is notice everything valuable (or where such things could be hidden).";
            result.PersonalityTrait[3] = "I would rather make a new friend than a new enemy.";
            result.PersonalityTrait[4] = "I am incredibly slow to trust. Those who seem the fairest often have the most to hide.";
            result.PersonalityTrait[5] = "I don't pay attention to the risks in a situation. Never tell me the odds.";
            result.PersonalityTrait[6] = "The best way to get me to do something is to tell me I can't do it.";
            result.PersonalityTrait[7] = "I blow up at the slightest insult.";
            result.Ideal[0] = "Honor. I don’t steal from others in the trade. (Lawful)";
            result.Ideal[1] = "Freedom. Chains are meant to be broken, as are those who would forge them. (Chaotic)";
            result.Ideal[2] = "Charity. I steal from the wealthy so that I can help people in need. (Good)";
            result.Ideal[3] = "Greed. I will do whatever it takes to become wealthy. (Evil)";
            result.Ideal[4] = "People. I’m loyal to my friends, not ideals. Everyone else can go down the Styx for all I care. (Neutral)";
            result.Ideal[5] = "Redemption. There’s a spark of good in everyone. (Good)";
            result.Bond[0] = "I’m trying to pay off an old debt I owe to a generous benefactor.";
            result.Bond[1] = "My ill-gotten gains go to support my family.";
            result.Bond[2] = "Something important was taken from me, and I aim to steal it back.";
            result.Bond[3] = "I will become the greatest thief that ever lived.";
            result.Bond[4] = "I’m guilty of a terrible crime. I hope I can redeem myself for it.";
            result.Bond[5] = "Someone I loved died because of a mistake I made. That will never happen again.";
            result.Flaw[0] = "When I see something valuable, I can’t think about anything but how to steal it.";
            result.Flaw[1] = "When faced with a choice between money and my friends, I usually choose the money.";
            result.Flaw[2] = "If there’s a plan, I’ll forget it.If I don’t forget it, I’ll ignore it.";
            result.Flaw[3] = "I have a “tell” that reveals when I'm lying.";
            result.Flaw[4] = "I turn tail and run when things look bad.";
            result.Flaw[5] = "An innocent person is in prison for a crime that I committed.I’m okay with that.";

            return result;
        }
        public static Background Entertainer()
        {
            Background result = new Background();

            Console.WriteLine("You have the favor of an admirer. Pick an object to represent that by entering the number next to it.");
            CLIHelper.Print3Choices("Love letter from an admirer", "Lock of hair from an admirer", "Trinket from an admirer");
            int choice = CLIHelper.GetNumberInRange(1, 3);

            if (choice == 1)
            {
                result.Equipment.Add("Love letter from an admirer");
            }
            else if (choice == 2)
            {
                result.Equipment.Add("Lock of hair from an admirer");
            }
            else
            {
                result.Equipment.Add("Trinket from an admirer");
            }

            result.SkillProficiencies.Add("Acrobatics");
            result.SkillProficiencies.Add("Performance");
            result.ToolProficiencies.Add("Disguise Kit");
            result.ToolProficiencies.Add("Musical instrument");
            result.Equipment.Add("Costume");
            result.Equipment.Add("Musical instrument");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 15;
            result.Feature = "By Popular Demand: you can always find a place to perform, usually an inn or a tavern, but it could be a circus," +
                "\ntheater or even a noble's court. The place you perform will provide you with free lodging and a modest/comfortable" +
                "\nlevel of food (as long as you perform each night). Your performances also make you a local figure - strangers recognize" +
                "\nyou and usually like you.";
            result.Routine[0] = "Actor";
            result.Routine[1] = "Dancer";
            result.Routine[2] = "Fire-eater";
            result.Routine[3] = "Jester";
            result.Routine[4] = "Juggler";
            result.Routine[5] = "Instrumentalist";
            result.Routine[6] = "Poet";
            result.Routine[7] = "Singer";
            result.Routine[8] = "Storyteller";
            result.Routine[9] = "Tumbler";
            result.PersonalityTrait[0] = "I know a story relevant to almost every situation.";
            result.PersonalityTrait[1] = "Whenever I come to a new place, I collect local rumors and spread gossip.";
            result.PersonalityTrait[2] = "I’m a hopeless romantic, always searching for that 'special someone.'";
            result.PersonalityTrait[3] = "Nobody stays angry at me or around me for long, since I can defuse any amount of tension.";
            result.PersonalityTrait[4] = "I love a good insult, even one directed at me.";
            result.PersonalityTrait[5] = "I get bitter if I’m not the center of attention.";
            result.PersonalityTrait[6] = "I’ll settle for nothing less than perfection.";
            result.PersonalityTrait[7] = "I change my mood or my mind as quickly as I change key in a song.";
            result.Ideal[0] = "Beauty. When I perform, I make the world better than it was. (Good)";
            result.Ideal[1] = "Tradition. Stories/legends/songs of the past must never be forgotten, they teach us who we are. (Lawful)";
            result.Ideal[2] = "Creativity. The world is in need of new ideas and bold action. (Chaotic)";
            result.Ideal[3] = "Greed. I’m only in it for the money and fame. (Evil)";
            result.Ideal[4] = "People. I like seeing the smiles on people’s faces when I perform.That’s all that matters. (Neutral)";
            result.Ideal[5] = "Honesty. Art should reflect the soul; it should come from within and reveal who we really are. (Any)";
            result.Bond[0] = "My instrument is my most treasured possession, and it reminds me of someone I love.";
            result.Bond[1] = "Someone stole my precious instrument, and someday I’ll get it back.";
            result.Bond[2] = "I want to be famous, whatever it takes.";
            result.Bond[3] = "I idolize a hero of the old tales and measure my deeds against that person’s.";
            result.Bond[4] = "I will do anything to prove myself superior to my hated rival.";
            result.Bond[5] = "I would do anything for the other members of my old troupe.";
            result.Flaw[0] = "I’ll do anything to win fame and renown.";
            result.Flaw[1] = "I’m a sucker for a pretty face.";
            result.Flaw[2] = "A scandal prevents me from ever going home again. That kind of trouble seems to follow me around.";
            result.Flaw[3] = "I once satirized a noble who still wants my head. It was a mistake that I will likely repeat.";
            result.Flaw[4] = "I have trouble keeping my true feelings hidden. My sharp tongue lands me in trouble.";
            result.Flaw[5] = "Despite my best efforts, I am unreliable to my friends.";

            return result;
        }
        public static Background FolkHero()
        {
            Background result = new Background();

            result.SkillProficiencies.Add("Animal Handling");
            result.SkillProficiencies.Add("Survival");
            result.ToolProficiencies.Add("Artisan's Tools");
            result.ToolProficiencies.Add("Vehicles(land)");
            result.Equipment.Add("Common clothes");
            result.Equipment.Add("Artisan's Tools");
            result.Equipment.Add("Shovel");
            result.Equipment.Add("Iron pot");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 10;
            result.Feature = "Rustic Hospitality: common folk will give you a place to hide, rest, or recuperate unless you've shown you're a danger." +
                "\nThey will shield you from the law or anyone searching from you, but they will not risk their lives.";
            result.DefiningEvent[0] = "I stood up to a tyrant’s agents.";
            result.DefiningEvent[1] = "I saved people during a natural disaster.";
            result.DefiningEvent[2] = "I stood alone against a terrible monster.";
            result.DefiningEvent[3] = "I stole from a corrupt merchant to help the poor.";
            result.DefiningEvent[4] = "I led a militia to fight off an invading army.";
            result.DefiningEvent[5] = "I broke into a tyrant’s castle and stole weapons to arm the people.";
            result.DefiningEvent[6] = "I trained the peasantry to use farm implements as weapons against a tyrant’s soldiers.";
            result.DefiningEvent[7] = "A lord rescinded an unpopular decree after I led a symbolic act of protect against it.";
            result.DefiningEvent[8] = "A celestial, fey, or similar creature gave me a blessing or revealed my secret origin.";
            result.DefiningEvent[9] = "Recruited into a lord’s army, I rose to leadership and was commended for my heroism.";
            result.PersonalityTrait[0] = "I judge people by their actions, not their words.";
            result.PersonalityTrait[1] = "If someone is in trouble, I’m always ready to lend help.";
            result.PersonalityTrait[2] = "When I set my mind to something, I follow through no matter what gets in my way.";
            result.PersonalityTrait[3] = "I have a strong sense of fair play and always try to find the most equitable solution to arguments.";
            result.PersonalityTrait[4] = "I’m confident in my own abilities and do what I can to instill confidence in others.";
            result.PersonalityTrait[5] = "Thinking is for other people. I prefer action.";
            result.PersonalityTrait[6] = "I misuse long words in an attempt to sound smarter.";
            result.PersonalityTrait[7] = "I get bored easily.When am I going to get on with my destiny?";
            result.Ideal[0] = "Respect. People deserve to be treated with dignity and respect. (Good)";
            result.Ideal[1] = "Fairness. No one should get preferential treatment before the law, and no one is above the law. (Lawful)";
            result.Ideal[2] = "Freedom. Tyrants must not be allowed to oppress the people. (Chaotic)";
            result.Ideal[3] = "Might. If I become strong, I can take what I want - what I deserve. (Evil)";
            result.Ideal[4] = "Sincerity. There’s no good in pretending to be something I’m not. (Neutral)";
            result.Ideal[5] = "Destiny. Nothing and no one can steer me away from my higher calling. (Any)";
            result.Bond[0] = "I have a family, but I have no idea where they are.One day, I hope to see them again.";
            result.Bond[1] = "I worked the land, I love the land, and I will protect the land.";
            result.Bond[2] = "A proud noble once gave me a horrible beating, and I will take my revenge on any bully I encounter.";
            result.Bond[3] = "My tools are symbols of my past life, and I carry them so that I will never forget my roots.";
            result.Bond[4] = "I protect those who cannot protect themselves.";
            result.Bond[5] = "I wish my childhood sweetheart had come with me to pursue my destiny.";
            result.Flaw[0] = "The tyrant who rules my land will stop at nothing to see me killed.";
            result.Flaw[1] = "I’m convinced of the significance of my destiny, and blind to my shortcomings and the risk of failure.";
            result.Flaw[2] = "The people who knew me when I was young know my shameful secret, so I can never go home again.";
            result.Flaw[3] = "I have a weakness for the vices of the city, especially hard drink.";
            result.Flaw[4] = "Secretly, I believe that things would be better if I were a tyrant lording over the land.";
            result.Flaw[5] = "I have trouble trusting in my allies.";

            return result;
        }

        public static Background GuildArtisan()
        {
            Background result = new Background();

            result.SkillProficiencies.Add("Insight");
            result.SkillProficiencies.Add("Persuasion");
            result.ToolProficiencies.Add("Artisan's Tools");
            result.Languages.Add("Choice");
            result.Equipment.Add("Traveler's clothes");
            result.Equipment.Add("Artisan's Tools,");
            result.Equipment.Add("Letter of introduction from the guild");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 15;
            result.Feature = "Guild Membership: guild members will provide yu with food and lodging if necessary (they'll also pay for your funeral" +
                "\nif necessary). The guild hall offers a place for you to meet others in your profession, potential patrons, allies, or" +
                "\nhirelings. Guilds wield tremendous political power - if accused of a crime, they will support you if a good case can be" +
                "\nmade or if the crime is justifiable. You can also gain access to political figures, if you're in good standing, but a" +
                "\ndonation of money or magical items to the guild coffers might be required. You must pay the guild 5GP per month." +
                "\nIf you fall behind to can payback missed dues to remain in good standing.";
            result.GuildBusiness[0] = "Alchemists and apothecaries";
            result.GuildBusiness[1] = "Armorers, locksmiths, and finesmiths";
            result.GuildBusiness[2] = "Brewers, distillers, and vintners";
            result.GuildBusiness[3] = "Calligraphers, scribes, and scriveners";
            result.GuildBusiness[4] = "Carpenters, roofers, and plasterers";
            result.GuildBusiness[5] = "Cartographers, surveyors, and chart-makers";
            result.GuildBusiness[6] = "Cobblers and shoemakers";
            result.GuildBusiness[7] = "Cooks and bakers";
            result.GuildBusiness[8] = "Glassblowers and glaziers";
            result.GuildBusiness[9] = "Jewelers and gemcutters";
            result.GuildBusiness[10] = "Leatherworkers, skinners, and tanners";
            result.GuildBusiness[11] = "Masons and stonecutters";
            result.GuildBusiness[12] = "Painters, limners, and sign-makers";
            result.GuildBusiness[13] = "Potters and tile-makers";
            result.GuildBusiness[14] = "Shipwrights and sailmakers";
            result.GuildBusiness[15] = "Smiths and metal-forgers";
            result.GuildBusiness[16] = "Tinkers, pewterers, and casters";
            result.GuildBusiness[17] = "Wagon-makers and wheelwrights";
            result.GuildBusiness[18] = "Weavers and dyers";
            result.GuildBusiness[19] = "Woodcarvers, coopers, and bowyers";
            result.PersonalityTrait[0] = "I believe that anything worth doing is worth doing right. I can’t help it - I’m a perfectionist.";
            result.PersonalityTrait[1] = "I’m a snob who looks down on those who can’t appreciate fine art.";
            result.PersonalityTrait[2] = "I always want to know how things work and what makes people tick.";
            result.PersonalityTrait[3] = "I’m full of witty aphorisms and have a proverb for every occasion.";
            result.PersonalityTrait[4] = "I’m rude to people who lack my commitment to hard work and fair play.";
            result.PersonalityTrait[5] = "I like to talk at length about my profession.";
            result.PersonalityTrait[6] = "I don’t part with my money easily and will haggle tirelessly to get the best deal possible.";
            result.PersonalityTrait[7] = "I’m well known for my work. I'm always taken aback when people haven’t heard of me.";
            result.Ideal[0] = "Community. Everyone's duty is to strengthen the bonds of community and civilization's security. (Lawful)";
            result.Ideal[1] = "Generosity. My talents were given to me so that I could use them to benefit the world. (Good)";
            result.Ideal[2] = "Freedom. Everyone should be free to pursue his or her own livelihood. (Chaotic)";
            result.Ideal[3] = "Greed. I’m only in it for the money. (Evil)";
            result.Ideal[4] = "People. I’m committed to the people I care about, not to ideals. (Neutral)";
            result.Ideal[5] = "Aspiration. I work hard to be the best there is at my craft. (Any)";
            result.Bond[0] = "The workshop where I learned my trade is the most important place in the world to me.";
            result.Bond[1] = "I created a great work for someone, then found them unworthy of it. I’m still looking for someone worthy.";
            result.Bond[2] = "I owe my guild a great debt for forging me into the person I am today.";
            result.Bond[3] = "I pursue wealth to secure someone’s love.";
            result.Bond[4] = "One day I will return to my guild and prove that I am the greatest artisan of them all.";
            result.Bond[5] = "I will get revenge on the evil forces that destroyed my place of business and ruined my livelihood.";
            result.Flaw[0] = "I’ll do anything to get my hands on something rare or priceless.";
            result.Flaw[1] = "I’m quick to assume that someone is trying to cheat me.";
            result.Flaw[2] = "No one must ever learn that I once stole money from guild coffers.";
            result.Flaw[3] = "I’m never satisfied with what I have— I always want more.";
            result.Flaw[4] = "I would kill to acquire a noble title.";
            result.Flaw[5] = "I’m horribly jealous of anyone who can outshine my handiwork.Everywhere I go, I’m surrounded by rivals.";

            return result;
        }
        public static Background Hermit()
        {
            Background result = new Background();

            result.SkillProficiencies.Add("Medicine");
            result.SkillProficiencies.Add("Religion");
            result.ToolProficiencies.Add("Herbalism Kit");
            result.Languages.Add("Choice");
            result.Equipment.Add("Common clothes");
            result.Equipment.Add("Scroll case stuffed full of notes");
            result.Equipment.Add("Winter blanket");
            result.Equipment.Add("Herbalism Kit");
            result.GP = 5;
            result.Feature = "Discovery: your seclusion gave you access to a unique and powerful discovery. It could be: a great truth about" +
                "\nthe cosmos/deities/powerful beings/forces of nature, a site no one has ever seen, an uncovered fact that has been long" +
                "\nforgotten, an unearthered relic, etc. Work with your DM to determine the details of your discovery.";
            result.LifeOfSeclusion[0] = "I was searching for spiritual enlightenment.";
            result.LifeOfSeclusion[1] = "I was partaking of communal living in accordance with the dictates of a religious order.";
            result.LifeOfSeclusion[2] = "I was exiled for a crime I didn’t commit.";
            result.LifeOfSeclusion[3] = "I retreated from society after a life-altering event.";
            result.LifeOfSeclusion[4] = "I needed a quiet place to work on my art, literature, music, or manifesto.";
            result.LifeOfSeclusion[5] = "I needed to commune with nature, far from civilization.";
            result.LifeOfSeclusion[6] = "I was the caretaker of an ancient ruin or relic.";
            result.LifeOfSeclusion[7] = "I was a pilgrim in search of a person, place, or relic of spiritual significance.";
            result.PersonalityTrait[0] = "I’ve been isolated for so long that I rarely speak, preferring gestures and the occasional grunt.";
            result.PersonalityTrait[1] = "I am utterly serene, even in the face of disaster.";
            result.PersonalityTrait[2] = "The leader of my community had something wise to say on every topic, and I am eager to share that wisdom.";
            result.PersonalityTrait[3] = "I feel tremendous empathy for all who suffer.";
            result.PersonalityTrait[4] = "I’m oblivious to etiquette and social expectations.";
            result.PersonalityTrait[5] = "I connect everything that happens to me to a grand, cosmic plan.";
            result.PersonalityTrait[6] = "I often get lost in my own thoughts and contemplation, becoming oblivious to my surroundings.";
            result.PersonalityTrait[7] = "I am working on a grand philosophical theory and love sharing my ideas.";
            result.Ideal[0] = "Greater Good. My gifts are meant to be shared with all, not used for my own benefit. (Good)";
            result.Ideal[1] = "Logic. Emotions must not cloud our sense of what is right and true, or our logical thinking. (Lawful)";
            result.Ideal[2] = "Free Thinking. Inquiry and curiosity are the pillars of progress. (Chaotic)";
            result.Ideal[3] = "Power. Solitude and contemplation are paths toward mystical or magical power. (Evil)";
            result.Ideal[4] = "Live and Let Live. Meddling in the affairs of others only causes trouble. (Neutral)";
            result.Ideal[5] = "Self-Knowledge. If you know yourself, there’s nothing left to know. (Any)";
            result.Bond[0] = "Nothing is more important than the other members of my hermitage, order, or association.";
            result.Bond[1] = "I entered seclusion to hide from the ones who might still be hunting me. I must someday confront them.";
            result.Bond[2] = "I’m still seeking the enlightenment I pursued in my seclusion, and it still eludes me.";
            result.Bond[3] = "I entered seclusion because I loved someone I could not have.";
            result.Bond[4] = "Should my discovery come to light, it could bring ruin to the world.";
            result.Bond[5] = "My isolation gave me great insight into a great evil that only I can destroy.";
            result.Flaw[0] = "Now that I've returned to the world, I enjoy its delights a little too much.";
            result.Flaw[1] = "I harbor dark, bloodthirsty thoughts that my isolation and meditation failed to quell.";
            result.Flaw[2] = "I am dogmatic in my thoughts and philosophy.";
            result.Flaw[3] = "I let my need to win arguments overshadow friendships and harmony.";
            result.Flaw[4] = "I’d risk too much to uncover a lost bit of knowledge.";
            result.Flaw[5] = "I like keeping secrets and won’t share them with anyone.";

            return result;
        }
        public static Background Noble()
        {
            Background result = new Background();

            result.SkillProficiencies.Add("History");
            result.SkillProficiencies.Add("Persuasion");
            result.ToolProficiencies.Add("Gaming set");
            result.Languages.Add("Choice");
            result.Equipment.Add("Fine clothes");
            result.Equipment.Add("Signet ring");
            result.Equipment.Add("Scroll of pedigree");
            result.Equipment.Add("Coin purse");
            result.GP = 25;
            result.Feature = "Position of Privilege: people are inclined to think better of you, you are welcome in high society, and people assume" +
                "\nyou have the right to be wherever you are. Common folk make every effort to accomodate you and avoid your displeasure." +
                "\nOther people of high birth treat you as a member of the same social sphere." +
                "\nYou can secure an audience with a local noble if you need to.";
            result.PersonalityTrait[0] = "My eloquent flattery makes everyone I talk to feel like the most wonderful and important person in the world.";
            result.PersonalityTrait[1] = "The common folk love me for my kindness and generosity.";
            result.PersonalityTrait[2] = "No one could doubt by looking at my regal bearing that I am a cut above the unwashed masses.";
            result.PersonalityTrait[3] = "I take great pains to always look my best and follow the latest fashions.";
            result.PersonalityTrait[4] = "I don’t like to get my hands dirty, and I won’t be caught dead in unsuitable accommodations.";
            result.PersonalityTrait[5] = "Despite my noble birth, I do not place myself above other folk.We all have the same blood.";
            result.PersonalityTrait[6] = "My favor, once lost, is lost forever.";
            result.PersonalityTrait[7] = "If you do me an injury, I will crush you, ruin your name, and salt your fields.";
            result.Ideal[0] = "Respect. Respect is due to me because of my position, but all people deserve to be treated with dignity. (Good)";
            result.Ideal[1] = "Responsibility. It is everyone's duty to respect the authority of those above them. (Lawful)";
            result.Ideal[2] = "Independence. I must prove that I can handle myself without the coddling of my family. (Chaotic)";
            result.Ideal[3] = "Power. If I can attain more power, no one will tell me what to do. (Evil)";
            result.Ideal[4] = "Family. Blood runs thicker than water. (Any)";
            result.Ideal[5] = "Noble Obligation. It is my duty to protect and care for the people beneath me. (Good)";
            result.Bond[0] = "I will face any challenge to win the approval of my family.";
            result.Bond[1] = "My house’s alliance with another noble family must be sustained at all costs.";
            result.Bond[2] = "Nothing is more important than the other members of my family.";
            result.Bond[3] = "I am in love with the heir of a family that my family despises.";
            result.Bond[4] = "My loyalty to my sovereign is unwavering.";
            result.Bond[5] = "The common folk must see me as a hero of the people.";
            result.Flaw[0] = "I secretly believe that everyone is beneath me.";
            result.Flaw[1] = "I hide a truly scandalous secret that could ruin my family forever.";
            result.Flaw[2] = "I too often hear veiled insults and threats in every word addressed to me, and I’m quick to anger.";
            result.Flaw[3] = "I have an insatiable desire for carnal pleasures.";
            result.Flaw[4] = "In fact, the world does revolve around me.";
            result.Flaw[5] = "By my words and actions, I often bring shame to my family.";

            return result;
        }
        public static Background Outlander()
        {
            Background result = new Background();

            result.SkillProficiencies.Add("Athletics");
            result.SkillProficiencies.Add("Survival");
            result.ToolProficiencies.Add("Musical Instrument");
            result.Languages.Add("Choice");
            result.Equipment.Add("Traveler's clothes");
            result.Equipment.Add("Staff");
            result.Equipment.Add("Hunting trap");
            result.Equipment.Add("Trophy from a killed animal");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 10;
            result.Feature = "Wanderer: you can always recall the general layout of terrain, settlements, and other" +
                "\nfeatures around you. You can find food and fresh water for yourself and up to 5 people each day," +
                "\nas long as the land offers berries, small game, water, etc.";
            result.Origin[0] = "Forester";
            result.Origin[1] = "Trapper";
            result.Origin[2] = "Homesteader";
            result.Origin[3] = "Guide";
            result.Origin[4] = "Exile or outcast";
            result.Origin[5] = "Bounty hunter";
            result.Origin[6] = "Pilgrim";
            result.Origin[7] = "Tribal nomad";
            result.Origin[8] = "Hunter-gatherer";
            result.Origin[9] = "Tribal marauder";
            result.PersonalityTrait[0] = "I’m driven by a wanderlust that led me away from home.";
            result.PersonalityTrait[1] = "I watch over my friends as if they were a litter of newborn pups.";
            result.PersonalityTrait[2] = "I once ran 25 miles without stopping to warn to my clan of an approaching horde. I’d do it again if I had to.";
            result.PersonalityTrait[3] = "I have a lesson for every situation, drawn from observing nature.";
            result.PersonalityTrait[4] = "I place no stock in wealthy or well-mannered folk. Money and manners won’t save you from a hungry owlbear.";
            result.PersonalityTrait[5] = "I’m always picking things up, absently fiddling with them, and sometimes accidentally breaking them.";
            result.PersonalityTrait[6] = " I feel far more comfortable around animals than people.";
            result.PersonalityTrait[7] = "I was, in fact, raised by wolves.";
            result.Ideal[0] = "Change. Life is like the seasons, in constant change, and we must change with it. (Chaotic)";
            result.Ideal[1] = "Greater Good. It is each person’s responsibility to make the most happiness for the whole tribe. (Good)";
            result.Ideal[2] = "Honor. If I dishonor myself, I dishonor my whole clan. (Lawful)";
            result.Ideal[3] = "Might. The strongest are meant to rule. (Evil)";
            result.Ideal[4] = "Nature. The natural world is more important than all the constructs of civilization. (Neutral)";
            result.Ideal[5] = "Glory. I must earn glory in battle, for myself and my clan. (Any)";
            result.Bond[0] = "My family, clan, or tribe is the most important thing in my life, even when they are far from me.";
            result.Bond[1] = "An injury to the unspoiled wilderness of my home is an injury to me.";
            result.Bond[2] = "I will bring terrible wrath down on the evildoers who destroyed my homeland.";
            result.Bond[3] = "I am the last of my tribe, and it is up to me to ensure their names enter legend.";
            result.Bond[4] = "I suffer awful visions of a coming disaster and will do anything to prevent it.";
            result.Bond[5] = "It is my duty to provide children to sustain my tribe.";
            result.Flaw[0] = "I am too enamored of ale, wine, and other intoxicants.";
            result.Flaw[1] = "There’s no room for caution in a life lived to the fullest.";
            result.Flaw[2] = "I remember every insult I’ve received and nurse a silent resentment toward anyone who’s ever wronged me.";
            result.Flaw[3] = "I am slow to trust members of other races, tribes, and societies.";
            result.Flaw[4] = "Violence is my answer to almost any challenge.";
            result.Flaw[5] = "I won't save those who can’t save themselves. Nature’s way is for the strong thrive and the weak perish.";

            return result;
        }
        public static Background Sage()
        {
            Background result = new Background();

            result.SkillProficiencies.Add("Arcana");
            result.SkillProficiencies.Add("History");
            result.Languages.Add("Choice");
            result.Languages.Add("Choice2");
            result.Equipment.Add("Common clothes");
            result.Equipment.Add("Quill and ink");
            result.Equipment.Add("Small knife");
            result.Equipment.Add("Letter from a dead colleague posing an unanswered question");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 10;
            result.Feature = "Researcher: when you want to learn new lore, you usually know where to find it - whether it's" +
                "\nin a book, a sage or other creature knows it, etc. The DM may rule the knowledge is inaccessible.";
            result.Specialty[0] = "Alchemist";
            result.Specialty[1] = "Astronomer";
            result.Specialty[2] = "Discredited academic";
            result.Specialty[3] = "Librarian";
            result.Specialty[4] = "Professor";
            result.Specialty[5] = "Researcher";
            result.Specialty[6] = "Wizard’s apprentice";
            result.Specialty[7] = "Scribe";
            result.PersonalityTrait[0] = "I use polysyllabic words that convey the impression of great erudition.";
            result.PersonalityTrait[1] = "I've read every book in the world’s greatest libraries - or I like to boast that I have.";
            result.PersonalityTrait[2] = "I'm used to helping out those who aren’t as smart as I am. I patiently explain anything/everything to others.";
            result.PersonalityTrait[3] = "There’s nothing I like more than a good mystery.";
            result.PersonalityTrait[4] = "I’m willing to listen to every side of an argument before I make my own judgment.";
            result.PersonalityTrait[5] = "I... speak... slowly... when talking... to idiots... which... almost... everyone... is... compared... to me.";
            result.PersonalityTrait[6] = "I am horribly, horribly awkward in social situations.";
            result.PersonalityTrait[7] = "I’m convinced that people are always trying to steal my secrets.";
            result.Ideal[0] = "Knowledge. The path to power and self-improvement is through knowledge. (Neutral)";
            result.Ideal[1] = "Beauty. What is beautiful points us beyond itself toward what is true. (Good)";
            result.Ideal[2] = "Logic. Emotions must not cloud our logical thinking. (Lawful)";
            result.Ideal[3] = "No Limits. Nothing should fetter the infinite possibility inherent in all existence. (Chaotic)";
            result.Ideal[4] = "Power. Knowledge is the path to power and domination. (Evil)";
            result.Ideal[5] = "Self-Improvement. The goal of a life of study is the betterment of oneself. (Any)";
            result.Bond[0] = "It is my duty to protect my students.";
            result.Bond[1] = "I have an ancient text that holds terrible secrets that must not fall into the wrong hands.";
            result.Bond[2] = "I work to preserve a library, university, scriptorium, or monastery.";
            result.Bond[3] = "My life’s work is a series o f tomes related to a specific field of lore.";
            result.Bond[4] = "I've been searching my whole life for the answer to a certain question.";
            result.Bond[5] = "I sold my soul for knowledge.I hope to do great deeds and win it back.";
            result.Flaw[0] = "I am easily distracted by the promise of information.";
            result.Flaw[1] = "Most people scream and run when they see a demon. I stop and take notes on its anatomy.";
            result.Flaw[2] = "Unlocking an ancient mystery is worth the price of a civilization.";
            result.Flaw[3] = "I overlook obvious solutions in favor of complicated ones.";
            result.Flaw[4] = "I speak without really thinking through my words, invariably insulting others.";
            result.Flaw[5] = "I can’t keep a secret to save my life, or anyone else’s.";

            return result;
        }
        public static Background Sailor()
        {
            Background result = new Background();
            var luckyCharmExamples = new List<string>() { "rabbit foot", "small stone with a hole in the center", "random Trinket"};
            Console.WriteLine("Sailors get a lucky charm as a part of their equipment. Pick an option to determine it.");
            CLIHelper.Print2Choices("Pick from a list of examples.", "Leave it as 'Lucky charm'.");
            int choice = CLIHelper.GetNumberInRange(1, 2);

            if (choice == 1)
            {
                int index = CLIHelper.PrintChoices(luckyCharmExamples);
                result.Equipment.Add(luckyCharmExamples[index]);
            }
            else
            {
                result.Equipment.Add("Lucky charm");
            }

            result.SkillProficiencies.Add("Athletics");
            result.SkillProficiencies.Add("Perception");
            result.ToolProficiencies.Add("Navigator's Tools");
            result.ToolProficiencies.Add("Vehicles(water)");
            result.Equipment.Add("Common clothes");
            result.Equipment.Add("Belaying Pin(can be used as a club)");
            result.Equipment.Add("50ft of silk rope");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 10;
            result.Feature = "Ship's Passage: you can secure free passage on a sailing ship for you and your party. You won't determine the route" +
                "\nor what stops the ship will make, and the crew expects the party to assist them along the way." +
                "\nThe DM decides how long the journey takes.";
            result.PersonalityTrait[0] = "My friends know they can rely on me, no matter what.";
            result.PersonalityTrait[1] = "I work hard so that I can play hard when the work is done.";
            result.PersonalityTrait[2] = "I enjoy sailing into new ports and making new friends over a flagon of ale.";
            result.PersonalityTrait[3] = "I stretch the truth for the sake of a good story.";
            result.PersonalityTrait[4] = "To me, a tavern brawl is a nice way to get to know a new city.";
            result.PersonalityTrait[5] = "I never pass up a friendly wager.";
            result.PersonalityTrait[6] = "My language is as foul as an otyugh nest.";
            result.PersonalityTrait[7] = "I like a job well done, especially if I can convince someone else to do it.";
            result.Ideal[0] = "Respect. The thing that keeps a ship together is mutual respect between captain and crew. (Good)";
            result.Ideal[1] = "Fairness. We all do the work, so we all share in the rewards. (Lawful)";
            result.Ideal[2] = "Freedom. The sea is freedom—the freedom to go anywhere and do anything. (Chaotic)";
            result.Ideal[3] = "Mastery. I’m a predator, and the other ships on the sea are my prey. (Evil)";
            result.Ideal[4] = "People. I’m committed to my crewmates, not to ideals. (Neutral)";
            result.Ideal[5] = "Aspiration. Someday I’ll own my own ship and chart my own destiny. (Any)";
            result.Bond[0] = "I’m loyal to my captain first, everything else second.";
            result.Bond[1] = "The ship is most important—crewmates and captains come and go.";
            result.Bond[2] = "I’ll always remember my first ship.";
            result.Bond[3] = "In a harbor town, I have a paramour whose eyes nearly stole me from the sea.";
            result.Bond[4] = "I was cheated out of my fair share of the profits, and I want to get my due.";
            result.Bond[5] = "Ruthless pirates murdered my crewmates, plundered our ship, and left me to die. Vengeance will be mine.";
            result.Flaw[0] = "I follow orders, even if I think they’re wrong.";
            result.Flaw[1] = "I’ll say anything to avoid having to do extra work.";
            result.Flaw[2] = "Once someone questions my courage, I never back down no matter how dangerous the situation.";
            result.Flaw[3] = "Once I start drinking, it’s hard for me to stop.";
            result.Flaw[4] = "I can’t help but pocket loose coins and other trinkets I come across.";
            result.Flaw[5] = "My pride will probably lead to my destruction.";

            return result;
        }
        public static Background Soldier()
        {
            Background result = new Background();
            Console.WriteLine("Pick 1 or 2 to add to your equipment");
            CLIHelper.Print2Choices("Bone dice", "Deck of cards");
            int gamingChoice = CLIHelper.GetNumberInRange(1, 2);

            if (gamingChoice == 1)
            {
                result.Equipment.Add("Bone dice");
            }
            else
            {
                result.Equipment.Add("Deck of cards");
            }

            var trophyExamples = new List<string>() { "Dagger", "Broken blade", "Piece of a banner" };
            Console.WriteLine("Soldiers get a trophy taken from a fallen enemy as a part of their equipment. Pick an option to determine it.");
            CLIHelper.Print3Choices("See a list of examples to pick from", "Leave it as 'Trophy taken from a fallen enemy'.", "Write-in your own trophy.");
            int trophyChoice = CLIHelper.GetNumberInRange(1, 3);

            if (trophyChoice == 1)
            {
                int index = CLIHelper.PrintChoices(trophyExamples);
                string trophy = trophyExamples[index];
                result.Equipment.Add(trophy + " from a fallen enemy");
            }
            else if (trophyChoice == 2)
            {

                result.Equipment.Add("Trophy taken from a fallen enemy");
            }
            else
            {
                string trophy = Console.ReadLine().ToLower().Trim();
                trophy = CLIHelper.CapitalizeFirstLetter(trophy);
                result.Equipment.Add(trophy);
            }

            result.SkillProficiencies.Add("Athletics");
            result.SkillProficiencies.Add("Intimidation");
            result.ToolProficiencies.Add("Gaming set");
            result.ToolProficiencies.Add("Vehicles(land)");
            result.Equipment.Add("Common clothes");
            result.Equipment.Add("Insignia of rank");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 15;
            result.Feature = "Military Rank: soldiers loyal to your former military organization still recognize your authority," +
                "\ndeferring to you if they are a lower rank. You can exert your influence over other soldiers and requisition simple" +
                "\nequipment or horses for temporary use. You can usually gain access to friendly military encampments/fortresses.";
            result.Specialty[0] = "Officer";
            result.Specialty[1] = "Scout";
            result.Specialty[2] = "Infantry";
            result.Specialty[3] = "Cavalry";
            result.Specialty[4] = "Healer";
            result.Specialty[5] = "Quartermaster";
            result.Specialty[6] = "Standard bearer";
            result.Specialty[7] = "Support staff(cook, blacksmith, or the like)";
            result.PersonalityTrait[0] = "I'm always polite and respectful.";
            result.PersonalityTrait[1] = "I’m haunted by memories of war.I can’t get the images of violence out of my mind.";
            result.PersonalityTrait[2] = "I’ve lost too many friends, and I’m slow to make new ones.";
            result.PersonalityTrait[3] = "I’m full of inspiring & cautionary tales from my military experience relevant to almost every combat situation.";
            result.PersonalityTrait[4] = "I can stare down a hell hound without flinching.";
            result.PersonalityTrait[5] = "I enjoy being strong and like breaking things.";
            result.PersonalityTrait[6] = "I have a crude sense of humor.";
            result.PersonalityTrait[7] = "I face problems head-on.A simple, direct solution is the best path to success.";
            result.Ideal[0] = "Greater Good. Our lot is to lay down our lives in defense of others. (Good)";
            result.Ideal[1] = "Responsibility. I do what I must and obey just authority. (Lawful)";
            result.Ideal[2] = "Independence. When people follow orders blindly, they embrace a kind of tyranny. (Chaotic)";
            result.Ideal[3] = "Might. In life as in war, the stronger force wins. (Evil)";
            result.Ideal[4] = "Live and Let Live. Ideals aren’t worth killing over or going to war for. (Neutral)";
            result.Ideal[5] = "Nation. My city, nation, or people are all that matter. (Any)";
            result.Bond[0] = "I would still lay down my life for the people I served with.";
            result.Bond[1] = "Someone saved my life on the battlefield.To this day, I will never leave a friend behind.";
            result.Bond[2] = "My honor is my life.";
            result.Bond[3] = "I’ll never forget the crushing defeat my company suffered or the enemies who dealt it.";
            result.Bond[4] = "Those who fight beside me are those worth dying for.";
            result.Bond[5] = "I fight for those who cannot fight for themselves.";
            result.Flaw[0] = "The monstrous enemy we faced in battle still leaves me quivering with fear.";
            result.Flaw[1] = "I have little respect for anyone who is not a proven warrior.";
            result.Flaw[2] = "I made a terrible mistake in battle cost many lives - and I would do anything to keep that mistake secret.";
            result.Flaw[3] = "My hatred of my enemies is blind and unreasoning.";
            result.Flaw[4] = "I obey the law, even if the law causes misery.";
            result.Flaw[5] = "I’d rather eat my armor than admit when I’m wrong.";

            return result;
        }
        public static Background Urchin()
        {
            Background result = new Background();

            result.SkillProficiencies.Add("Sleight of Hand");
            result.SkillProficiencies.Add("Stealth");
            result.ToolProficiencies.Add("Disguise Kit");
            result.ToolProficiencies.Add("Thieves' Tools");
            result.Equipment.Add("Common clothes");
            result.Equipment.Add("Small knife");
            result.Equipment.Add("Map of your home city");
            result.Equipment.Add("Pet mouse");
            result.Equipment.Add("Token to remember your parents by");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 15;
            result.Feature = "City Secrets: you know secret passages through the urban sprawl. Outside of combat, you can travel through any two" +
                "\nlocations in the city twice as fast as your speed normally allows.";
            result.PersonalityTrait[0] = "I hide scraps of food and trinkets away in my pockets.";
            result.PersonalityTrait[1] = "I ask a lot of questions.";
            result.PersonalityTrait[2] = "I like to squeeze into small places where no one else can get to me.";
            result.PersonalityTrait[3] = "I sleep with my back to a wall or tree, with everything I own wrapped in a bundle in my arms.";
            result.PersonalityTrait[4] = "I eat like a pig and have bad manners.";
            result.PersonalityTrait[5] = "I think anyone who’s nice to me is hiding evil intent.";
            result.PersonalityTrait[6] = "I don’t like to bathe.";
            result.PersonalityTrait[7] = "I bluntly say what other people are hinting at or hiding.";
            result.Ideal[0] = "Respect. All people, rich or poor, deserve respect. (Good)";
            result.Ideal[1] = "Community. We have to take care of each other, because no one else is going to do it. (Lawful)";
            result.Ideal[2] = "Change. The low are lifted up, the high & mighty are brought down. Such is the nature of life. (Chaotic)";
            result.Ideal[3] = "Retribution. The rich need to be shown what life and death are like in the gutters. (Evil)";
            result.Ideal[4] = "People. I help the people who help me - that’s what keeps us alive. (Neutral)";
            result.Ideal[5] = "Aspiration. I'm going to prove that I'm worthy of a better life.";
            result.Bond[0] = "My town or city is my home, and I’ll fight to defend it.";
            result.Bond[1] = "I sponsor an orphanage to keep others from enduring what I was forced to endure.";
            result.Bond[2] = "I owe my survival to another urchin who taught me to live on the streets.";
            result.Bond[3] = "I owe a debt I can never repay to the person who took pity on me.";
            result.Bond[4] = "I escaped my life of poverty by robbing an important person, and I’m wanted for it.";
            result.Bond[5] = "No one else should have to endure the hardships I’ve been through.";
            result.Flaw[0] = "If I'm outnumbered, I will run away from a fight.";
            result.Flaw[1] = "Gold seems like a lot of money to me, and I’ll do just about anything for more of it.";
            result.Flaw[2] = "I will never fully trust anyone other than myself.";
            result.Flaw[3] = "I’d rather kill someone in their sleep then fight fair.";
            result.Flaw[4] = "It’s not stealing if I need it more than someone else.";
            result.Flaw[5] = "People who can't take care of themselves get what they deserve.";

            return result;
        }
    }
}
