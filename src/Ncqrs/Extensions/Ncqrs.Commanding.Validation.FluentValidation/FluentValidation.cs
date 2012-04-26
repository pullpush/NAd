// Needs a seperate project, but I think a seperate project for a single class is a little overkill
// until it is needed in multiple projects.
namespace Ncqrs.Commanding.Validation
{
    using System;
    using System.Runtime.Serialization;

    using JetBrains.Annotations;

    [Serializable]
    public class CommandParameterValidationException : Exception
    {
        public CommandParameterValidationException() { }
        public CommandParameterValidationException(string message) : base(message) { }
        public CommandParameterValidationException(string message, Exception innerException) : base(message, innerException) { }
        protected CommandParameterValidationException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

namespace Ncqrs.Commanding.Validation.FluentValidation
{
    using System.Reflection;
    using System.Text;

    using global::FluentValidation;
    using global::FluentValidation.Attributes;
    using global::FluentValidation.Results;

    using ServiceModel;

    /// <summary>
    ///   Validates command parameters before they get executed.
    /// </summary>
    public class ValidateCommandInterceptor : ICommandServiceInterceptor
    {
        private readonly IValidatorFactory _factory;
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ValidateCommandInterceptor(IValidatorFactory validatorFactory = null)
        {
            _factory = validatorFactory ?? new AttributedValidatorFactory();
        }

        public void OnBeforeBeforeExecutorResolving(CommandContext context)
        {
            // Nothing
        }

        public void OnBeforeExecution(CommandContext context)
        {
            var validator = _factory.GetValidator(context.TheCommandType);
            if (validator != null)
            {
                var result = validator.Validate(context.TheCommand);
                if (!result.IsValid)
                {
                    var message = string.Format("Command validation failed on command {0}{1}", context.TheCommandType, CreateValidationSummary(result));
                    _logger.ErrorFormat(message);
                    throw new CommandParameterValidationException(message);
                }
            }
        }

        public void OnAfterExecution(CommandContext context)
        {
            // Nothing
        }

        private static string CreateValidationSummary(ValidationResult result)
        {
            if (result.IsValid)
                return string.Empty;

            var sb = new StringBuilder(result.Errors.Count);
            foreach (var failure in result.Errors)
            {
                sb.AppendLine();
                sb.AppendFormat(" (*) Property {0}: {1}", failure.PropertyName, failure.ErrorMessage);
            }
            return sb.ToString();
        }
    }
}