namespace currency_converter.Modules.Domain.Commands
{
    public class CommandResult
    {
        #region Constructors

        public CommandResult()
        {
        }

        public CommandResult(string message, object data)
        {
            Message = message;
            Data = data;
        }

        public CommandResult(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        #endregion

        #region Properties

        public bool Sucess { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        #endregion

        #region Methods

        public CommandResult SetSuccessResult()
        {
            Sucess = true;

            return this;
        }

        public CommandResult SetFailResult()
        {
            Sucess = false;

            return this;
        }

        #endregion
    }
}