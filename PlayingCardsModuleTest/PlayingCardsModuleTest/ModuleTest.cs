using PlayingCards;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCardsModuleTest
{
    class ModuleTest
    {
        Cards cards = new Cards();

        public string CaseID { get; set; }
        public string Input { get; set; }
        public string Expected { get; set; }
        public string Result { get; set; }
        public string FilePath { get; set; }
        public List<string> ResultList { get; set; }

        public void CreateOrGetFile()
        {
            string file = "ModuleTest.txt";
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            FilePath = directory + "\\" + file;
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
            }
        }

        public void SaveToFile(List<string> inputResultList)
        {
            string[] testResults = new string[inputResultList.Count()];
            testResults = inputResultList.ToArray();
            File.WriteAllLines(FilePath, testResults);
        }

        public void Test()
        {
            string[] testCases = {
                "001:aC:AceClubs",
                "002:7d:SevenDiamonds",
                "003:Ks:KingSpades",
                "004:!0:FAIL",
                "005:10c:TenClubs",
                "006:66D:FAIL",
                "007:xX14:FAIL",
                "008:jD:JackDiamonds",
                "009:4h:FourHearts",
                "010:12/:FAIL"
            };
            ResultList = new List<string>();
            foreach (string test in testCases)
            {
                string[] splitCases = test.Split(':');
                CaseID = splitCases[0];
                Input = splitCases[1];
                Expected = splitCases[2];
                string output = cards.CardConverter(Input);
                if (output == Expected)
                {
                    Result = "PASS";
                }
                if (output == null)
                {
                    Result = "FAIL";
                }
                ResultList.Add(CaseID + ":" + Input + ":" + Expected + ":" + Result);
            }
            SaveToFile(ResultList);
        }
    }
}
