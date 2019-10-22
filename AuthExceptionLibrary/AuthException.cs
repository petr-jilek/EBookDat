using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExceptionLibrary
{
    public class AuthException : EBookDatExpection
    {
        public string block;
        /// <summary>
        ///     'List' of all exception types for this module
        /// </summary>
        /// 
        public enum EList
        {
            #region Unexpected 100

            UnexpectedException = 100,

            #endregion

            #region Other 200

            AuthHeaderInvalid = 200,
            BadInput = 401,

            #endregion

            #region Book 300
            #endregion

            #region EGCInput 400

            IsExist = 400,

            #endregion

            #region Field 500

            FieldIsEmpty = 500,
            FieldContainsBannedMarks = 501,
            FieldIsTooLong = 502,
            FieldIsntNumber = 503,

            #endregion

        }

        /// <summary>
        ///     Base Code - base error code for this module
        /// </summary>
        public const int BCode = 20000;

        /// <summary>
        ///     'List' of all exceptions with their data
        /// </summary>
        private static readonly Dictionary<EList, Error> Errors = new Dictionary<EList, Error>
        {
            #region Unexpected

            {EList.UnexpectedException, new Error("unexpected_exception", "Unexpected exception")},

            #endregion

            #region Other

            {EList.AuthHeaderInvalid, new Error("invalid_auth_header", "Invalid authentication header")},
            {EList.BadInput, new Error("bad_input", "Bad input")},

            #endregion        

            #region EGCInput
         
            {EList.IsExist, new Error("is_exist", "Položka se stejným jménem již existuje")},

            #endregion

            #region Filed

            {EList.FieldIsEmpty, new Error("empty_field", "Položka nemůže být prázdná")},
            {EList.FieldContainsBannedMarks, new Error("banned_marks", "Položka obsahuje zakázané znaky (;)")},
            {EList.FieldIsTooLong, new Error("long_field", "Položka je moc dlouhá")},
            {EList.FieldIsntNumber, new Error("istn_number", "Položka není číslo")},

            #endregion

        };

        /// <inheritdoc />
        /// <summary>
        ///     Constructor for AuthException
        /// </summary>
        /// <param name="e">Exception type according to the EList</param>
        public AuthException(EList e, string block) : base(BCode + (int)e, Errors[e].Code, Errors[e].Message) {
            this.block = block;
        }
    }
}
