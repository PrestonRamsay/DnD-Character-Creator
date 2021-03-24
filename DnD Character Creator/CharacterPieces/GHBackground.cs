using DnD_Character_Creator.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Creator.Backgrounds
{
    public class GHBackground
    {
        public HashSet<string> SkillProficiencies { get; set; } = new HashSet<string>();
        public HashSet<string> ToolProficiencies { get; set; } = new HashSet<string>();
        public List<string> Languages { get; set; } = new List<string>();
        public List<string> Equipment { get; set; } = new List<string>();
        public string Progression { get; protected set; }
        public Dictionary<string, string> Talents { get; set; } = new Dictionary<string, string>();
        public int GP { get; set; }
        public string Feature { get; protected set; }
        public string[] PersonalityTrait { get; protected set; } = new string[8];
        public string[] Ideal { get; protected set; } = new string[6];
        public string[] Bond { get; protected set; } = new string[6];
        public string[] Flaw { get; protected set; } = new string[6];
        public string[] FavoriteScam { get; protected set; } = new string[6];
        public string[] Routine { get; protected set; } = new string[10];
        public string[] GuildBusiness { get; protected set; } = new string[20];
        public static GHBackground NewBackground(Character character)
        {
            var result = new GHBackground();


            switch (character.ChosenBackground)
            {
                case "Academic":
                    result = Academic(character);
                    break;
                case "Aristocrat":
                    result = Aristocrat(character);
                    break;
                case "Clergy":
                    result = Clergy(character);
                    break;
                case "Common Folk":
                    result = CommonFolk(character);
                    break;
                case "Criminal":
                    result = Criminal(character);
                    break;
                case "Militarist":
                    result = Militarist(character);
                    break;
                case "Outlander":
                    result = Outlander(character);
                    break;
                case "Seafarer":
                    result = Seafarer(character);
                    break;
            }

            return result;
        }
        public static Tuple<string, int> GetRank(List<string> professions, Character character)
        {
            Console.Clear();
            string pickMsg = "Pick a profession for your advanced background";
            int index = CLIHelper.PrintChoices(pickMsg, professions);
            string prof = professions[index];
            character.ChosenBackground += $"({prof})";
            Console.WriteLine("Enter your rank 1-4");
            int rank = CLIHelper.GetNumberInRange(1, 4);

            return new Tuple<string, int>( prof, rank );
        }
        public static void GetTalents(List<string> talents, Character character, int rank)
        {
            character.ProfessionDie += rank * 2;
            List<string> pickedTalents = CLIHelper.GetDictionaryOptions(Options.Talents, talents, rank, "Pick your talent now");
            foreach (var item in pickedTalents)
            {
                character.Talents.Add(item, Options.Talents[item]);
            }
            Console.Clear();
        }
        public static GHBackground Academic(Character character)
        {
            GHBackground result = new GHBackground();

            var skills = new List<string> { "Arcana", "History", "Investigation", "Medicine", "Nature", "Religion" };
            string pickMsg = $"Pick a skill from the list";
            string errorMsg = "You are already trained in that skill, pick a different skill.";
            var skill = CLIHelper.GetNew(skills, character.SkillProficiencies, pickMsg, errorMsg);
            result.SkillProficiencies.Add(skill);
            pickMsg = "Pick a standard language";
            errorMsg = "You already have that language try again";
            string lang1 = CLIHelper.GetNew(Options.StandardLanguages, character.Languages, pickMsg, errorMsg);
            result.Languages.Add(lang1);
            pickMsg = "Pick an exotic language";
            string lang2 = CLIHelper.GetNew(Options.ExoticLanguages, character.Languages, pickMsg, errorMsg);
            result.Languages.Add(lang2);
            result.Equipment.Add("Common clothes");
            result.Equipment.Add("Quill and ink");
            result.Equipment.Add("Small knife");
            result.Equipment.Add("Letter from a dead colleague posing an unanswered question");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 10;

            var professions = new List<string> { "Antiquarian", "Archivist", "Physician" };
            var tuple = GetRank(professions, character);
            string prof = tuple.Item1;
            int rank = tuple.Item2;

            if (prof == "Antiquarian")
            {
                result.SkillProficiencies.Add("History");
                result.Equipment.Add("Fine brush");
                result.Equipment.Add("Magnifying lens");
                result.Equipment.Add("Small wooden crate to store relics");
                result.Feature = "Insightful Discovery: spend 1hr, succeed on medium DC History check - uncover purposes and uses of any" +
                    "\nobject, language, cultural practice, or similiar subject (including magic items)";

                if (rank == 1)
                {
                    character.ChosenBackground += " - Museum Scholar";
                    result.Equipment.Add("Holdings: A desk at library, college, or museum with access to common resources." +
                        "\nA map or letter detailing the location of a hidden treasure or relic.");
                    result.Progression = "Acquire a small collection of antiquities that fellow antiquarians acknowledge.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Adept Collector";
                    result.Equipment.Add("Holdings: A small collection of prized antiquities and a quaint office to store/display them." +
                        "\nA hireling scholar who tends to your collection and undertakes research for you.");
                    result.Progression = "Build multiple collections dedicated to diverse subjects. You must also accommodate your collections in a suitable gallery.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Senior Professor";
                    result.Equipment.Add("Holdings: An array of prized collections - each holds secrets to lost civilizations, forgotten magics or legends." +
                        "\nAn extravagant gallery that displays and protects your collection." +
                        "\nA team of assistants and scholars who attend to the collection, conduct research, and explore the world to find more antiquities." +
                        "\nA small following within the world of academia who seek you out to discuss and learn about your collection.");
                    result.Progression = "Create a great museum - collections must be extensive spanning many subjects, time periods, and cultures." +
                        "\nYou must document a great finding about a lost subject, magic item, or tradition, and be cited in others’ work regarding the subject.";
                }
                else
                {
                    character.ChosenBackground += " - Curator";
                    result.Equipment.Add("Holdings: A great museum with collections that draw monarchs and common folk alike." +
                        "\nA dedicated team of antiquarians that manage your collection and museum, scouring the world for relics." +
                        "\nA position within a prestigious council of academics, who regard you as an esteemed peer and assist you with your studies.");
                }
            }
            else if (prof == "Archivist")
            {
                result.SkillProficiencies.Add("Investigation");
                result.Equipment.Add("Ink pen");
                result.Equipment.Add("Bottle of Ink");
                result.Equipment.Add("Tin of pounce powder");
                result.Feature = "Academic References: spend 1hr, succeed on medium DC Investigation check - find a contact within a library," +
                    "\nacademy, or place of knowledge. Contact is friendly and will answer research questions";

                if (rank == 1)
                {
                    character.ChosenBackground += " - Scribe's Assistant";
                    result.Equipment.Add("Holdings: A desk within a college, library, or museum with access to common resources." +
                        "\nA well-regarded text which is suspected to contain falsehoods, with made-up accounts and references.");
                    result.Progression = "";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Scribe";
                    result.Equipment.Add("Holdings: An office with printing materials, binding equipment." +
                        "\nA dedicated hireling assistant who completes minor tasks for you." +
                        "\nAccess to restricted sections of libraries and other places of collective knowledge.");
                    result.Progression = "Complete and restore a catalogue of books or scrolls to be added to a library." +
                        "\nYour contribution to the library must be deemed a worthy addition by your superiors.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Chief Librarian";
                    result.Equipment.Add("Holdings: A great library containing texts collected over centuries." +
                        "\nA team of hirelings who attend the day-to-day running of the library, such as scribes, assistants, and scholars." +
                        "\nYour name is highly regarded within the world of academia." +
                        "\nAccess to the entire library, including forbidden tomes and the knowledge they contain.");
                    result.Progression = "Make an unprecedented contribution to the world of academia." +
                        "\nThis may be the uncovering of a great truth, or the invention of a new methodology.";
                }
                else
                {
                    character.ChosenBackground += " - Grand Loremaster";
                    result.Equipment.Add("Holdings: You have become head of a knowledge-based institute(ministry, college, etc). You command the institution’s resources." +
                        "\nYou have authority over all smaller institutions within your region, including access to their resources and hirelings." +
                        "\nYou have access to sources of knowledge that have otherwise been sworn to secrecy." +
                        "\nSources can include forbidden arcane practices, demons’ true names, and schematics for powerful artifacts.");
                }
            }
            else if (prof == "Physician")
            {
                result.SkillProficiencies.Add("Medicine");
                result.Equipment.Add("Bag filled with medicinal herbs");
                result.Equipment.Add("Pestle & mortar");
                result.Equipment.Add("Bandages");
                result.Equipment.Add("Needle & thread");
                result.Equipment.Add("Jar of leeches");
                result.Feature = "Medical Diagnosis: spend 1hr, succeed on medium DC Medicine check - find the exact cause of an" +
                    "\nillness, injury, or death and if a nonmagical cure exists, you become aware of that cure";

                if (rank == 1)
                {
                    character.ChosenBackground += " - Surgeon’s Apprentice";
                    result.Equipment.Add("Holdings: Lodging near the medical clinic, hospital, or infirmary where you work." +
                        "\nA copy of the medical codex Cause and Cures.");
                    result.Progression = "Complete a variety of surgeries successfully, and be considered proficient by a mentor who has attained the rank of Barber Surgeon.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Barber Surgeon";
                    result.Equipment.Add("Holdings: A crude medical clinic known as a “Chop Shop”, to facilitate the surgeries you perform." +
                        "\nUp to half a dozen apprentices who follow your commands, assist you where possible, and aspire to become surgeons themselves.");
                    result.Progression = "Obtain your medical licence by proving your skill and dedication to a Royal Physician.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Doctor";
                    result.Equipment.Add("Holdings: A medical clinic, equipped with an infirmary to care for long-term patients with a variety of illnesses." +
                        "\nA medical licence granted by a Royal Physician, granting you the right to treat individuals of any background." +
                        "\nA clinic staff of half a dozen Barber Surgeons and a team of apprentices." +
                        "\nA patient list of influential figures of various backgrounds who employ your practice for their medical needs.");
                    result.Progression = "Build your practice into a hospital, with multiple Barber Surgeons and Doctors working alongside you." +
                        "\nYou must also accomplish a great medical achievement (discover a cure to a disease or a medical practice breakthrough)";
                }
                else
                {
                    character.ChosenBackground += " - Royal Physician";
                    result.Equipment.Add("Holdings: A Royal Hospital(reserved for the upper class) complete with multiple wards dedicated to various specialisations." +
                        "\nAn experienced team of physicians of all ranks, dedicated to running the Royal Hospital and advancing medical practices." +
                        "\nA client list consisting of Monarchs, powerful merchants, and other important individuals.");
                }
            }

            var talents = new List<string> { "Biologist", "Botanist", "Copycat", "Diligent Research", "Disciplinarian", "Drunkard",
                "Forecaster", "Gambler", "Local Historian", "Mystical Scholar", "Passionate Orator", "Pathologist", "Problem Solver",
                "Runekeeper", "Sawbones", "Translator" };
            GetTalents(talents, character, rank);

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
        public static GHBackground Aristocrat(Character character)
        {
            GHBackground result = new GHBackground();

            var skills = new List<string> { "Deception", "History", "Insight", "Performance", "Persuasion", "Religion" };
            string pickMsg = $"Pick a skill from the list";
            string errorMsg = "You are already trained in that skill, pick a different skill.";
            var skill = CLIHelper.GetNew(skills, character.SkillProficiencies, pickMsg, errorMsg);
            result.SkillProficiencies.Add(skill);
            pickMsg = "Pick a standard language";
            errorMsg = "You already have that language try again";
            string lang1 = CLIHelper.GetNew(Options.StandardLanguages, character.Languages, pickMsg, errorMsg);
            result.Languages.Add(lang1);
            result.Equipment.Add("Fine clothes");
            result.Equipment.Add("Piece of fine jewelry that displays your status");
            result.Equipment.Add("Quill and ink");
            result.Equipment.Add("Letter opener");
            result.Equipment.Add("Parchment");
            result.Equipment.Add("Coin purse");
            result.GP = 25;

            var professions = new List<string> { "Courtier", "Envoy", "Noble" };
            var tuple = GetRank(professions, character);
            string prof = tuple.Item1;
            int rank = tuple.Item2;

            if (prof == "Courtier")
            {
                result.SkillProficiencies.Add("Deception");
                result.Equipment.Add("A medallion or pin displaying your house patron");
                result.Equipment.Add("Court clothes");
                result.Feature = "Political Maneuvering: spend 1hr, succeed on medium DC Deception check - plant gossip true or false in gov't";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Chamber Keeper";
                    result.Equipment.Add("Holdings: A room or lodging provided by your patron within their estate." +
                        "\nA scandalous secret relating to a member of your court.");
                    result.Progression = "Obtain a minor title from your patron that reflects your station.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Court Official";
                    result.Equipment.Add("Holdings: The authority and resources associated with your minor title." +
                        "\nFor example, a cofferer would control financial records, and perhaps even bank access." +
                        "\nUp to half a dozen servant hirelings to assist in your daily responsibilities.");
                    result.Progression = "To be granted a greater court title by your patron that reflects your station.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Court Patrician";
                    result.Equipment.Add("Holdings: A greater court title and all the privileges that accompany it." +
                        "\nFor example, the master of ceremonies would have personal access to their patrons’ family." +
                        "\nA team of servants and lesser Courtiers sworn to you either through authority or intrigue." +
                        "\nA private suite within your patron’s estate that provides easy access to court and extravagant luxury." +
                        "\nInformants and spies throughout the court who report intrigue and valuable information to you.");
                    result.Progression = "Achieve complete control of your Court, through coercion, deception, or any other means.";
                }
                else
                {
                    character.ChosenBackground += " - Royal Chamberlain";
                    result.Equipment.Add("Holdings: Complete control of the court’s resources, such as finances, hirelings, and establishments." +
                        "\nIncriminating information relating to each member at court and their possible weaknesses." +
                        "\nInformants and spies across the region, who feed you intrigue regarding your court and others.");
                }
            }
            else if (prof == "Envoy")
            {
                result.SkillProficiencies.Add("Insight");
                result.Equipment.Add("Royal seal allowing you to cross borders");
                result.Equipment.Add("Diplomatic garb");
                result.Feature = "Diplomatic Connections: spend 1hr, succeed on medium DC Insight check - find an ally within the aristocracy, guilds, etc" +
                    "\nAlly is friendly to you and will answer questions about nobility, politics, or high-society";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Secretary";
                    result.Equipment.Add("Holdings: Free lodging within any consulate you represent or work for." +
                        "\nA secret encrypted political message you cannot decipher.");
                    result.Progression = "Assist in completing a dangerous or urgent diplomatic mission.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Councillor";
                    result.Equipment.Add("Holdings: A personal assistant to help with organising, who accompanies you on diplomatic journeys." +
                        "\nAccess to equipment and information known to the consulate.");
                    result.Progression = "Complete your own diplomatic mission successfully.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Ambassador";
                    result.Equipment.Add("Holdings: A team of Envoys to assist you at your consulate." +
                        "\nProvisions and resources sent to you by your home region to assist in diplomatic missions." +
                        "\nAn encryption codex, used to decipher encoded messages sent to and from your home region.");
                    result.Progression = "Negotiate an important treaty between nations, or uncover a great espionage conspiracy within your province.";
                }
                else
                {
                    character.ChosenBackground += " - Grand Chancellor";
                    result.Equipment.Add("Holdings: Access to restricted and classified documents." +
                        "\nYou represent your monarch or other absolute authority in external relations." +
                        "\nYou have access to any resources your monarch will provide you, and broad authority to use them.");
                }
            }
            else if (prof == "Noble")
            {
                result.SkillProficiencies.Add("Persuasion");
                result.Equipment.Add("Signet ring engraved with family crest");
                result.Feature = "Position of Privilege: spend 1hr, succeed on medium DC Persuasion check - reduce consequences for greater crimes" +
                    "\nignore small crimes like trespassing, theft, possession of contraband, unarmed assault, etc";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Dishevelled Noble";
                    result.Equipment.Add("Holdings: A ruined estate and noble title that carries little influence");
                    result.Progression = "To be granted a barony, or holdings worthy of the title, by a Count or higher-ranking noble" +
                        "\nAdditionally, you must restore your family household to a reputable state.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Lord Baron";
                    result.Equipment.Add("Holdings: A barony estate, including resources and hirelings." +
                        "\nA baron’s title, granting you authority and affirming your social status to people in your region.");
                    result.Progression = "Have a Duke or Monarch make you a Count, and construct a noble estate befitting a Count.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Count";
                    result.Equipment.Add("Holdings: A county estate, which includes resources and hirelings." +
                        "\nA count’s title, granting you authority and affirming your social status among other individuals of your region.");
                    result.Progression = "Be granted the title of Duke by a Monarch, and construct a noble estate befitting a Duke.";
                }
                else
                {
                    character.ChosenBackground += " - Duke";
                    result.Equipment.Add("Holdings: A Duke’s estate, which includes resources and hirelings." +
                        "\nA Duke’s title, granting you authority and social status among other individuals of your region.");
                }
            }

            var talents = new List<string> { "Born In the Saddle", "Copycat", "Court Schemer", "Disciplinarian", "Drunkard", "Elusive",
                "Figure of Authority", "Gambler", "Impressionist", "Local Historian", "Problem Solver", "Quick Fingers", "Translator" };
            GetTalents(talents, character, rank);

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
        public static GHBackground Clergy(Character character)
        {
            GHBackground result = new GHBackground();

            var skills = new List<string> { "History", "Insight", "Intimidation", "Medicine", "Persuasion", "Religion" };
            string pickMsg = $"Pick a skill from the list";
            string errorMsg = "You are already trained in that skill, pick a different skill.";
            var skill = CLIHelper.GetNew(skills, character.SkillProficiencies, pickMsg, errorMsg);
            result.SkillProficiencies.Add(skill);
            pickMsg = "Pick a standard language";
            errorMsg = "You already have that language try again";
            string lang1 = CLIHelper.GetNew(Options.StandardLanguages, character.Languages, pickMsg, errorMsg);
            result.Languages.Add(lang1);
            pickMsg = "Pick an exotic language from:";
            var langList = new List<string> { "Abyssal", "Celestial", "Infernal" };
            string lang2 = CLIHelper.GetNew(langList, character.Languages, pickMsg, errorMsg);
            result.Languages.Add(lang2);
            result.Equipment.Add("Prayer robes");
            result.Equipment.Add("Holy symbol");
            result.Equipment.Add("Prayer book or divine text");
            result.Equipment.Add("Vestments");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 15;

            var professions = new List<string> { "Inquisitor", "Preacher", "Priest" };
            var tuple = GetRank(professions, character);
            string prof = tuple.Item1;
            int rank = tuple.Item2;

            if (prof == "Inquisitor")
            {
                result.SkillProficiencies.Add("Intimidation");
                result.Equipment.Add("Manacles");
                result.Equipment.Add("A copy of the text \"Sins of the Heretic\"");
                result.Equipment.Add("Leather strap");
                result.Feature = "Eradicate Heresy: spend 1hr, succeed on medium DC Intimidation check - find informant and extract info" +
                    "\nInfo like the location of local cults, witch covens, and other enemies of the Divine";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Initiate";
                    result.Equipment.Add("Holdings: Free lodging at any religious institution that you currently serve." +
                        "\nYou know someone from your childhood who is now with a witch coven, religious cult, or other enemy of the faith.");
                    result.Progression = "Be promoted to the rank of Inquisitor by a Chapter Master.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Inquisitor";
                    result.Equipment.Add("Holdings: Free lodging at any religious institution that you currently serve." +
                        "\nAccess to info and equipment provided by the Order and temples of faith.");
                    result.Progression = "Be promoted to Chapter Master by a Grand Theologist Inquisitor.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Chapter Master";
                    result.Equipment.Add("Holdings: Free lodging at any religious institution that you currently serve." +
                        "\nAccess to the restricted section of the chapter library, which contains all known weaknesses of supernatural entities." +
                        "\nIf you have irrefutable evidence of their crimes, you have the authority to declare anyone an enemy of the faith.");
                    result.Progression = "Being appointed to Grand Theologist Inquisitor by the head of your Order and a panel of ranking clergy.";
                }
                else
                {
                    character.ChosenBackground += " - Grand Theologist Inquisitor";
                    result.Equipment.Add("Holdings: Access to a council of Chapter Masters and other ranked clergy with whom you discuss matters of your Order." +
                        "\nYou have the authority to appoint/dismiss chapter members to positions of power, both within the Inquisition and temples of the faith." +
                        "\nYou have the ability to denounce those who you know(or suspect) to be enemies of the faith" +
                        "\nYou can dispatch Inquisitor factions to investigate and impose the will of the faith.");
                }
            }
            else if (prof == "Preacher")
            {
                result.SkillProficiencies.Add("Persuasion");
                result.Equipment.Add("Flyers displaying propaganda");
                result.Equipment.Add("Box to stand on");
                result.Feature = "Propagate Agenda: spend 1hr, succeed on medium DC Persuasion check - you can influence the thoughts/opinions of locals" +
                    "\ncan be used to do things like heighten the people's fear of magic or to bring them comfort/peace of mind";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Crier";
                    result.Equipment.Add("Holdings: Free lodging at your local temple of the faith or religious institution." +
                        "\nKnowledge of a member of the ranked clergy using unlicensed magic or committing some other transgression.");
                    result.Progression = "You have a small congregation of followers who come to hear your sermons each day.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Truth Speaker";
                    result.Equipment.Add("Holdings: Free lodging at your local temple of the faith or religious institution." +
                        "\nYou advise a group of criers in your province on religious matters and outline the agenda for each.");
                    result.Progression = "You progress after having converted a significant number of people to your religion.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Enlightened Evangelist";
                    result.Equipment.Add("Holdings: Free lodging at your local temple of the faith or religious institution." +
                        "\nA letter that gives you religious immunity from Inquisitors, verifying that you are not a heretic." +
                        "\nA following of disciples who will accompany you to new unenlightened provinces to glorify your deity and you as its disciple.");
                    result.Progression = "A member of your congregation observes you performing a miracle, drawing new converts to the faith.";
                }
                else
                {
                    character.ChosenBackground += " - Exalted Savior";
                    result.Equipment.Add("Holdings: About a dozen faithful disciples that observe/convey your teachings & thousands of loyal followers." +
                        "\nA divine mandate bestowed by your deity or seraph that elevates you above the laws of humanity.");
                }
            }
            else if (prof == "Priest")
            {
                result.SkillProficiencies.Add("Religion");
                result.Equipment.Add("5 sticks of incense and an alms box");
                result.Equipment.Add("Religious medallion stamped with the divine word");
                result.Feature = "Religious Hierarchy: spend 1hr, succeed on medium DC Religion check - find an ally within the local clergy" +
                    "\nAlly is friendly to you and will answer questions about religion, the clergy’s agenda, and local religious matters";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Acolyte";
                    result.Equipment.Add("Holdings: You know of a senior clergy member who is exploiting the faith for personal gain." +
                        "\nFree lodging at your local temple of the faith.");
                    result.Progression = "Be recommended for priesthood by a senior clergy member who has overseen your study of divine texts." +
                    "\nYou will be given a religious task that you must complete.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Priest";
                    result.Equipment.Add("Holdings: You know of a senior clergy member who is exploiting the faith for personal gain." +
                        "\nFree lodging at your local temple of the faith." +
                        "\nA modest parish to oversee, including humble lodgings, and regularly receive locals for confession." +
                        "\nYou have knowledge of a wealthy noble who possesses a 1st ed. book of scripture that the church greatly desires.");
                    result.Progression = "Either expose the senior clergy member, or acquire the 1st ed. book of scripture.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Bishop";
                    result.Equipment.Add("Holdings: Well-appointed lodgings nearby a temple you steward (largest temple in your region)" +
                        "\nYou oversee your own diocese in a major city, speaking on behalf of the faith and supervising the clergy there.");
                    result.Progression = "You become Cardinal in the event that a Cardinal passes away or retires," +
                    "\nand the head of your faith appoints you in their stead due to your outstanding commitment to the faith.";
                }
                else
                {
                    character.ChosenBackground += " - Cardinal";
                    result.Equipment.Add("Holdings: A number of divine districts that you oversee within your province." +
                        "\nFree lodging at any parish, divine district, and any institution under control of the faith that recognises you");
                }
            }

            var talents = new List<string> { "Astute Intuition", "Cabal Lorekeeper", "Confessor", "Copycat", "Diligent Researcher",
                "Disciplinarian", "Drunkard", "Figure of Authority", "Idolist", "Interrogator", "Local Historian", "Menacing Presence",
                "Mystical Scholar", "Passionate Orator", "Pathologist", "Sawbones", "Shrewd Deduction" };
            GetTalents(talents, character, rank);

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
        public static GHBackground CommonFolk(Character character)
        {
            GHBackground result = new GHBackground();

            var skills = new List<string> { "Animal Handling", "Athletics", "Insight", "Nature", "Persuasion" };
            string pickMsg = $"Pick a skill from the list";
            string errorMsg = "You are already trained in that skill, pick a different skill.";
            var skill = CLIHelper.GetNew(skills, character.SkillProficiencies, pickMsg, errorMsg);
            result.SkillProficiencies.Add(skill);
            pickMsg = "Pick a standard language";
            errorMsg = "You already have that language try again";
            string lang1 = CLIHelper.GetNew(Options.StandardLanguages, character.Languages, pickMsg, errorMsg);
            result.Languages.Add(lang1);
            pickMsg = "Pick a tool or instrument for your proficiencies/inventory";
            var tools = new List<string>();
            tools.AddRange(Options.ArtisanTools);
            tools.AddRange(Options.MusicalInstruments);
            int index = CLIHelper.PrintChoices(pickMsg, tools);
            result.ToolProficiencies.Add(tools[index]);
            result.Equipment.Add(tools[index]);
            result.Equipment.Add("Common clothes");
            result.Equipment.Add("Small drawstring sack");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 10;

            var professions = new List<string> { "Villager", "Entertainer", "Merchant" };
            var tuple = GetRank(professions, character);
            string prof = tuple.Item1;
            int rank = tuple.Item2;

            if (prof == "Villager")
            {
                result.SkillProficiencies.Add("Insight");
                result.Equipment.Add("Iron pot");
                result.Equipment.Add("Shovel");
                result.Equipment.Add("Tinderbox");
                result.Feature = "Local Gossip: spend 1hr, succeed on medium DC Insight check - learn of rumours about a certain subject" +
                    "\ninfo can include jobs, political intrigue, or info that people tend to keep from authorities";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Peasant";
                    result.Equipment.Add("Holdings: A shack or hovel which you call home." +
                        "\nA deed to a heavily indebted farmstead which has been seized until its debts are cleared." +
                        "\nYou may have acquired this deed through inheritance, gambling winnings, or some other means.");
                    result.Progression = "Clear the debt on your deed and restore your farmstead to operating condition.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Land Owner";
                    result.Equipment.Add("Holdings: A small farmstead, including livestock, crops, and stores suitable to the location." +
                        "\nHalf a dozen unskilled hirelings who live and work on your farm.");
                    result.Progression = "Become a respected and influential member of your local village.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Council Member";
                    result.Equipment.Add("Holdings: A skilled, professional hireling assistant(lawyer, accountant, etc) who helps manage your affairs." +
                        "\nResources allocated by the Mayor for you to complete your duties as a council member.");
                    result.Progression = "To be elected or appointed Mayor by a lord, council, electorate, or other means.";
                }
                else
                {
                    character.ChosenBackground += " - Mayor";
                    result.Equipment.Add("Holdings: You have the resources of your village council at your disposal." +
                        "\nA team of skilled hirelings trained in professional services who assist you in your endeavours to run your holdings." +
                        "\nTo maintain order within the settlement, your Monarch grants resources(gold, military support, etc).");
                }

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
            }
            else if (prof == "Entertainer")
            {
                result.SkillProficiencies.Add("Performance");
                result.Equipment.Add("Colorful performer's clothes");
                result.Equipment.Add("Musical instrument");
                result.Equipment.Add("Tuning fork");
                result.Feature = "Find Fandom: spend 1hr, succeed on medium DC Performance check - find an ally within the local community leaders," +
                    "\nsuch as village elders, tavern owners, and other well-respected common folk." +
                    "\nAlly is friendly to you and will answer questions about life within the town, local news, and public opinions.";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Stage Hand";
                    result.Equipment.Add("Holdings: Lodging with an entertainers’ troupe, which includes food in exchange for regular performances." +
                        "\nAn anonymous letter from a loyal admirer and fan who is desperate to meet you.");
                    result.Progression = "The troupe leader asks you to fill in for an unreliable performer," +
                    "\nand offers you a permanent position in the troupe, owing to your musical or other talents.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Performer";
                    result.Equipment.Add("Holdings: Access to a troupe’s performing equipment/supplies, including instruments, concoctions, etc" +
                        "\nFree lodging and food at any establishment you perform in.");
                    result.Progression = "A travelling noble or court official observes your performance," +
                        "\nand days later you receive a letter of invitation to perform at a court or estate.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Troupe Leader";
                    result.Equipment.Add("Holdings: A following of loyal fans, including several influential individuals." +
                        "\nA troupe of skilled performers who are adept in a variety of forms of entertainment." +
                        "\nFree lodging and food at any establishment your troupe performs in.");
                    result.Progression = "You have been offered a large sum of money by a wealthy fan to perform for them on a semiregular basis.";
                }
                else
                {
                    character.ChosenBackground += " - Court Troubadour";
                    result.Equipment.Add("Holdings: A following of loyal fans, including several influential individuals." +
                        "\nContact with the troupe of skilled performers you used to lead." +
                        "\nPermanent lodgings at the noble estate or court where you are employed." +
                        "\nA scandalous secret about the lord of the manor or a prominent courtier, which you have irrefutable evidence of.");
                }

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
            }
            else if (prof == "Merchant")
            {
                result.SkillProficiencies.Add("Investigation");
                result.Equipment.Add("Fine clothes");
                result.Equipment.Add("Abacus");
                result.Equipment.Add("Quill and ink");
                result.Equipment.Add("Empty inventory record");
                result.Feature = "Appraisal: spend 1hr, succeed on medium DC Investigation check - learn the value of any trading good" +
                    "\nIf you do so within a settlement, you can also find the most profitable location to sell the item or goods.";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Clerk";
                    result.Equipment.Add("Holdings: A small back room in a shop, which serves as an office and doubles as your sleeping quarters." +
                        "\nA leather-bound ledger book containing the accounting methods of your mentor and teacher.");
                    result.Progression = "Acquire a loan, or save up funds, and find a suitable shop or storefront to start your own business.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Merchant";
                    result.Equipment.Add("Holdings: A quaint store or shop front, in which you sell your specialised goods." +
                        "\nA clerk who maintains your store and runs it on a day-to-day basis in your absence.");
                    result.Progression = "Own and maintain multiple successful businesses simultaneously.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Magnate";
                    result.Equipment.Add("Holdings: A series of successful businesses spanning multiple industries, and a network of suppliers." +
                        "\nA senior position in the regional Merchants Guild, including networks and guild benefits." +
                        "\nTeams of hirelings who work to keep the day-to-day operations of your businesses running smoothly.");
                    result.Progression = "Defeat your largest competitor(drive them out of business, buy them out, or merge your businesses).";
                }
                else
                {
                    character.ChosenBackground += " - Guild Chancellor";
                    result.Equipment.Add("Holdings: A Trade Certificate(Monarch signed), granting you an exclusive right to sell specialist goods." +
                        "\nNo other business within may trade in this commodity without your consent." +
                        "\nComplete control of the regional Merchant Guild you originally joined." +
                        "\nA trade empire containing many businesses and subsidiaries, each serving your interests.");
                }

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
            }

            var talents = new List<string> { "Beast Whisperer", "Biologist", "Botanist", "Calloused Hands", "Disciplinarian", "Drunkard",
                "Elusive", "Flamboyant Presentation", "Forecaster", "Gambler", "Gut Feeling", "Hard-Working", "Navigator", "Wayfarer" };
            GetTalents(talents, character, rank);

            return result;
        }
        public static GHBackground Criminal(Character character)
        {
            GHBackground result = new GHBackground();

            var skills = new List<string> { "Acrobatics", "Athletics", "Deception", "Intimidation", "Sleight of Hand", "Stealth" };
            string pickMsg = $"Pick a skill from the list";
            string errorMsg = "You are already trained in that skill, pick a different skill.";
            var skill = CLIHelper.GetNew(skills, character.SkillProficiencies, pickMsg, errorMsg);
            result.SkillProficiencies.Add(skill);
            result.Languages.Add("Thieves' Cant");
            result.ToolProficiencies.Add("Thieves' Tools");
            result.Equipment.Add("Dark common clothes with a hood");
            result.Equipment.Add("Thieves' Tools");
            result.Equipment.Add("Fake currency");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 15;

            var professions = new List<string> { "Charltan", "Cutthroat", "Burglar" };
            var tuple = GetRank(professions, character);
            string prof = tuple.Item1;
            int rank = tuple.Item2;

            if (prof == "Charltan")
            {
                result.SkillProficiencies.Add("Deception");
                result.Equipment.Add("Imitation fine clothes");
                result.Equipment.Add("Lockbox with a secret compartment");
                result.Equipment.Add("Forgery of a Merchant Guild membership");
                result.Feature = "False Identity: spend 1hr, succeed on medium DC Deception check - create a new identity with a fake ID.";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Peddler";
                    result.Equipment.Add("Holdings: A stash of counterfeit items that you sell and scam people with." +
                        "\nA secluded stoop that you use as a shelter against the elements near your place of “business”.");
                    result.Progression = "You create/are recruited by a gang of Hustlers to participate in more organized/larger-scale scams.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Hustler";
                    result.Equipment.Add("Holdings: A group of miscreants that assist your cons, you split the spoils with them.");
                    result.Progression = "You must acquire or create plans for a large-scale con and procure the necessary elements.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Con Artist";
                    result.Equipment.Add("Holdings: A team of skilled forgers who can recreate items at your request with great accuracy." +
                        "\nAn unmarked warehouse(in a disreputable part of town) to oversee your operations, you can store/create forged items there.");
                    result.Progression = "Successfully executing a grand con that draws the outrage of a great noble household, religious faction," +
                        "\nor other powerful institution. It also makes you famous among other criminals.";
                }
                else
                {
                    character.ChosenBackground += " - Mastermind";
                    result.Equipment.Add("Holdings: Many detailed plans of cons you have devised or procured." +
                        "\nA network of talented individuals who work at your behest, aiding you in orchestrating your ploys." +
                        "\nAn unmarked warehouse(in a disreputable part of town) to oversee your operations, you can store/create forged items there.");
                }

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
            }
            else if (prof == "Cutthroat")
            {
                result.SkillProficiencies.Add("Intimidation");
                result.Equipment.Add("Bag of loaded dice");
                result.Equipment.Add("Snuff box");
                result.Equipment.Add("Pocket watch that runs five minutes fast");
                result.Feature = "Underground Connections: spend 1hr, succeed on medium DC Intimidation check - find a contact in a local gang" +
                    "\nContact is friendly to you and will will assist you with matters related to their criminal endeavours.";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Tough";
                    result.Equipment.Add("Holdings: A hideout where you can seek shelter from the elements, and from local law enforcement.");
                    result.Progression = "Acquire a building to use as a centre of operations for your illicit activities," +
                    "\nand a handful of other criminals willing to follow your lead.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Crew Leader";
                    result.Equipment.Add("Holdings: A group of thugs that you command, overseeing their various ploys." +
                        "\nKnowledge of back alleys and slipways that allow you and your group to escape unpursued by local law enforcement." +
                        "\nA rundown establishment that you and your fellow henchmen operate out of.");
                    result.Progression = "Your group of thugs has progressed in size to exert control over an entire village or district within a city." +
                    "\nA sizable collection of shop owners that you can regularly exploit for 'protection'.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Gang Boss";
                    result.Equipment.Add("Holdings: Multiple warehouses/fronts to launder and store your spoils until you find a suitable buyer." +
                        "\nA network of contacts that you use to acquire and sell illicit goods." +
                        "\nA sizable collection of shop owners that you can regularly exploit for 'protection'.");
                    result.Progression = "You must overthrow a rival crime lord, or claim the territory of all surrounding rival gangs.";
                }
                else
                {
                    character.ChosenBackground += " - Crime Lord";
                    result.Equipment.Add("Holdings: An expansive territory that you control, including a headquarters" +
                        "\nYou oversee the criminals and businesses of the city taking a cut of their profits in exchange for 'protection'." +
                        "\nA number of personal secrets and incriminating evidence about high-ranking nobles, clergy, or business magnates." +
                        "\nA corrupt, influential state official who does your bidding and provides you with confidential information.");
                }
            }
            else if (prof == "Burglar")
            {
                result.SkillProficiencies.Add("Perception");
                result.Equipment.Add("Grappling hook and rope");
                result.Equipment.Add("Kidskin gloves");
                result.Equipment.Add("Glass cutter");
                result.Equipment.Add("Vial of Flour");
                result.Feature = "Surveillance: spend 1hr, succeed on medium DC Perception check - map the general layout of a building." +
                    "\nMap includes guard routes/rotation times, building entrances/exits, and the potential locations of valuables.";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Snatcher";
                    result.Equipment.Add("Holdings: A safehouse in the poor district, used to store stolen goods and as an emergency lodging." +
                        "\nYou have blueprints of the city including secret entrances and passageways.");
                    result.Progression = "You rob a well-to-do store in a reputable district, gaining notoriety and a big payday.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Burglar Specialist";
                    result.Equipment.Add("Holdings: A team of specialist thieves who operate under your instruction to execute more ambitious heists." +
                        "\nA contact working inside an establishment which you plan on robbing," +
                        "\nthe contact provides you info(routine of the occupants, location of valuable items, escape routes, etc).");
                    result.Progression = "Membership in an established Thieves’ Guild in a major city or town.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Heist Master";
                    result.Equipment.Add("Holdings: Membership in the Thieves' Guild gives you access to new fences and buyers" +
                        "\nIt also allows you to work with more experienced thieves and learn their methods" +
                        "\nYou uncover evidence of an attempted assassination on the life of a Thieves' Guild member.");
                    result.Progression = "You orchestrate a large-scale heist to rob the estate of a local noble.";
                }
                else
                {
                    character.ChosenBackground += " - Prince of Thieves";
                    result.Equipment.Add("Holdings: A senior position in the Thieves’ Guild," +
                        "\nYou instruct junior members in lockpicking, housebreaking, and evading law enforcers." +
                        "\nYou own an estate with a household of staff to maintain it and serve you" +
                        "\nYou also have your own circles of thieves, fences, and buyers to acquire/sell rare/valuable items for you");
                }
            }

            var talents = new List<string> { "Bounty Hunter", "Quick Fingers", "Contortionist", "Copycat", "Disciplinarian", "Drunkard",
                "Elusive", "Gambler", "Grifter", "Heister", "Impressionist", "Interrogator", "Menacing Presence", "Nimble Fingers",
                "Renowned", "Ropesman", "Sentry", "Urban Sprinter" };
            GetTalents(talents, character, rank);

            if (prof != "Charltan")
            {
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
            }
            
            return result;
        }
        public static GHBackground Militarist(Character character)
        {
            GHBackground result = new GHBackground();

            
            var skills = new List<string> { "Animal Handling", "Athletics", "Insight", "Intimidation", "Perception", "Survival" };
            string pickMsg = $"Pick a skill from the list";
            string errorMsg = "You are already trained in that skill, pick a different skill.";
            var skill = CLIHelper.GetNew(skills, character.SkillProficiencies, pickMsg, errorMsg);
            result.SkillProficiencies.Add(skill);
            result.ToolProficiencies.Add("Gaming set");
            result.Equipment.Add("Common clothes");
            result.Equipment.Add("Gaming set");
            result.Equipment.Add("Insignia of rank");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 15;

            var professions = new List<string> { "Mercenary", "Guard", "Soldier" };
            var tuple = GetRank(professions, character);
            string prof = tuple.Item1;
            int rank = tuple.Item2;

            if (prof == "Mercenary")
            {
                result.SkillProficiencies.Add("Intimidation");
                result.Equipment.Add("Moleskin gloves");
                result.Equipment.Add("Grappling net");
                result.Equipment.Add("Flask of hard liquor");
                result.Feature = "Independent Contractor: spend 1hr, succeed on medium DC Intimidation check - draw mercenary and adventuring jobs";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Hireling";
                    result.Equipment.Add("Holdings: Lodging at any Free Sword’s guild house and use of Free Sword’s training grounds and facilities." +
                        "\nThe contract for a dangerous bounty that your mentor died trying to complete.");
                    result.Progression = "Complete a contract with a guild member who has a Free Sword licence.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Sellsword";
                    result.Equipment.Add("Holdings: A Free Sword licence - allows you to accept your own mercenary contracts and collect rewards." +
                        "\nAccess to hirelings belonging to the Free Swords guild, who you can contract for a small fee.");
                    result.Progression = "Lead a team successfully through several highstakes encounters during mercenary contracts.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Sword Commander";
                    result.Equipment.Add("Holdings: A private room in a guild house and a retainer(goes to the guild house or accompanys you)." +
                        "\nCommand authority over lower ranks and the power to employ them for jobs." +
                        "\nAccess to restricted jobs that depend on sensitive information or extraordinary risk.");
                    result.Progression = "Successfully complete a restricted job for a high-profile client.";
                }
                else
                {
                    character.ChosenBackground += " - Battlelord";
                    result.Equipment.Add("Holdings: Command of the Free Swords guild(its members, managing contracts and training new members)." +
                        "\nA guild chapterhouse, which includes housing for you and your lieutenants as well as an extensive armoury." +
                        "\nAccess to restricted jobs that depend on sensitive information or extraordinary risk.");
                }
            }
            else if (prof == "Guard")
            {
                result.SkillProficiencies.Add("Perception");
                result.Equipment.Add("Manacles");
                result.Equipment.Add("Pipe and tobacco box");
                result.Equipment.Add("Badge of office");
                result.Feature = "Informant: spend 1hr, succeed on medium DC Perception check - find a contact among constables/guards." +
                    "\nContact is friendly to you and will answer questions regarding criminals, law enforcement, and investigations";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Town Militia";
                    result.Equipment.Add("Holdings: A bunk bed to sleep in at your stationed guardhouse." +
                        "\nSensitive information relating to an unsolved murder that you have not told anyone about.");
                    result.Progression = "Solve a crime or uncover a major smuggling route.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Captain of the Watch";
                    result.Equipment.Add("Holdings: Your own room in a guardhouse of your choosing" +
                        "\nAccess to city gates keys. A group of militia guards to train and organise.");
                    result.Progression = "Catch a renowned criminal before they can escape the city, or another act worthy of a promotion.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Royal Guard";
                    result.Equipment.Add("Holdings: Free lodging on the grounds of the palace or other place of work." +
                        "\nUnquestioned access to restricted areas of the city." +
                        "\nPermission to view the casefiles of ongoing investigations and past crimes" +
                        "\nYou can also access documents detailing guard routes and rosters.");
                    result.Progression = "Save a VIP from an assasination attempt, rescue a kidnapped princess, or anything of equal import to be promoted.";
                }
                else
                {
                    character.ChosenBackground += " - Lord Commander";
                    result.Equipment.Add("Holdings: ");
                }
            }
            else if (prof == "Soldier")
            {
                result.SkillProficiencies.Add("Athletics");
                result.Equipment.Add("Standard soldier garb");
                result.Equipment.Add("Trophy from your first battle");
                result.Equipment.Add("Letter from your family or a loved one");
                result.Equipment.Add("Service medallion signifying rank");
                result.Feature = "Combat Drills: spend 1hr, succeed on medium DC Athletics check - gain accurate estimate of drilled people" +
                    "\nIncludes combat capabilities, equipment or fortifications. You determine how to improve short-term and long-term training";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Foot Soldier";
                    result.Equipment.Add("Holdings: A tent to sleep in and free food when in an encampment of your military." +
                        "\nA letter from a fallen enemy messenger that you either killed or found.");
                    result.Progression = "Distinguish yourself. Bring vital info about enemy camp or movement(help win a battle or prevent defeat)." +
                    "\nOr perform exceptionally well in battle, turning the tide or capturing an enemy banner.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Sergeant";
                    result.Equipment.Add("Holdings: Command over a small unit of Foot Soldiers - equipment and camp materials." +
                        "\nA valet who attends to your personal needs in the field and relays important messages when required.");
                    result.Progression = "Maintain your troops’ discipline through multiple skirmishes.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Lieutenant";
                    result.Equipment.Add("Holdings: Command over a brigade of soldiers, a large military force." +
                        "\nA command tent that serves as your headquarters for battlefield operations." +
                        "\nA lieutenant's quarters that is comfortable, well-equiped, and well-guarded");
                    result.Progression = "Decisively win an even battle or win a battle against the odds.";
                }
                else
                {
                    character.ChosenBackground += " - Field Marshal";
                    result.Equipment.Add("Holdings: Command over a region’s military. A seat at council meetings relevant to military matters." +
                        "\nResidence in a manor in a city of your choosing in your region, it must be close to training grounds." +
                        "\nIf you choose to participate in military attacks, accomodations of your choosing will be provided.");
                }
            }

            var talents = new List<string> { "Astute Intuition", "Beast Whisperer", "Born in the Saddle", "Bounty Hunter",
                "Calloused Hands", "Copycat", "Disciplinarian", "Drunkard", "Figure of Authority", "Forecaster", "Gambler",
                "Hard-Working", "Interrogator", "Menacing Presence", "Navigator", "Passionate Orator", "Recruiter", "Renowned",
                "Sentry", "Shrewd Deduction", "Urban Sprinter", "Wayfarer" };
            GetTalents(talents, character, rank);

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
        public static GHBackground Outlander(Character character)
        {
            GHBackground result = new GHBackground();

            var skills = new List<string> { "Animal Handling", "Athletics", "Medicine", "Nature", "Perception", "Stealth", "Survival" };
            string pickMsg = $"Pick a skill from the list";
            string errorMsg = "You are already trained in that skill, pick a different skill.";
            var skill = CLIHelper.GetNew(skills, character.SkillProficiencies, pickMsg, errorMsg);
            result.SkillProficiencies.Add(skill);
            result.ToolProficiencies.Add("Herbalism Kit");
            pickMsg = "Pick a standard language";
            errorMsg = "You already have that language try again";
            string lang1 = CLIHelper.GetNew(Options.StandardLanguages, character.Languages, pickMsg, errorMsg);
            result.Languages.Add(lang1);
            result.Equipment.Add("Traveler's clothes");
            result.Equipment.Add("Tinderbox");
            result.Equipment.Add("5 Torches");
            result.Equipment.Add("Waterskin");
            result.Equipment.Add("Hatchet");
            result.Equipment.Add("Herbalism Kit");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 10;

            var professions = new List<string> { "Beast Hunter", "Pioneer", "Explorer" };
            var tuple = GetRank(professions, character);
            string prof = tuple.Item1;
            int rank = tuple.Item2;

            if (prof == "Beast Hunter")
            {
                result.SkillProficiencies.Add("Survival");
                result.Equipment.Add("Net");
                result.Equipment.Add("Hunting trap");
                result.Equipment.Add("30ft of rope");
                string listMsg = "Pick 1 or 2 to add to your equipment";
                var list = new List<string> { "Vial of pheromones", "Pouch of bait" };
                int bait = CLIHelper.PrintChoices(listMsg, list);
                result.Equipment.Add(list[bait]);
                result.Feature = "Track Quarry: spend 1hr, succeed on medium DC Survival check - track creatures who passed through an area." +
                    "\nIf you are familiar with the type of creature, you learn the exact time and direction the creature went.";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Tracker";
                    result.Equipment.Add("Holdings: You can find Beast Hunters' Lodges in the wilderness to rest and escape danger." +
                        "\nYou have a lead as to the location of the lair of a powerful and dangerous creature.");
                    result.Progression = "Prove to your mentor that you are competent to hunt on your own and teach the new and inexperienced.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Trapper";
                    result.Equipment.Add("Holdings: Up to a handful of apprentices who wish to learn the trade." +
                        "\nUse of equipment from a Beast Hunters' Lodges to hunt any beast you accept a contract to kill.");
                    result.Progression = "Complete a contract to kill a particularly rare/dangerous beast for a community/influential individual." +
                    "\nYou must determine the creature’s species, track it, and slay it.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Venator";
                    result.Equipment.Add("Holdings: A team of experienced hunters who assist you in large hunts and handle smaller jobs you assign." +
                        "\nAccess to the Beast Hunters' Library, which contains all known weaknesses of beasts and monsters.");
                    result.Progression = "Slay a legendary beast. The event must draw the awe of influential individuals across the land.";
                }
                else
                {
                    character.ChosenBackground += " - Mythical Beast Hunter";
                    result.Equipment.Add("Holdings: Control of the Beast Hunters guild, including resources and personnel." +
                        "\nYou are famous across the land as a figure of legend." +
                        "\nA mighty weapon or artifact handed down to you by the guild, a satisfied customer, or an admirer." +
                        "\nAn audience with any ruler at their convenience to discuss matters of beast hunting in their domain.");
                }
            }
            else if (prof == "Pioneer")
            {
                result.SkillProficiencies.Add("Nature");
                result.Equipment.Add("Shovel");
                result.Equipment.Add("Hammer and nails");
                result.Equipment.Add("Saw");
                result.Equipment.Add("Spare leather");
                result.Equipment.Add("Needle and Thread");
                result.Feature = "Handyman by Necessity: spend 1hr, succeed on medium DC Nature check - find materials to mend any mundane item.";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Hermit";
                    result.Equipment.Add("Holdings: Knowledge of a rare plant or animal, if domesticated, could be farmed for great gain.");
                    result.Progression = "Build a house, or similar building, and the beginnings of a farm.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Secluded Cultivator";
                    result.Equipment.Add("Holdings: A house you built and a small herd or a field of crops." +
                        "\nA small family or group of farmhands who help tend your homestead.");
                    result.Progression = "Gather a small community around your homestead.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Homestead Proprietor";
                    result.Equipment.Add("Holdings: A sizable ranch/plantation of your chosen commodity, bringing significant profit each harvest." +
                        "\nA small, self-sufficient, village-sized community that takes care of your ranch/plantation." +
                        "\nThe village will also listen to your opinion on difficult decisions or conflict resolution" +
                        "\nA trail/road that leads to the nearest town for traveling merchants to buy and sell wares.");
                    result.Progression = "Acquire a rare or magical animal or plant to be farmed.";
                }
                else
                {
                    character.ChosenBackground += " - Governor";
                    result.Equipment.Add("Holdings: As a local authority, you enter into the society of notable merchants, nobles, and royalty." +
                        "\nPowerful people approach you to buy what you offer and deal with your town." +
                        "\nAn inn with a central courtyard that houses coming and going merchant caravans from across the land." +
                        "\nA large house for you and your family, suitable for receiving important visitors." +
                        "\nA small but disciplined militia to protect your homestead and its surroundings." +
                        "\nA political alliance with a neighbouring state that supports your independence.");
                }
            }
            else if (prof == "Explorer")
            {
                result.SkillProficiencies.Add("Survival");
                result.Equipment.Add("Compass");
                result.Equipment.Add("Mapmaking Tools(quill, ink, parchment, calipers, ruler)");
                result.Equipment.Add("10 days of rations");
                result.Feature = "Known Shelters: spend 1hr, succeed on medium DC Survival check - find the nearest settlement" +
                    "\nSettlement may be hostile such as bandits, druids, or tribal people. If the settlement is not hostile" +
                    "\nInhabitants are initially friendly and will let you seek shelter and trade among them.";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Wanderer";
                    result.Equipment.Add("Holdings: A letter from an old friend describing an anomaly within the wilds of your choice." +
                        "\nA hidden stash in the wilds you chose, containing rations, medical supplies, fresh water, and weapons.");
                    result.Progression = "Discover an anomaly and document its location.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Pathfinder";
                    result.Equipment.Add("Holdings: Detailed knowledge of your chosen wilderness, including locations of interest and danger." +
                        "\nA contract with a local guild or faction to guide members through the area.");
                    result.Progression = "Establish a new road or trade route between known settlements or landmarks that is safe to travel.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Royal Surveyor";
                    result.Equipment.Add("Holdings: Resources to assist in your exploration provided by clients." +
                        "\nAn assistant cartographer, scribe, or other related profession." +
                        "\nMaps and charts that have been procured by your assistant, detailing hidden routes.");
                    result.Progression = "Complete an exploration mission of great notoriety, commissioned by a Monarch or other leader.";
                }
                else
                {
                    character.ChosenBackground += " - Horizon Master";
                    result.Equipment.Add("Holdings: If your campaign permits it, you know of gateways to other planes of existence." +
                        "\nAn ancient map leading to a lost landmark of great importance. It may contain wealth, power, or knowledge." +
                        "\nAn exploration company of hirelings - labourers, soldiers, academics, carpenters, and many other professions." +
                        "\nA port/encampment at a strategic location that acts as a frontier post to launch exploration missions.");
                }
            }

            var talents = new List<string> { "Beast Whisperer", "Biologist", "Born in the Saddle", "Botanist", "Calloused Hands",
                "Disciplinarian", "Drunkard", "Forecaster", "Gambler", "Gut Feeling", "Hard-Working", "Local Historian", "Navigator",
                "Renowned", "Translator" };
            GetTalents(talents, character, rank);

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
        public static GHBackground Seafarer(Character character)
        {
            GHBackground result = new GHBackground();

            var skills = new List<string> { "Athletics", "Perception", "Persuasion", "Sleight of Hand", "Survival" };
            string pickMsg = $"Pick a skill from the list";
            string errorMsg = "You are already trained in that skill, pick a different skill.";
            var skill = CLIHelper.GetNew(skills, character.SkillProficiencies, pickMsg, errorMsg);
            result.SkillProficiencies.Add(skill);
            result.ToolProficiencies.Add("Navigator's Tools");
            result.ToolProficiencies.Add("Vehicles(water)");
            pickMsg = "Pick a standard language";
            errorMsg = "You already have that language try again";
            string lang1 = CLIHelper.GetNew(Options.StandardLanguages, character.Languages, pickMsg, errorMsg);
            result.Languages.Add(lang1);
            pickMsg = "Pick an exotic language";
            string lang2 = CLIHelper.GetNew(Options.ExoticLanguages, character.Languages, pickMsg, errorMsg);
            result.Languages.Add(lang2);
            result.Equipment.Add("Common clothes");
            result.Equipment.Add("Belaying Pin(can be used as a club)");
            result.Equipment.Add("Thread and blunt needle");
            result.Equipment.Add("Bucket of tar");
            result.Equipment.Add("Belt pouch for coins");
            result.GP = 10;

            var luckyCharmExamples = new List<string>() { "rabbit foot", "small stone with a hole in the center", "random Trinket" };
            Console.WriteLine("Sailors get a lucky charm as a part of their equipment. Pick an option to determine it.");
            CLIHelper.Print2Choices("Pick from a list of examples.", "Leave it as 'Lucky charm'.");
            int choice = CLIHelper.GetNumberInRange(1, 2);

            if (choice == 1)
            {
                string luckyCharm = CLIHelper.PrintChoices(luckyCharmExamples);
                result.Equipment.Add(luckyCharm);
            }
            else
            {
                result.Equipment.Add("Lucky charm");
            }

            var professions = new List<string> { "Sailor", "Dock Worker", "Sea Gatherer" };
            var tuple = GetRank(professions, character);
            string prof = tuple.Item1;
            int rank = tuple.Item2;

            if (prof == "Sailor")
            {
                result.SkillProficiencies.Add("Perception");
                result.Equipment.Add("Sturdy clothes");
                result.Equipment.Add("Large sack");
                result.Equipment.Add("Dice");
                result.Equipment.Add("Liquor Flask");
                result.Feature = "Sea Passage: spend 1hr, succeed on medium DC Perception check - find a ship that will provide free passage" +
                    "\nto a location of your choice, provided any ships are traveling toward that location";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Deck Hand";
                    result.Equipment.Add("Holdings: Free lodging on your boat. Knowledge of a potential mutiny.");
                    result.Progression = "Be promoted to Boatswain by a Captain.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Boatswain";
                    result.Equipment.Add("Holdings: Command over the deckhands on the ship when not under the orders of a higher rank." +
                        "\nAn officer’s quarters which doubles as your cabin and living space.");
                    result.Progression = "Be promoted to Ship Captain or become Captain of your own ship by other means.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Ship Captain";
                    result.Equipment.Add("Holdings: A ship, one you own or one you've been entrusted command of." +
                        "\nCommand of a loyal crew that see to the operation and maintenance of your ship." +
                        "\nIf you own the ship, you have complete control, but you have to pay for upkeep." +
                        "\nEven if the ship belongs to an admiralty or business interest, on board the ship you are the one in charge.");
                    result.Progression = "Be promoted to Admiral by a higher authority, or by obtaining a fleet of your own.";
                }
                else
                {
                    character.ChosenBackground += " - Fleet Admiral";
                    result.Equipment.Add("Holdings: A fleet of ships that follow your every command." +
                        "\nCommand of multiple loyal crews that see to the operation and maintenance of your fleet." +
                        "\nYou are known in other lands for the tales of your victories and expertise." +
                        "\nFree lodging on any ship you are in command of, and any port or shipyard you are docked at.");
                }
            }
            else if (prof == "Dock Worker")
            {
                result.SkillProficiencies.Add("Investigation");
                result.Equipment.Add("Leather strap");
                result.Equipment.Add("30ft of rope");
                result.Equipment.Add("Pulley");
                result.Equipment.Add("Box of snuff");
                result.Equipment.Add("Clipboard and quill");
                result.Feature = "Liberate Ledgers: spend 1hr, succeed on medium DC Investigation check - you know the traffic of ships, wagons" +
                    "\nand merchandise at a trade hub. You can also discern where different goods, including contraband, are stored";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Stock Clerk";
                    result.Equipment.Add("Holdings: Lodging near the port or trade station you work at." +
                        "\nYou know where the contraband is hidden and how to get in.");
                    result.Progression = "Be promoted to Customs Inspector by a dock worker of a higher station.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Customs Inspector";
                    result.Equipment.Add("Holdings: A list of fellow Customs Inspectors known for accepting bribes, and who bribed them." +
                        "\nA letter or clue revealing the smuggling operations of a criminal organisation." +
                        "\nAuthority over low ranking dockworkers and port guards.");
                    result.Progression = "Expose a large quantity of contraband or a criminal organisation.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Harbor Master";
                    result.Equipment.Add("Holdings: Comfortable accommodation within the port town or city of your station." +
                        "\nAuthority of all resources, funding, and personnel of the harbour you manage." +
                        "\nThe authority to grant commodity licences, allowing the import or harvesting of the commodity.");
                    result.Progression = "Be promoted by a Monarch or state leader.";
                }
                else
                {
                    character.ChosenBackground += " - Sealord";
                    result.Equipment.Add("Holdings: Luxurious lodging near a mercantile district where you oversee the operations of the region." +
                        "\nControl over docking fees and other charges associated with trading posts and ports across the region." +
                        "\nAuthority of all resources, funding, and personnel of the harbour you manage." +
                        "\nThe authority to grant commodity licences, allowing the import or harvesting of the commodity." +
                        "\nA seat at any council meetings pertaining to trade or the sea in the kingdom.");
                }
            }
            else if (prof == "Sea Gatherer")
            {
                result.SkillProficiencies.Add("Survival");
                result.Equipment.Add("Bag of water weeds");
                result.Equipment.Add("Shellfish trap");
                result.Equipment.Add("Shucking knife");
                result.Equipment.Add("Pouch of bait");
                result.Equipment.Add("Straw sunhat");
                result.Feature = "Knowledge of the Seas: spend 1hr, succeed on medium DC Survival check - earn money by finding sea treasures" +
                                 "This can be anything - simple fishing, dangerous monster hunting, diving for wrecks and ruins, etc";
                if (rank == 1)
                {
                    character.ChosenBackground += " - Dredge";
                    result.Equipment.Add("Holdings: A small, wicker, one-person fishing boat." +
                        "\nKnowledge of the best fishing spots in the area.");
                    result.Progression = "Acquire a trawling boat and a commodity license from a Harbour Master.";
                }
                else if (rank == 2)
                {
                    character.ChosenBackground += " - Trawler";
                    result.Equipment.Add("Holdings: A single-masted trawling boat with a few assistants to crew it." +
                        "\nA rumour of a great sunken treasure and the identity of who currently holds the map to it.");
                    result.Progression = "Complete a contract to kill a particularly rare and dangerous nautical monster or find a sunken treasure." +
                        "\nThe contract must be completed for a wizard, merchant prince, or similarly influential individual.";
                }
                else if (rank == 3)
                {
                    character.ChosenBackground += " - Trawl Master";
                    result.Equipment.Add("Holdings: A deep-sea trawling boat, equipped to spend months at sea." +
                        "\nA team of expert trawlers and divers to assist you in adventures and maintain your boat." +
                        "\nThe audience of wizards and merchant princes who wish to hire you.");
                    result.Progression = "Slay a major sea monster or find a sunken treasure that becomes legend." +
                        "\nThe event must draw the awe of influential individuals across the land.";
                }
                else
                {
                    character.ChosenBackground += " - Nautical Legend";
                    result.Equipment.Add("Holdings: Control of a coastal island awarded to you by a Monarch in recognition of your feats." +
                        "\nThe island houses a fortress, guild house, or similar structure where nautical legends gather." +
                        "\nA deep-sea trawling boat, equipped to spend months at sea. A team of expert trawlers/divers who maintain the boat." + 
                        "\nRepute across the land as a figure of legend. A mighty weapon or artifact(sunken treasure or reward)." +
                        "\nAn audience with any ruler, at their convenience, to discuss matters of salvage/treasure hunting." +
                        "\nThe audience of wizards and merchant princes who wish to hire you.");
                }
            }

            var talents = new List<string> { "Calloused Hands", "Copycat", "Disciplinarian", "Drunkard", "Forecaster", "Gambler","Gut Feeling",
                "Hard-Worker", "Menacing Presence", "Navigator", "Recruiter", "Renowned", "Ropesman", "Sea Dog", "Sentry", "Wayfarer" };
            GetTalents(talents, character, rank);

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
    }
}
