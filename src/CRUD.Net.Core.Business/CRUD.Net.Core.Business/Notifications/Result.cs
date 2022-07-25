using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Net.Core.Business.Notifications
{
    public class Result
    {
        public Result(bool sucesso, List<string> errors, List<string> messages)
        {
            Status = sucesso;
            Errors = errors;
            Messages = messages;
        }

        public bool Status { get; set; }

        public List<string> Errors { get; set; }

        public List<string> Messages { get; set; }

        public static Result Sucesso(List<string> messages)
        {
            return new Result(true, new List<string>(), messages);
        }

        public static Result Falha(List<string> errors)
        {
            return new Result(false, errors, new List<string>());
        }


    }
}
