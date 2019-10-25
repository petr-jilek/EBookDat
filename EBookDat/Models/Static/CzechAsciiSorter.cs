using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookDat
{
    public static class CzechAsciiSorter
    {
        public static List<int> SetIntValuesForString(string sInput) {
            List<int> values = new List<int>();
            for (int c = 0; c < sInput.Length; c++) {
                switch (sInput[c]) {
                    case 'ž':
                        values.Add(150);
                        break;
                    case 'Ž':
                        values.Add(151);
                        break;
                    case 'z':
                        values.Add(152);
                        break;
                    case 'Z':
                        values.Add(153);
                        break;
                    case 'ý':
                        values.Add(154);
                        break;
                    case 'Ý':
                        values.Add(155);
                        break;
                    case 'y':
                        values.Add(156);
                        break;
                    case 'Y':
                        values.Add(157);
                        break;
                    case 'x':
                        values.Add(158);
                        break;
                    case 'X':
                        values.Add(159);
                        break;
                    case 'w':
                        values.Add(160);
                        break;
                    case 'W':
                        values.Add(161);
                        break;
                    case 'v':
                        values.Add(162);
                        break;
                    case 'V':
                        values.Add(163);
                        break;
                    case 'ů':
                        values.Add(164);
                        break;
                    case 'Ů':
                        values.Add(165);
                        break;
                    case 'ú':
                        values.Add(166);
                        break;
                    case 'Ú':
                        values.Add(167);
                        break;
                    case 'u':
                        values.Add(168);
                        break;
                    case 'U':
                        values.Add(169);
                        break;
                    case 'ť':
                        values.Add(170);
                        break;
                    case 'Ť':
                        values.Add(171);
                        break;
                    case 't':
                        values.Add(172);
                        break;
                    case 'T':
                        values.Add(173);
                        break;
                    case 'š':
                        values.Add(174);
                        break;
                    case 'Š':
                        values.Add(175);
                        break;
                    case 's':
                        values.Add(176);
                        break;
                    case 'S':
                        values.Add(177);
                        break;
                    case 'ř':
                        values.Add(178);
                        break;
                    case 'Ř':
                        values.Add(179);
                        break;
                    case 'r':
                        values.Add(180);
                        break;
                    case 'R':
                        values.Add(181);
                        break;
                    case 'q':
                        values.Add(182);
                        break;
                    case 'Q':
                        values.Add(183);
                        break;
                    case 'p':
                        values.Add(184);
                        break;
                    case 'P':
                        values.Add(185);
                        break;
                    case 'ó':
                        values.Add(186);
                        break;
                    case 'Ó':
                        values.Add(187);
                        break;
                    case 'o':
                        values.Add(188);
                        break;
                    case 'O':
                        values.Add(189);
                        break;
                    case 'ň':
                        values.Add(190);
                        break;
                    case 'Ň':
                        values.Add(191);
                        break;
                    case 'n':
                        values.Add(192);
                        break;
                    case 'N':
                        values.Add(193);
                        break;
                    case 'm':
                        values.Add(194);
                        break;
                    case 'M':
                        values.Add(195);
                        break;
                    case 'l':
                        values.Add(196);
                        break;
                    case 'L':
                        values.Add(197);
                        break;
                    case 'k':
                        values.Add(198);
                        break;
                    case 'K':
                        values.Add(199);
                        break;
                    case 'j':
                        values.Add(200);
                        break;
                    case 'J':
                        values.Add(201);
                        break;
                    case 'í':
                        values.Add(202);
                        break;
                    case 'Í':
                        values.Add(203);
                        break;
                    case 'i':
                        values.Add(204);
                        break;
                    case 'I':
                        values.Add(205);
                        break;
                    case 'h':
                        values.Add(206);
                        break;
                    case 'H':
                        values.Add(207);
                        break;
                    case 'g':
                        values.Add(208);
                        break;
                    case 'G':
                        values.Add(209);
                        break;
                    case 'f':
                        values.Add(210);
                        break;
                    case 'F':
                        values.Add(211);
                        break;
                    case 'ě':
                        values.Add(212);
                        break;
                    case 'Ě':
                        values.Add(213);
                        break;
                    case 'é':
                        values.Add(214);
                        break;
                    case 'É':
                        values.Add(215);
                        break;
                    case 'e':
                        values.Add(216);
                        break;
                    case 'E':
                        values.Add(217);
                        break;
                    case 'ď':
                        values.Add(218);
                        break;
                    case 'Ď':
                        values.Add(219);
                        break;
                    case 'd':
                        values.Add(220);
                        break;
                    case 'D':
                        values.Add(210);
                        break;
                    case 'č':
                        values.Add(222);
                        break;
                    case 'Č':
                        values.Add(223);
                        break;
                    case 'c':
                        values.Add(224);
                        break;
                    case 'C':
                        values.Add(225);
                        break;
                    case 'b':
                        values.Add(226);
                        break;
                    case 'B':
                        values.Add(227);
                        break;
                    case 'á':
                        values.Add(228);
                        break;
                    case 'Á':
                        values.Add(229);
                        break;
                    case 'a':
                        values.Add(230);
                        break;
                    case 'A':
                        values.Add(231);
                        break;
                    default:
                        values.Add((int)sInput[c]);
                        break;
                }
            }
            return values;
        }

        public static bool CompareTwoStringsIsFirstUpToSecond(string first, string second) {
            List<int> firstValues = SetIntValuesForString(first);
            List<int> secondValues = SetIntValuesForString(second);
            for (int i = 0; i < (firstValues.Count < secondValues.Count ? firstValues.Count : secondValues.Count); i++) {
                if ((int)firstValues[i] > (int)secondValues[i]) {
                    return true;
                }
                else if ((int)firstValues[i] < (int)secondValues[i]) {
                    return false;
                }
            }
            return firstValues.Count > secondValues.Count ? true : false;
        }

    }
}
