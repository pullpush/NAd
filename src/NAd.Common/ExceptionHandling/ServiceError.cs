
namespace NAd.Common.ExceptionHandling
{
    public class ServiceError : Error
    {
        public static Error RecordDoesNotExistAnymore = new Error("RecordDoesNotExistAnymore");
        public static Error RecordIsChangedByAnotherUser = new Error("RecordIsChangedByAnotherUser");
        public static Error RecordIsUsedByAnotherRecord = new Error("RecordIsUsedByAnotherRecord");
        public static Error NameCodeOrNumberIsNotUnique = new Error("NameCodeOrNumberIsNotUnique");
        public static Error DataSizeWasExceeded = new Error("DataSizeWasExceeded");
        public static Error ErrorRetrievingClassifieds = new Error("ErrorRetrievingClassifieds");

        public ServiceError(string code) : base(code)
        {
        }
    }
}