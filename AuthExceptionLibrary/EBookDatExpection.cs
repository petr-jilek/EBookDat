using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExceptionLibrary
{
    public abstract class EBookDatExpection : Exception
    {
        #region Error

        protected class Error
        {
            public readonly string Code;
            public readonly string Message;

            public Error(string code, string message) {
                Code = code;
                Message = message;
            }
        }

        #endregion

        #region Fields

        /// <summary>
        ///     Numeric error code
        /// </summary>
        public int Id { get; }

        /// <summary>
        ///     Human-readable error code
        /// </summary>
        protected string Code { get; }

        #endregion


        #region Constructors

        /// <inheritdoc />
        /// <summary>
        ///     Custom exception constructor
        /// </summary>
        /// <param name="id">Error ID</param>
        /// <param name="code">Internal code</param>
        /// <param name="message">Message that may be sent to the user</param>
        /// <param name="args">Other arguments</param>
        protected EBookDatExpection(int id, string code, string message, params object[] args)
            : this(null, id, string.Empty, message, args) {
            Id = id;
            Code = code;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Custom exception constructor
        /// </summary>
        /// <param name="innerException">Inner exception</param>
        /// <param name="id">Error ID</param>
        /// <param name="code">Internal code</param>
        /// <param name="message">Message that may be sent to the user</param>
        /// <param name="args">Other arguments</param>
        protected EBookDatExpection(Exception innerException, int id, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException) {
            Id = id;
            Code = code;
        }

        #endregion

    }
}
