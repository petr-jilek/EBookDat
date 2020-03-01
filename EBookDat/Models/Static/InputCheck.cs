using AuthExceptionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EBookDat
{
    public static class InputCheck
    {
        private static void CheckFieldMain(string input, bool checkMinLengt, bool isInt, bool biggerLength, string block) {
            if (input.Contains(';')) throw new AuthException(AuthException.EList.FieldContainsBannedMarks, block);

            if (checkMinLengt) {
                if (string.IsNullOrWhiteSpace(input)) throw new AuthException(AuthException.EList.FieldIsEmpty, block); ;
            }

            if (input.Length != 0 && !(input.Length == 1 && input == "-")) {
                if (isInt) {
                    if (!int.TryParse(input, out int outher)) throw new AuthException(AuthException.EList.FieldIsntNumber, block);
                }
            }

            if (biggerLength) {
                if (input.Length > 1500) throw new AuthException(AuthException.EList.FieldIsTooLong, block);
            }
            else {
                if (input.Length > 500) throw new AuthException(AuthException.EList.FieldIsTooLong, block);
            }

        }

        public static void CheckBookInput(string title, string author, string publishYear, string publishLocation, string publisher, string isbn, string pagesNumber, string note) {
            InputCheck.CheckFieldMain(title, true, false, false, "Titul");
            InputCheck.CheckFieldMain(author, true, false, false, "Autor");

            InputCheck.CheckFieldMain(publishYear, false, true, false, "Rok vydání");
            InputCheck.CheckFieldMain(pagesNumber, false, true, false, "Počet stran");

            InputCheck.CheckFieldMain(publishLocation, false, false, false, "Místo vydání");
            InputCheck.CheckFieldMain(publisher, false, false, false, "Nakladatelství");
            InputCheck.CheckFieldMain(isbn, false, false, false, "Isbn");

            InputCheck.CheckFieldMain(note, false, false, true, "Poznámka");

        }

        public static void CheckEGCInput(string input) {
            InputCheck.CheckFieldMain(input, true, false, false, "Název");
        }




    }
}
