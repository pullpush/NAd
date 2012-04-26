
namespace NAd.Common
{
    public class Error : Descriptor<string>
    {
        public static Error Internal = new Error("InternalError");

        public Error(string code)
            : base(code)
        {

        }
    }
}